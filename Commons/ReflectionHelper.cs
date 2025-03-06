using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// loop through all assemblies
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAllcompiledAssemblies(bool skipSystemAssemblies = true)
        {
            IEnumerable<Assembly> assemblies = DependencyContext.Default!.CompileLibraries
              .Where(l => !l.Serviceable && l.Type != "package" && (skipSystemAssemblies ? l.Type == "project" : true))
              .Select(l => Assembly.Load(new AssemblyName(l.Name)));

            return assemblies;
        }

    }
}
