using RecipeCollector.Common;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Threading.Tasks;

namespace CooksDotComCollector
{
    [Export(typeof(IRecipeImporter))]
    public class CooksImporter : IRecipeImporter
    {
        private Version _version = new Version(1, 0, 0, 0);

        public string ProductName => "COOKS.COM";

        public Version Version => _version;

        public string Site => "cooks.com";

        public async Task<Recipe> ImportRecipe(string url)
        {
            string html = string.Empty;
            using (WebClient client = new WebClient()) 
            {
                html = await client.DownloadStringTaskAsync(new Uri(url));
            }

            return GenerateRecipe(html);
        }

        private Recipe GenerateRecipe(string html)
        {
            return null;
        }
    }
}
