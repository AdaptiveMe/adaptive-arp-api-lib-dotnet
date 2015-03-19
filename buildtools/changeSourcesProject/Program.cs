using System;
using Mono.Options;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;

namespace changeSourcesProject
{
	class MainClass
	{
		private static string COMMAND_NAME = "changeSourcesProject";
		private static string FileName;
		private static string FileSource;
		private static OptionSet p = new OptionSet () {
			{ "p|project=", "the {PROJECT} file to change", v => FileName = v },
			{ "s|source=", "the {SOURCE} path to apply in the project", v => FileSource = v },
			{ "h|help",  "show this message and exit", v => ShowHelp()}
		};

		public static void Main (string[] args)
		{
			try {
				p.Parse (args);
			}
			catch (OptionException e) {
				Console.Write (COMMAND_NAME+": ");
				Console.WriteLine (e.Message);
				Console.WriteLine ("Try '"+COMMAND_NAME+" --help' for more information.");
				return;
			}

			if (FileName == null || FileSource == null) {
				ShowHelp ();
			} else {
				Process (FileName, FileSource);
			}
		}

		static void ShowHelp ()
		{
			Console.WriteLine ("Usage: "+COMMAND_NAME+" [OPTIONS]");
			Console.WriteLine ("Changes the version string in a project file.");
			Console.WriteLine ();
			Console.WriteLine ("Options:");
			p.WriteOptionDescriptions (Console.Out);
		}

		static void Process(string file, string sources) {
			if (File.Exists (file)) {
				Stream s = File.Open (file, FileMode.Open);
				XDocument d = XDocument.Load (s, LoadOptions.None);
				s.Close ();
				ChangeSources (d, file, sources);

			} else {
				Console.WriteLine ("File : '" + file + "' does not exist.");
				Environment.Exit (-1);
			}
		}

		static void ChangeSources(XDocument document, string file, string sources) {
			
			XElement targetElement = null;

			foreach (XNode node in document.Root.Nodes()) {
				if (node is XElement) {
					XElement element = (XElement)node;
					if (element.Name.LocalName.Equals ("ItemGroup")) {
						foreach (XElement child in element.Elements()) {
							if (child.Name.LocalName.Equals ("Compile")) {
								targetElement = element;
								break;
							}
						}
						if (targetElement != null) {
							break;
						}
					}
				}
			}

			targetElement.RemoveAll ();
			XElement assemblyInfo = new XElement(targetElement.Name.Namespace+"Compile", new XAttribute("Include", "Properties\\AssemblyInfo.cs"));
			targetElement.Add (assemblyInfo);

			if (Directory.Exists (sources)) {
				foreach (string child in Directory.GetFiles(sources, "*", SearchOption.AllDirectories)) {
					if (child.EndsWith(".cs")) {
						string childSource = MakeRelativePath (Path.GetFullPath (file), Path.GetFullPath (child));
						childSource = childSource.Replace('/', '\\');
						XElement childElement = new XElement(targetElement.Name.Namespace+"Compile", new XAttribute("Include", childSource));
						targetElement.Add (childElement);
					}
				}
			} 

			if (File.Exists(file+".new")) {
				File.Delete(file+".new");
			}


			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = Encoding.UTF8;
			settings.Indent = true;
			settings.IndentChars = "\t";

			XmlWriter writer = XmlTextWriter.Create(file+".new",settings);
			document.Save (writer);
			writer.Close ();

			File.Replace (file + ".new", file, file + ".bkp");

		}

		public static String MakeRelativePath(String fromPath, String toPath)
		{
			if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
			if (String.IsNullOrEmpty(toPath))   throw new ArgumentNullException("toPath");

			Uri fromUri = new Uri(fromPath);
			Uri toUri = new Uri(toPath);

			if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

			Uri relativeUri = fromUri.MakeRelativeUri(toUri);
			String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			if (toUri.Scheme.ToUpperInvariant() == "FILE")
			{
				relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}

			return relativePath;
		}
	}
}