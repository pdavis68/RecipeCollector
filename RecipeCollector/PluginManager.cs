using RecipeCollector.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCollector
{
    public class PluginManager
    {
        [ImportMany]
        IEnumerable<IRecipeImporter> _recipes;

        public void Init()
        {
            string pluginsRoot = ConfigurationManager.AppSettings["PluginsRoot"];
            if (string.IsNullOrWhiteSpace(pluginsRoot))
            {
                throw new ConfigurationErrorsException("PluginsRoot AppSetting is missing.");
            }
            string[] pluginDirs = Directory.GetDirectories(pluginsRoot);
            var catalog = new AggregateCatalog();
            foreach(string pluginDir in pluginDirs)
            {
                catalog.Catalogs.Add(new DirectoryCatalog(pluginDir));
            }
        }
    }
}
