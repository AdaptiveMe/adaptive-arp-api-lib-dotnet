using System;
using Mono.Options;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

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

		static void Process(string file, string version) {
			if (File.Exists (file)) {
				Stream s = File.Open (file, FileMode.Open);
				XDocument d = XDocument.Load (s, LoadOptions.PreserveWhitespace);
				s.Close ();
				//ChangeVersion (d, file, version);

			} else {
				Console.WriteLine ("File : '" + file + "' does not exist.");
				Environment.Exit (-1);
			}
		}

		static void ChangeVersion(XDocument document, string file, string version) {
			XElement element = document.Root.Element ("metadata").Element ("version");
			Console.WriteLine ("Current version: "+element.Value);
			element.Value = version;
			Console.WriteLine ("    New version: "+element.Value);
			if (File.Exists(file+".new")) {
				File.Delete(file+".new");
			}
			Stream s = File.Open (file+".new", FileMode.CreateNew);
			document.Save (s);
			s.Close ();

			File.Replace (file + ".new", file, file + ".bkp");
		}
	}
}