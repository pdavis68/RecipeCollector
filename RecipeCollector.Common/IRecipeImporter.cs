using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCollector.Common
{
    public interface IRecipeImporter
    {
        string ProductName { get; }
        string Site { get; }
        Version Version { get; }
        Task<Recipe> ImportRecipe(string url);
    }
}
