using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Models
{
	public static class MyExtenshionMethods
	{
		public static decimal TotalPrices(this IEnumerable<Product> productEnum)
		{
			return productEnum.Sum(x => x.Price);
		}

		public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string categoryParams)
		{
			foreach (Product product in productEnum)
				if (product.Category == categoryParams)
					yield return product;
		}
	}
}