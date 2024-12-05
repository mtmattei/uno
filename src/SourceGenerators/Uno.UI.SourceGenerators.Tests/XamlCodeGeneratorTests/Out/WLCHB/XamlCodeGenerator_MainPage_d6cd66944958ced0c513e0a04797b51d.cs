﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using MyProject;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Microsoft.UI.Xaml.UIElement;
#endif

namespace TestRepro
{
	partial class MainPage : global::Microsoft.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d = "ms-appx:///TestProject/";
		private global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			// Source 0\MainPage.xaml (Line 1:2)
			base.Content = 
			new Microsoft.UI.Xaml.ElementStub( () => 
			new global::Microsoft.UI.Xaml.Controls.ContentControl
			{
				IsParsing = true,
				Name = "topLevelContent",
				// Source 0\MainPage.xaml (Line 9:3)
				Content = 
				new global::Microsoft.UI.Xaml.Controls.TextBlock
				{
					IsParsing = true,
					Name = "innerTextBlock",
					// Source 0\MainPage.xaml (Line 10:4)
				}
				.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
				{
				/* _isTopLevelDictionary:False */
				__that._component_0 = __p1;
				__nameScope.RegisterName("innerTextBlock", __p1);
				__that.innerTextBlock = __p1;
				// FieldModifier public
				__p1.SetBinding(
					global::Microsoft.UI.Xaml.Controls.TextBlock.TextProperty,
					new Microsoft.UI.Xaml.Data.Binding()
					{
						Mode = global::Microsoft.UI.Xaml.Data.BindingMode.OneWay,
					}
						.BindingApply(___b =>  /*defaultBindModeOneTime InnerText*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, __that, ___ctx => ___ctx is global::TestRepro.MainPage ___tctx ? (TryGetInstance_xBind_1(___tctx, out var bindResult1) ? (true, bindResult1) : (false, default)) : (false, default), null , new [] {"InnerText"}))
				);
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
				__p1.CreationComplete();
				}
				))
				,
			}
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler1)(__p1 => 
			{
			__nameScope.RegisterName("topLevelContent", __p1);
			__that.topLevelContent = __p1;
			// FieldModifier public
			// Load false
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
			__p1.CreationComplete();
			}
			))
			)			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler2)(__p1 => 
			{
			__p1.Name = "topLevelContent";
			_topLevelContentSubject.ElementInstance = __p1;
			__that._component_1 = __p1;
			var _component_1_update_That = (this as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference;
			var _component_1_update_subject_capture = _topLevelContentSubject;
			void _component_1_update(global::Microsoft.UI.Xaml.ElementStub sender)
			{
				if (_component_1_update_That.Target is global::TestRepro.MainPage that)
				{
					if (sender.IsMaterialized)
					{
						that.Bindings.UpdateResources();
						that.Bindings.NotifyXLoad("topLevelContent");
					}
					else
					{
						_topLevelContentSubject.ElementInstance = null;
						_innerTextBlockSubject.ElementInstance = null;
						_innerTextBlockSubject.ElementInstance = null;
					}
				}
			}
			__p1.MaterializationChanged += _component_1_update;
			var owner = this;
			void _component_1_materializing(object sender)
			{
				if (_component_1_update_That.Target is global::TestRepro.MainPage that)
				{
					that._component_0.ApplyXBind();
					that._component_0.UpdateResourceBindings();
				}
			}
			__p1.Materializing += _component_1_materializing;
			}
			))
			;
			
			this
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler3)(__p1 => 
			{
			// Source 0\MainPage.xaml (Line 1:2)
			
			// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler3)(__p1 => 
			{
			// Class TestRepro.MainPage
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
			__p1.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

			Bindings = new MainPage_Bindings(this);
			((global::Microsoft.UI.Xaml.FrameworkElement)this).Loading += (s, e) =>
			{
				__that.Bindings.Update();
				__that.Bindings.UpdateResources();
			}
			;
		}
		partial void OnInitializeCompleted();
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _innerTextBlockSubject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.TextBlock innerTextBlock
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.TextBlock)_innerTextBlockSubject.ElementInstance;
			}
			set
			{
				_innerTextBlockSubject.ElementInstance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _topLevelContentSubject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.ContentControl topLevelContent
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.ContentControl)_topLevelContentSubject.ElementInstance;
			}
			set
			{
				_topLevelContentSubject.ElementInstance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_0_Holder = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.TextBlock _component_0
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.TextBlock)_component_0_Holder.Instance;
			}
			set
			{
				_component_0_Holder.Instance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_1_Holder = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: false);
		private global::Microsoft.UI.Xaml.ElementStub _component_1
		{
			get
			{
				return (global::Microsoft.UI.Xaml.ElementStub)_component_1_Holder.Instance;
			}
			set
			{
				_component_1_Holder.Instance = value;
			}
		}
		private interface IMainPage_Bindings
		{
			void Initialize();
			void Update();
			void UpdateResources();
			void StopTracking();
			void NotifyXLoad(string name);
		}
		#pragma warning disable 0169 //  Suppress unused field warning in case Bindings is not used.
		private IMainPage_Bindings Bindings;
		#pragma warning restore 0169
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private class MainPage_Bindings : IMainPage_Bindings
		{
			#if UNO_HAS_UIELEMENT_IMPLICIT_PINNING
			private global::System.WeakReference _ownerReference;
			private global::TestRepro.MainPage Owner { get => (global::TestRepro.MainPage)_ownerReference?.Target; set => _ownerReference = new global::System.WeakReference(value); }
			#else
			private global::TestRepro.MainPage Owner { get; set; }
			#endif
			public MainPage_Bindings(global::TestRepro.MainPage owner)
			{
				Owner = owner;
			}
			void IMainPage_Bindings.NotifyXLoad(string name)
			{
			}
			void IMainPage_Bindings.Initialize()
			{
			}
			void IMainPage_Bindings.Update()
			{
				var owner = Owner;
				owner._component_0.ApplyXBind();
			}
			void IMainPage_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings();
				owner._component_1.UpdateResourceBindings();
			}
			void IMainPage_Bindings.StopTracking()
			{
			}
		}
		private static bool TryGetInstance_xBind_1(global::TestRepro.MainPage ___tctx, out object o)
		{
			o = null;
			o = ___tctx.InnerText;
			return true;
		}
	}
}
namespace MyProject
{
	static class MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.TextBlock MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Microsoft.UI.Xaml.Controls.ContentControl instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.ContentControl MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.ContentControl instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler2(global::Microsoft.UI.Xaml.ElementStub instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.ElementStub MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.ElementStub instance, XamlApplyHandler2 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler3(global::Microsoft.UI.Xaml.Controls.Page instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Page MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Page instance, XamlApplyHandler3 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
