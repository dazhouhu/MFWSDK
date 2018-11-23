using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{

    public class DeviceManager:BaseModel
    {
        #region Fields
        private ILog log = LogManager.GetLogger("MFW.DeviceManager");
        private PropertyManager propertyManager = PropertyManager.GetInstance();
        private ObservableCollection<Device> devices = new ObservableCollection<Device>();
        #endregion

        #region Constructors
        private static DeviceManager _instance = null;
        private DeviceManager() { }

        public static DeviceManager GetInstance()
        {
            if(null == _instance)
            {
                _instance = new DeviceManager();
            }
            return _instance;
        }
        #endregion

        #region Events
        public event NotifyCollectionChangedEventHandler DevicesChanged;
        #endregion

        #region CurrentDevice
        private Device _currentAudioInputDevice;
        public Device CurrentAudioInputDevice
        {
            get { return _currentAudioInputDevice; }
            set
            {
                if (_currentAudioInputDevice != value)
                {
                    _currentAudioInputDevice = value;
                    propertyManager.SetProperty(PropertyKey.AUDIO_INPUT_DEVICE, _currentAudioInputDevice?.DeviceHandle);
                    NotifyPropertyChanged("CurrentAudioInputDevice");
                }
            }
        }
        private Device _currentAudioOutputDevice;
        public Device CurrentAudioOutputDevice
        {
            get { return _currentAudioOutputDevice; }
            set
            {
                if (_currentAudioOutputDevice != value)
                {
                    _currentAudioOutputDevice = value;
                    propertyManager.SetProperty(PropertyKey.AUDIO_OUTPUT_DEVICE, _currentAudioOutputDevice?.DeviceHandle);
                    NotifyPropertyChanged("CurrentAudioOutputDevice");
                }
            }
        }
        private Device _currentVideoInputDevice;
        public Device CurrentVideoInputDevice
        {
            get { return _currentVideoInputDevice; }
            set
            {
                if (_currentVideoInputDevice != value)
                {
                    _currentVideoInputDevice = value;
                    propertyManager.SetProperty(PropertyKey.VIDEO_INPUT_DEVICE, _currentVideoInputDevice?.DeviceHandle);
                    NotifyPropertyChanged("CurrentVideoInputDevice");
                }
            }
        }

        #endregion

        #region Methods
        public void AddDevice(Device device)
        {
            if (device.DeviceName.Contains("none"))
            {
                return;
            }
            if (!ContainDevice(device.DeviceHandle))
            {
                devices.Add(device);
                switch (device.DeviceType)
                {
                    case DeviceType.AUDIOINPUT:
                    case DeviceType.AUDIOOUTPUT:
                        {
                            var audioInput = GetDevicesByType(DeviceType.AUDIOINPUT).FirstOrDefault();
                            var audioOutput = GetDevicesByType(DeviceType.AUDIOOUTPUT).FirstOrDefault();
                            var inputHandle = audioInput?.DeviceHandle;
                            var outputHandle = audioOutput?.DeviceHandle;
                            if (null == CurrentAudioInputDevice && null != audioInput)
                            {
                                CurrentAudioInputDevice = audioInput;
                                WrapperProxy.SetAudioDevice(inputHandle, outputHandle);
                                WrapperProxy.SetAudioDeviceForRingtone(outputHandle);
                            }
                            if (null == CurrentAudioOutputDevice && null != outputHandle)
                            {
                                CurrentAudioOutputDevice = audioOutput;
                                WrapperProxy.SetAudioDevice(inputHandle, outputHandle);
                                WrapperProxy.SetAudioDeviceForRingtone(outputHandle);
                            }
                        }
                        break;
                    case DeviceType.VIDEOINPUT:
                        {
                            if (null == CurrentAudioOutputDevice)
                            {
                                var video = GetDevicesByType(DeviceType.VIDEOINPUT).FirstOrDefault();
                                var videoHandle = video?.DeviceHandle;
                                if (null != videoHandle)
                                {
                                    CurrentVideoInputDevice = video;
                                    WrapperProxy.SetVideoDevice(videoHandle);
                                }
                            }
                        }
                        break;
                }
            }
        }
        public void RemoveDevice(string deviceHandle)
        {
            var device = GetDevice(deviceHandle);
            if(null != device)
            {
                RemoveDevice(device);
            }
        }
        public void RemoveDevice(Device device)
        {
            devices.Remove(device);
        }

        public Device GetDevice(string deviceHandle)
        {
            return devices.FirstOrDefault(d => d.DeviceHandle == deviceHandle);
        }
        public bool ContainDevice(string deviceHandle)
        {
            return null != GetDevice(deviceHandle);
        }

        public List<Device> GetDevicesByType(DeviceType deviceType)
        {
            return devices.Where(d => d.DeviceType == deviceType).ToList();
        }
        #endregion
    }
}
