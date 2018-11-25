using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class PropertyManager
    {
        #region Fields
        private IDictionary<PropertyKey, string> _properties;
        private ILog log = LogManager.GetLogger("MFW.PropertyManager");
        #endregion

        #region Constructors
        private static readonly object lockObj = new object();
        private static PropertyManager _instance = null;
        private PropertyManager()
        {
            _properties = new Dictionary<PropertyKey, string>();
        }
        public static PropertyManager GetInstance()
        {
            if(null == _instance)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new PropertyManager();
                    }
                }
            }
            return _instance;
        }
        #endregion

        #region Set 
        public void SetProperty(PropertyKey key, string value)
        {
            log.Info(string.Format(string.Format("SetProperty:{0}={1}", key, value)));
            _properties[key] = value;
            if (key <= PropertyKey.PLCM_MFW_KVLIST_KEY_MAXSYS)
            {
                var errno = WrapperProxy.SetProperty(key, value);
                if (errno != ErrorNumber.OK)
                {
                    var errMsg = string.Format("{0}设定失败,err={1}", key, errno);
                    log.Error(errMsg);
                    throw new Exception(errMsg);
                }
                /*
                errno = WrapperProxy.UpdateConfig();
                if (errno != ErrorNumber.OK)
                {
                    var errMsg = string.Format("{0}更新配置失败,err={1}", key, errno);
                    log.Error(errMsg);
                    throw new Exception(errMsg);
                }
                */
            }
            else
            {
                switch (key)
                {
                    case PropertyKey.LocalAddr:break;
                    case PropertyKey.CalleeAddr: break;
                    case PropertyKey.AUDIO_INPUT_DEVICE:
                        {

                        }
                        break;
                    case PropertyKey.AUDIO_OUTPUT_DEVICE:
                        {

                        }
                        break;
                    case PropertyKey.AUDIO_OUTPUT_DEVICE_FOR_RINGTONE:
                        {

                        }
                        break;
                    case PropertyKey.VIDEO_INPUT_DEVICE:
                        {

                        }
                        break;
                    case PropertyKey.MONITOR_DEVICE: break;

                    /*Sound Effects*/
                    case PropertyKey.SOUND_INCOMING: break;
                    case PropertyKey.SOUND_CLOSED: break;
                    case PropertyKey.SOUND_RINGING: break;
                    case PropertyKey.SOUND_HOLD: break;

                    //ICE token
                    case PropertyKey.ICE_AUTH_TOKEN: break;
                }
            }
        }
        public void SetProperties(IDictionary<PropertyKey,string> properties)
        {
            if (null != properties && properties.Count > 0)
            {
                var errno = ErrorNumber.OK;
                foreach (var propertyKV in properties)
                {
                    log.Info(string.Format(string.Format("SetProperty:{0}={1}", propertyKV.Key, propertyKV.Value)));
                    _properties[propertyKV.Key] = propertyKV.Value;
                    if (propertyKV.Key <= PropertyKey.PLCM_MFW_KVLIST_KEY_MAXSYS)
                    {
                        errno = WrapperProxy.SetProperty(propertyKV.Key, propertyKV.Value);
                        if (errno != ErrorNumber.OK)
                        {
                            var errMsg = string.Format("{0}设定失败,err={1}", propertyKV.Key, errno);
                            log.Error(errMsg);
                            throw new Exception(errMsg);
                        }
                    }
                }
                /*
                errno = WrapperProxy.UpdateConfig();
                if (errno != ErrorNumber.OK)
                {
                    var errMsg = string.Format("更新配置失败,err={0}", errno);
                    log.Error(errMsg);
                    throw new Exception(errMsg);
                }
                */
            }
        }
        #endregion

        #region Get
        public IDictionary<PropertyKey,string> GetProerpties()
        {
            log.Info("GetProerpties");
            return _properties;
        }

        public string GetProperty(PropertyKey key)
        {
            log.Info(string.Format("GetProperty:{0}:{1}",key, _properties[key]));
            return _properties[key];
        }
        #endregion
    }
}
