﻿#nullable enable
// <autogenerated />
#pragma warning disable // Disable all warnings for this generated file

// Register an embedded sources provider for Hot Reload
[assembly: global::System.Reflection.AssemblyMetadata("Uno.HotDesign.HotReloadEmbeddedXamlSourceFilesProvider", "MyProject.__Sources__.EmbeddedXamlSourcesProvider")]

namespace MyProject.__Sources__;

/// <summary>
/// Provides access to the embedded XAML sources
/// </summary>
/// <remarks>
/// This class is used to provide the embedded XAML sources to the Hot Reload engine.
/// This is not intended to be used directly by application code.
/// WON'T BE GENERATED ON RELEASE BUILDS
/// </remarks>
internal static class EmbeddedXamlSourcesProvider
{
	// key=absolute file path
	private static global::System.Collections.Generic.IDictionary<string, (string ActualPath, global::System.Func<(string Hash, string Payload)> Getter)>? _XamlSources;

	// hash of all the paths
	private static volatile string? _filesListHash;

	// get the current value of the update counter
	private static volatile uint _updateCounter;

	private static readonly global::System.Text.Encoding _utf8 = global::System.Text.Encoding.UTF8;

	// The content of this method only changes when the file list changes
	private static global::System.Collections.Generic.IDictionary<string, (string ActualPath, global::System.Func<(string Hash, string Payload)> Getter)> EnsureInitialize()
	{
		const string currentListHash = "d6cd66944958ced0c513e0a04797b51d"; // that's the hash of all the paths, used to detect changes in the file list following a HR operation

		// Determine if the sources have been updated or not initialized yet
		var previousHashList = _XamlSources;
		var needsUpdate = previousHashList is null || _filesListHash != currentListHash;

		if (needsUpdate)
		{
			var xamlSources = new global::System.Collections.Generic.Dictionary<string, (string ActualPath, global::System.Func<(string Hash, string Payload)> Getter)>(1, global::System.StringComparer.OrdinalIgnoreCase);

			// Use method groups to avoid closure allocation and ensure no lambda is created, to allow proper HR support
			xamlSources[NormalizePath(@"C:/Project/0/MainPage.xaml")] = (NormalizePath(@"C:/Project/0/MainPage.xaml"), GetSources_MainPage_d6cd66944958ced0c513e0a04797b51d);

			if (global::System.Threading.Interlocked.CompareExchange(ref _XamlSources, xamlSources, previousHashList) == previousHashList)
			{
				// The sources were updated successfully (no other thread modified them concurrently)
				_filesListHash = currentListHash;
				_updateCounter++;
			}
		}

		return _XamlSources;
	}

	/// <summary>
	/// Gets the current update counter, used to detect changes in the sources.
	/// </summary>
	/// <remarks>
	/// This counter is incremented each time a Hot Reload sources update is detected.
	/// </remarks>
	public static uint UpdateCounter
	{
		get
		{
			EnsureInitialize();
			return _updateCounter;
		}
	}

	public static global::System.Collections.Generic.IReadOnlyList<string> GetXamlFilesList() => [.. EnsureInitialize().Keys];

	public static string? GetNormalizedFileName(string path)
	{
		// Will return the normalized path if the file exists, or null if it doesn't.
		// (the returned value will be constant for the file and can be used in a dictionary using an ordinal comparer)
		var normalizedPath = NormalizePath(path);
		return EnsureInitialize().TryGetValue(normalizedPath, out var entry) ? entry.ActualPath : null;
	}

	public static (string ActualPath, string Hash, string Payload)? GetXamlFile(string path)
	{
		var normalizedPath = NormalizePath(path);
		if (EnsureInitialize().TryGetValue(normalizedPath, out var entry))
		{
			var sources = entry.Getter();
			return (entry.ActualPath, sources.Hash, sources.Payload);
		}
		return null;
	}

	private static string NormalizePath(string path) => path.Replace('\\', '/');

	#region Sources for C:/Project/0/MainPage.xaml
	private static (string hash, string payload) GetSources_MainPage_d6cd66944958ced0c513e0a04797b51d()
	{
		return (
			"1c06c16d398ea19bdc8fe30e7d2ba2dcb58578ab", // hash
			_utf8.GetString(""""""
			<Page x:Class="TestRepro.MainPage"
			    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
			<!-- This is a comment having potential escaping problems: " "" """ """" """"" -->
			<!-- This is a comment having potential escaping problems: " "" """ """" """"" -->
			</Page>
			""""""u8)); // Stored as UTF8 to minimize impact on assembly size / limitations
	}
	#endregion
}
