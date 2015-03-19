using System;
using Mono.Options;
using System.Collections.Generic;

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
			List<string> extra;
			try {
				extra = p.Parse (args);
			}
			catch (OptionException e) {
				Console.Write (COMMAND_NAME+": ");
				Console.WriteLine (e.Message);
				Console.WriteLine ("Try '"+COMMAND_NAME+" --help' for more information.");
				return;
			}

			if (FileName == null || VersionId == null) {
				ShowHelp ();
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
	}
}
