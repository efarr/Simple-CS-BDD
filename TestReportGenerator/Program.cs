using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace TestReportGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				(new ReportGenerator()).Process(args);
			}
			catch (ReflectionTypeLoadException e)
			{
				Console.WriteLine(e.LoaderExceptions);
			}
		}
	}

    class ReportGenerator
    {
        private readonly Dictionary<string, Dictionary<string, IList<string>>> _namespaces = new Dictionary<string, Dictionary<string, IList<string>>>();

        public void Process(string[] args)
        {
            foreach (var fileName in args)
            {
                ProcessAssembly(fileName);
            }

            WriteTextFile(args);
        }

        private void ProcessAssembly(string fileName)
        {
            foreach (Type type in AllFixtureClasses(fileName))
            {
                string concerning = type.FullName.Split('.').Where(s => s.StartsWith("Concerning")).FirstOrDefault();

                if (concerning == null)
                {
                    Console.WriteLine(type.FullName);
                }
                else
                {
                    if (!_namespaces.ContainsKey(concerning))
                        _namespaces[concerning] = new Dictionary<string, IList<string>>();

                    _namespaces[concerning][type.Name] = new List<string>();

                    AddMethodNamesToCollection(concerning, type);
                }
            }
        }

        private void AddMethodNamesToCollection(string concerning, Type type)
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.ReflectedType.IsPublic && method.GetCustomAttributes(typeof (TestAttribute), true).Length > 0)
                {
                    _namespaces[concerning][type.Name].Add(method.Name);
                }
            }
        }

        private void WriteTextFile(string[] args)
        {
            TextWriter textWriter = new StreamWriter(args[0] + ".txt");

            foreach (string concerning in _namespaces.Keys.OrderBy(k => k))
            {
                textWriter.WriteLine("# {0}", concerning.PascalToSpaces());
                foreach (string test in _namespaces[concerning].Keys.OrderBy(k => k))
                {
                    textWriter.WriteLine("## {0}", test.UnderscoreToSpaces());
                    foreach (string method in _namespaces[concerning][test])
                    {
                        textWriter.WriteLine("* {0}", method.UnderscoreToSpaces());
                    }
                    textWriter.WriteLine();
                }
                textWriter.WriteLine();
            }
            AppendCssStyles(textWriter);
            textWriter.Close();
        }

        private static IEnumerable<Type> AllFixtureClasses(string assemblyName)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            return assembly.GetTypes().Where(
                t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes(typeof(TestFixtureAttribute), true).Length > 0);
        }

        private static void AppendCssStyles(TextWriter textWriter)
        {
            textWriter.WriteLine(
@"<style type=""text/css"">
body { font-family: Arial, Helvetica, Sans-serif; font-size: 12pt; padding: 2em; }
th, td { margin-right: 12px; padding-right: 12px; }
dt { font-weight: bold; float: left; clear: left; width: 16em; background-color: #eee; padding: 3px 6px 3px 6px; margin-right: 6px; text-align: right; }
dd { padding: 3px; }
h1 { font-size: 20px; } 
h2 { font-size: 16px; }
</style>");
        }
    }

	public static class StringExtensions
	{
		public static string PascalToSpaces(this string target)
		{
			return Regex.Replace(target, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
		}
        
        public static string UnderscoreToSpaces(this string target)
        {
            return target.Replace('_', ' ');
        }
    }
}
