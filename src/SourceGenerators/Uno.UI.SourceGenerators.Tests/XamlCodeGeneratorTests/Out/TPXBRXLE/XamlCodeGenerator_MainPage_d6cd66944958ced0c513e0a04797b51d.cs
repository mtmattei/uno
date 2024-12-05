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
			Resources[
			"NullableBoolConverter"
			] = 
			new global::TestRepro.NullableBoolConverter
			{
				// Source 0\MainPage.xaml (Line 10:4)
			}
			;
			// Source 0\MainPage.xaml (Line 1:2)
			base.Content = 
			new global::Microsoft.UI.Xaml.Controls.StackPanel
			{
				IsParsing = true,
				// Source 0\MainPage.xaml (Line 12:3)
				Children = 
				{
					new Microsoft.UI.Xaml.ElementStub( () => 
					new global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton
					{
						IsParsing = true,
						Name = "LoadElement",
						// Source 0\MainPage.xaml (Line 13:4)
						Content = "Loaded via x:Load and toggle enable for buttons"
						,
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
					{
					/* _isTopLevelDictionary:False */
					__that._component_0 = __p1;
					__nameScope.RegisterName("LoadElement", __p1);
					__that.LoadElement = __p1;
					// FieldModifier public
					/* Skipping x:Load attribute already applied to ElementStub */
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
					__p1.CreationComplete();
					}
					))
					)					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler1)(__p1 => 
					{
					__p1.Name = "LoadElement";
					_LoadElementSubject.ElementInstance = __p1;
					__p1.SetBinding(
						global::Microsoft.UI.Xaml.ElementStub.LoadProperty,
						new Microsoft.UI.Xaml.Data.Binding()
						{
							Mode = global::Microsoft.UI.Xaml.Data.BindingMode.OneWay,
							Converter = (global::Microsoft.UI.Xaml.Data.IValueConverter)global::Uno.UI.ResourceResolverSingleton.Instance.ResolveResourceStatic("NullableBoolConverter", typeof(global::Microsoft.UI.Xaml.Data.IValueConverter), context: global::MyProject.GlobalStaticResources.__ParseContext_),
						}
							.BindingApply(___b =>  /*defaultBindModeOneTime ToggleLoad.IsChecked*/ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, __that, ___ctx => ___ctx is global::TestRepro.MainPage ___tctx ? ((true, ___tctx.ToggleLoad.IsChecked)) : (false, default), null , new [] {"ToggleLoad.IsChecked"}))
					);
					__that._component_1 = __p1;
					var _component_1_update_That = (this as global::Uno.UI.DataBinding.IWeakReferenceProvider).WeakReference;
					var _component_1_update_subject_capture = _LoadElementSubject;
					void _component_1_update(global::Microsoft.UI.Xaml.ElementStub sender)
					{
						if (_component_1_update_That.Target is global::TestRepro.MainPage that)
						{
							if (sender.IsMaterialized)
							{
								that.Bindings.UpdateResources();
								that.Bindings.NotifyXLoad("LoadElement");
							}
							else
							{
								_LoadElementSubject.ElementInstance = null;
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
					,
					new global::Microsoft.UI.Xaml.Controls.Button
					{
						IsParsing = true,
						Name = "button1",
						// Source 0\MainPage.xaml (Line 14:4)
						Content = "Button1"
						,
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler2)(__p1 => 
					{
					/* _isTopLevelDictionary:False */
					__that._component_2 = __p1;
					__nameScope.RegisterName("button1", __p1);
					__that.button1 = __p1;
					// FieldModifier public
					__p1.SetBinding(
						global::Microsoft.UI.Xaml.Controls.Button.TagProperty,
						new Microsoft.UI.Xaml.Data.Binding()
						{
							Mode = BindingMode.OneTime,
						}
							.BindingApply(___b =>  /*defaultBindModeOneTime */ global::Uno.UI.Xaml.BindingHelper.SetBindingXBindProvider(___b, __that, ___ctx => ___ctx is global::TestRepro.MainPage ___tctx ? ((true, ___ctx)) : (false, default), null ))
					);
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
					__p1.CreationComplete();
					}
					))
					,
					new global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton
					{
						IsParsing = true,
						Name = "ToggleLoad",
						IsChecked = false,
						// Source 0\MainPage.xaml (Line 15:4)
						Content = "Toggle Load"
						,
					}
					.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler0)(__p1 => 
					{
					__nameScope.RegisterName("ToggleLoad", __p1);
					__that.ToggleLoad = __p1;
					// FieldModifier public
					global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
					__p1.CreationComplete();
					}
					))
					,
				}
			}
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler3)(__p1 => 
			{
			global::Uno.UI.FrameworkElementHelper.SetBaseUri(__p1, __baseUri_MainPage_d6cd66944958ced0c513e0a04797b51d);
			__p1.CreationComplete();
			}
			))
			;
			
			this
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler4)(__p1 => 
			{
			// Source 0\MainPage.xaml (Line 1:2)
			
			// WARNING Property __p1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply((MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions.XamlApplyHandler4)(__p1 => 
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
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _LoadElementSubject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton LoadElement
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton)_LoadElementSubject.ElementInstance;
			}
			set
			{
				_LoadElementSubject.ElementInstance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _button1Subject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.Button button1
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Button)_button1Subject.ElementInstance;
			}
			set
			{
				_button1Subject.ElementInstance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _ToggleLoadSubject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton ToggleLoad
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton)_ToggleLoadSubject.ElementInstance;
			}
			set
			{
				_ToggleLoadSubject.ElementInstance = value;
			}
		}
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_0_Holder = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton _component_0
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton)_component_0_Holder.Instance;
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
		private global::Microsoft.UI.Xaml.Markup.ComponentHolder _component_2_Holder = new global::Microsoft.UI.Xaml.Markup.ComponentHolder(isWeak: true);
		private global::Microsoft.UI.Xaml.Controls.Button _component_2
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Button)_component_2_Holder.Instance;
			}
			set
			{
				_component_2_Holder.Instance = value;
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
				if (name == "LoadElement")
				{
				}
			}
			void IMainPage_Bindings.Initialize()
			{
			}
			void IMainPage_Bindings.Update()
			{
				var owner = Owner;
				owner._component_0.ApplyXBind();
				owner._component_1.ApplyXBind();
				owner._component_2.ApplyXBind();
			}
			void IMainPage_Bindings.UpdateResources()
			{
				var owner = Owner;
				owner._component_0.UpdateResourceBindings();
				owner._component_1.UpdateResourceBindings();
				owner._component_2.UpdateResourceBindings();
			}
			void IMainPage_Bindings.StopTracking()
			{
			}
		}
	}
}
namespace MyProject
{
	static class MainPage_d6cd66944958ced0c513e0a04797b51dXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Microsoft.UI.Xaml.ElementStub instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.ElementStub MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.ElementStub instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler2(global::Microsoft.UI.Xaml.Controls.Button instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Button MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Button instance, XamlApplyHandler2 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler3(global::Microsoft.UI.Xaml.Controls.StackPanel instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.StackPanel MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.StackPanel instance, XamlApplyHandler3 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler4(global::Microsoft.UI.Xaml.Controls.Page instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Page MainPage_d6cd66944958ced0c513e0a04797b51d_XamlApply(this global::Microsoft.UI.Xaml.Controls.Page instance, XamlApplyHandler4 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
