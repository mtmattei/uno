﻿#nullable enable

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Text;
using Microsoft.CodeAnalysis;
using Uno.Roslyn;
using Uno.UI.SourceGenerators.Helpers;
using Uno.DevTools.Telemetry;

namespace Uno.UI.SourceGenerators.XamlGenerator
{
	[Generator]
	public partial class XamlCodeGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
		}

		public void Execute(GeneratorExecutionContext context)
		{
			//var process = Process.GetCurrentProcess().ProcessName;
			//if (process.IndexOf("VBCSCompiler", StringComparison.OrdinalIgnoreCase) is not -1
			//	|| process.IndexOf("csc", StringComparison.OrdinalIgnoreCase) is not -1)
			//{
			//	Debugger.Launch();
			//}

			//Debugger.Launch();

			if (PlatformHelper.IsValidPlatform(context))
			{
				var gen = new XamlCodeGeneration(context);
				var generatedTrees = gen.Generate();

				foreach (var tree in generatedTrees)
				{
					context.AddSource(tree.Key, tree.Value);
					try
					{
						File.WriteAllText(Path.Combine("C:\\Src\\_Gen", tree.Key + ".cs"), tree.Value.ToString());
					}
					catch { }
				}

				DumpXamlSourceGeneratorState(context, generatedTrees);
			}
		}
	}
}
