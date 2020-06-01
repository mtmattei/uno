﻿#if __WASM__
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Uno.Devices.Midi.Internal;
using Uno.Extensions;
using Windows.Devices.Enumeration;
using static Uno.Foundation.WebAssemblyRuntime;

namespace Uno.Devices.Enumeration.Internal.Providers.Midi
{
	/// <summary>
	/// Must be public to allow for WASM binding
	/// </summary>
	internal abstract class MidiDeviceClassProviderBase : IDeviceClassProvider
	{
		private const string JsType = "Uno.Devices.Enumeration.Internal.Providers.Midi.MidiDeviceClassProvider";

		private readonly bool _isInput = false;
		

		public MidiDeviceClassProviderBase(bool isInput) => _isInput = isInput;

		public bool CanWatch => true;

		public event EventHandler<DeviceInformation> WatchAdded;
		public event EventHandler<DeviceInformation> WatchEnumerationCompleted;
		public event EventHandler<DeviceInformationUpdate> WatchRemoved;
		public event EventHandler<object> WatchStopped;
		public event EventHandler<DeviceInformationUpdate> WatchUpdated;

		public async Task<DeviceInformation[]> FindAllAsync()
		{
			Debug.WriteLine("FindAll started");
			if (!await WasmMidiAccess.RequestAsync())
			{
				throw new AccessViolationException("Can't access Web MIDI API");
			}

			return GetMidiDevices().ToArray();
		}

		public void WatchStart()
		{
			//TODO: Fire and forget, not good.
			Task.Run(async () =>
			{
				if (!await WasmMidiAccess.RequestAsync())
				{
					throw new AccessViolationException("Can't access Web MIDI API");
				}
				var devices = GetMidiDevices().ToArray();
				foreach (var device in devices)
				{
					WatchAdded?.Invoke(this, device);
				}
				OnEnumerationCompleted(devices.LastOrDefault());

				//TODO: initialize device watch
			});
		}

		public void WatchStop()
		{
			//_watchMidiManager.UnregisterDeviceCallback(_deviceCallback);
			//_deviceCallback?.Dispose();
			//_deviceCallback = null;
			//_watchMidiManager.Dispose();
			WatchStopped?.Invoke(this, null);
		}



		//internal (MidiDeviceInfo device, MidiDeviceInfo.PortInfo port) GetNativeDeviceInfo(string midiDeviceId)
		//{
		//	var parsed = ParseMidiDeviceId(midiDeviceId);
		//	using (var midiManager = ContextHelper.Current.GetSystemService(Context.MidiService).JavaCast<MidiManager>())
		//	{
		//		return midiManager
		//			.GetDevices()
		//			.Where(d => d.Id == parsed.id)
		//			.SelectMany(d =>
		//				d.GetPorts()
		//					.Where(p =>
		//						p.Type == _portType &&
		//						p.PortNumber == parsed.portNumber)
		//					.Select(p => (device: d, port: p)))
		//			.FirstOrDefault();
		//	}
		//}

		//private void OnDeviceAdded(MidiDeviceInfo deviceInfo)
		//{
		//	foreach (var port in deviceInfo.GetPorts().Where(p => p.Type == _portType))
		//	{
		//		WatchAdded?.Invoke(this, CreateDeviceInformation(deviceInfo, port));
		//	}
		//}

		private void OnDeviceRemoved()
		{
			OnDeviceUpdated();
			//foreach (var port in deviceInfo.GetPorts().Where(p => p.Type == _portType))
			//{
			WatchRemoved?.Invoke(this, null);
			//}
		}

		private void OnDeviceUpdated()
		{
			OnDeviceRemoved();
			//foreach (var port in status.DeviceInfo.GetPorts().Where(p => p.Type == _portType))
			//{
			WatchUpdated?.Invoke(this, null);
			//}
		}

		private void OnEnumerationCompleted(DeviceInformation lastDeviceInformation)
		{
			WatchEnumerationCompleted?.Invoke(this, lastDeviceInformation);
		}

		private IEnumerable<DeviceInformation> GetMidiDevices()
		{
			var command = $"{JsType}.findDevices({_isInput.ToString().ToLowerInvariant()})";
			var result = InvokeJS(command);

			var devices = result.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var device in devices)
			{
				var deviceMetadata = device.Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
				var id = Uri.UnescapeDataString(deviceMetadata[0]);
				var name = Uri.UnescapeDataString(deviceMetadata[1]);
				var identifier = new DeviceIdentifier(
					id,
					_isInput ? DeviceClassGuids.MidiIn : DeviceClassGuids.MidiOut);
				yield return new DeviceInformation(identifier)
				{
					Name = name
				};
			}
		}
	}
}
#endif
