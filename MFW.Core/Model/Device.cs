namespace MFW.Core
{
    public class Device
    {
        private DeviceType _deviceType;
        private string _deviceHandle;
        private string _deviceName;

        public Device(DeviceType deviceType, string deviceHandle, string deviceName)
        {
            this._deviceType = deviceType;
            this._deviceHandle = deviceHandle;
            this._deviceName = deviceName;
        }

        public DeviceType DeviceType { get { return this._deviceType; } }
        public string DeviceHandle { get { return this._deviceHandle; } }
        public string DeviceName { get { return this._deviceName; } }
    }
}
