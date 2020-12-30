using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace NugetAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NugetReference> nugetReferences = new List<NugetReference>();
            // Check all subfolders for packages.configs
            var packageConfigs = Directory.GetFiles(".", "packages.config", SearchOption.AllDirectories);
            foreach (var packageConfig in packageConfigs)
            {
                var packageConfigDocument = XDocument.Load(packageConfig);
                var packageElements = packageConfigDocument.Root.Elements("package");

                foreach (var packageElement in packageElements)
                {
                    var nugetReference = new NugetReference();
                    nugetReference.Id = packageElement.Attribute("id").Value;
                    nugetReference.Version = packageElement.Attribute("version").Value;
                    nugetReferences.Add(nugetReference);
                }
            }


            foreach (var nugetReference in nugetReferences)
            {
                Console.WriteLine($"Package {nugetReference.Id} version {nugetReference.Version}");

            }
            // Check csproj for package references

            // write out all dependencies
        }
    }
}
