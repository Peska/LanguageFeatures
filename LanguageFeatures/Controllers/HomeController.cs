using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
	public class HomeController : Controller
	{
		public string Index()
		{
			return "Navigate to URL to show an example";
		}

		public ViewResult AutoProperty()
		{
			// create na new Product object
			Product product = new Product();

			// set the property value
			product.Name = "Kayak";

			// get the property
			string productName = product.Name;

			// generate the view
			return View("Result", (object)string.Format("Product name: {0}", productName));
		}

		public ViewResult CreateProduct()
		{
			Product product = new Product();

			product.ProductID = 100;
			product.Name = "Kayak";
			product.Description = "A boat for one person";
			product.Price = 275M;
			product.Category = "Watersports";

			return View("Result", (object)string.Format("Category: {0}", product.Category));
		}

		public ViewResult UseExtensions()
		{
			IEnumerable<Product> products = new ShoppingCart
			{
				Products = new List<Product>
				{
					new Product { Name = "Kayak", Price = 275M },
					new Product { Name = "LifeJacket", Price = 48.95M },
					new Product { Name = "Soccer ball", Price = 19.50M },
					new Product { Name = "Corner flag", Price = 34.95M }
				}
			};

			return View("Result", (object)string.Format("Total: {0:c}", products.TotalPrices()));
		}

		public ViewResult UseFilterExtensionMethod()
		{
			IEnumerable<Product> products = new ShoppingCart
			{
				Products = new List<Product>
				{
					new Product { Name = "Kayak", Price = 275M, Category = "Watersports" },
					new Product { Name = "LifeJacket", Price = 48.95M, Category = "Watersports" },
					new Product { Name = "Soccer ball", Price = 19.50M, Category = "Soccer" },
					new Product { Name = "Corner flag", Price = 34.95M, Category = "Soccer" }
				}
			};

			Func<Product, bool> categoryFilter = x => x.Category == "Soccer";

			return View("Result", (object)string.Format("Total in Soccer: {0:c}", products.Filter(categoryFilter).TotalPrices()));
        }

		public ViewResult GetPageLength()
		{
			Task<long?> task = MyAsyncMethods.GetPageLength();

			return View("Result", (object)string.Format("Length: {0}", task.Result));
		}
	}
}