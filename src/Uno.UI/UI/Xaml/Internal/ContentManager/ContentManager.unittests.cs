﻿#nullable enable

using Microsoft.UI.Xaml;

namespace Uno.UI.Xaml.Controls;

partial class ContentManager
{
	static partial void LoadRootElementPlatform(XamlRoot xamlRoot, UIElement rootElement)
	{
		(rootElement as FrameworkElement)?.ForceLoaded();
	}
}
