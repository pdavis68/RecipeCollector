using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCollector.Common
{
    public interface IRecipeExporter
    {
        string ProductName { get; }
        string FileExtension { get; }
        Version Version { get; }
        Task<byte[]> ExportRecipe(Recipe recipe);
    }
}
