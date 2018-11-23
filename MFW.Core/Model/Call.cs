using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class Call : BaseModel
    {
        #region CallHandle
        private int _callHandle = -1;
        public int CallHandle
        {
            get { return _callHandle; }
            set
            {
                _callHandle = value;
                NotifyPropertyChanged("CallHandle");
            }
        }
        #endregion
        #region CallName
        private string _callName;
        public string CallName
        {
            get { return _callName; }
            set
            {
                _callName = value;
                NotifyPropertyChanged("CallName");
            }
        }
        #endregion

        #region CallState
        private CallState _callState;
        public CallState CallState
        {
            get { return _callState; }
            set
            {
                _callState = value;
                NotifyPropertyChanged("CallState");
            }
        }
        #endregion

        #region Reason
        private string _reason;
        public string Reason
        {
            get { return _reason; }
            set
            {
                _reason = value;
                NotifyPropertyChanged("Reason");
            }
        }
        #endregion
        #region NetworkIP
        private string _networkIP;
        public string NetworkIP
        {
            get { return _networkIP; }
            set
            {
                _networkIP = value;
                NotifyPropertyChanged("NetworkIP");
            }
        }
        #endregion
        #region IsAudioOnly
        private bool _isAudioOnly = false;
        public bool IsAudioOnly
        {
            get { return _isAudioOnly; }
            set
            {
                _isAudioOnly = value;
                NotifyPropertyChanged("IsAudioOnly");
            }
        }
        #endregion
        #region IsMute
        private bool _isMute;
        public bool IsMute
        {
            get { return _isMute; }
            set
            {
                _isMute = value;
                NotifyPropertyChanged("IsMute");
            }
        }
        #endregion    
        #region IsContentSupported
        private bool _isContentSupported = false;
        public bool IsContentSupported
        {
            get { return _isContentSupported; }
            set
            {
                _isContentSupported = value;
                NotifyPropertyChanged("IsContentSupported");
            }
        }
        #endregion

        #region CurrentChannel
        public Channel _currentChannel;
        public Channel CurrentChannel
        {
            get { return _currentChannel; }
            set
            {

                if (_currentChannel != value)
                {
                    if (null != _currentChannel)
                    {
                        _currentChannel.IsActive = false;
                    }
                    _currentChannel = value;
                    NotifyPropertyChanged("CurrentChannel");
                }
            }
        }
        #endregion
        #region Channels
        private ObservableCollection<Channel> _channels = new ObservableCollection<Channel>();
        public ObservableCollection<Channel> Channels { get { return _channels; } }

        public Channel GetChannel(int channelID)
        {
            return _channels.FirstOrDefault(c => c.ChannelID == channelID);
        }
        public void AddChannel(int channelID, MediaType mediaType)
        {
            if (null == GetChannel(channelID))
            {
                var isActive = channelID == ActiveSpeakerId;
                var channel = new Channel(this, channelID, mediaType, isActive);
                _channels.Add(channel);
                if (isActive)
                {
                    CurrentChannel = channel;
                }
            }
        }
        public void AddChannel(Channel channel)
        {
            if (null == GetChannel(channel.ChannelID))
            {
                var isActive = channel.IsActive;
                _channels.Add(channel);
                if (isActive)
                {
                    CurrentChannel = channel;
                }
            }
        }
        public void RemoveChannel(int channelID)
        {
            var channel = GetChannel(channelID);
            if (null != channel)
            {
                _channels.Remove(channel);
                if (CurrentChannel == channel)
                {
                    CurrentChannel = _channels.LastOrDefault();
                }
            }
        }
        public void ClearRemoteChannels()
        {
            var channels = _channels.Where(c => c.MediaType == MediaType.REMOTE).ToList();
            foreach (var c in channels)
            {
                _channels.Remove(c);
            }
            CurrentChannel = channels.FirstOrDefault();
        }
        public void SetChannelName(int channelID, string channelName)
        {
            var channel = GetChannel(channelID);
            if (null != channel)
            {
                channel.ChannelName = channelName;
            }
        }

        #endregion
        #region ChannelNumber
        private int _channelNumber;
        public int ChannelNumber
        {
            get { return _channelNumber; }
            set
            {
                _channelNumber = value;
                NotifyPropertyChanged("ChannelNumber");
            }
        }
        #endregion
        #region ActiveSpeakerId
        private int _activeSpeakerId = 0;
        public int ActiveSpeakerId
        {
            get { return _activeSpeakerId; }
            set
            {
                _activeSpeakerId = value;
                var channel = GetChannel(_activeSpeakerId);
                if (null != channel)
                {
                    channel.IsActive = true;
                    CurrentChannel = channel;
                    NotifyPropertyChanged("ActiveSpeakerId");
                }
            }
        }
        #endregion
        
        #region CallMode
        private CallMode _callMode;
        public CallMode CallMode
        {
            get { return _callMode; }
            set
            {
                _callMode = value;
                NotifyPropertyChanged("CallMode");
            }
        }
        #endregion

        #region IsCurrent
        private bool _isCurrent;
        public bool IsCurrent
        {
            get { return _isCurrent; }
            set
            {
                _isCurrent = value;
                NotifyPropertyChanged("IsCurrent");
            }
        }
        #endregion

        private RecordAudioStreamCallback _recordAudioStreamCallback = null;
        #region Constructors
        public Call(int callHandle)
        {
            this.CallHandle = callHandle;
        }
        #endregion
    }
}
