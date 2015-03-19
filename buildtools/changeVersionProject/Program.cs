using System;
using Mono.Options;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace changeVersionProject
{
	class MainClass
	{
		private static string COMMAND_NAME = "changeVersionProject";
		private static string FileName;
		private static string VersionId;
		private static OptionSet p = new OptionSet () {
			{ "p|project=", "the {PROJECT} file to change", v => FileName = v },
			{ "v|version=", "the {VERSION} to apply to the file", v => VersionId = v },
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

			if (FileName == null || VersionId == null) {
				ShowHelp ();
			} else {
				Process (FileName, VersionId);
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
				ChangeVersion (d, version);

			} else {
				Console.WriteLine ("File : '" + file + "' does not exist.");
				Environment.Exit (-1);
			}
		}

		static void ChangeVersion(XDocument document, string version) {
			IEnumerable<XElement> childList = document.Elements();
			foreach (XElement e in childList) {
				Console.WriteLine (e);
			}
		}
			
	}
}