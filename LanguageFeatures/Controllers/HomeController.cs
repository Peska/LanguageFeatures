using System.Web.Mvc;
using LanguageFeatures.Models;

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
    }
}