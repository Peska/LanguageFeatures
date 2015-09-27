using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
	public class MyAsyncMethods
	{
		public async static Task<long?> GetPageLength()
		{
			HttpClient client = new HttpClient();

			HttpResponseMessage httpTask = await client.GetAsync("http://google.com");

			return httpTask.Content.Headers.ContentLength;
		}
	}
}