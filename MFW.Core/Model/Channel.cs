using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFW.Core
{
    public class Channel : BaseModel
    {
        #region Constructors
        public Channel(Call call)
        {
            this._call = call;

        }
        public Channel(Call call, int id, MediaType mediaType, bool isActive = false)
        {
            this._call = call;
            this.ChannelID = id;
            this._mediaType = mediaType;
            this.IsActive = isActive;
        }
        public Channel(Call call, int id, string name, MediaType mediaType, bool isActive = false)
        {
            this._call = call;
            this.ChannelID = id;
            this.ChannelName = name;
            this._mediaType = mediaType;
            this.IsActive = isActive;
        }
        #endregion

        #region Field
        private Call _call;
        public Call Call { get { return _call; } }
        #endregion

        #region ChannelID
        private int _channelID = 0;
        public int ChannelID
        {
            get { return _channelID; }
            set
            {
                _channelID = value;
                NotifyPropertyChanged("ChannelID");
            }
        }
        #endregion

        #region ChannelName
        private string _channelName;
        public string ChannelName
        {
            get { return _channelName; }
            set
            {
                if (_channelName != value)
                {
                    _channelName = value;
                    NotifyPropertyChanged("ChannelName");
                }
            }
        }
        #endregion

        #region IsActive
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
        }
        #endregion

        #region IsVideo
        private bool _isVideo;
        public bool IsVideo
        {
            get { return _isVideo; }
            set
            {
                if (_isVideo != value)
                {
                    _isVideo = value;
                    NotifyPropertyChanged("IsVideo");
                }
            }
        }
        #endregion

        #region IsAudio
        private bool _isAudio;
        public bool IsAudio
        {
            get { return _isAudio; }
            set
            {
                _isAudio = value;
                NotifyPropertyChanged("IsAudio");
            }
        }
        #endregion

        #region MediaType
        private MediaType _mediaType;
        public MediaType MediaType
        {
            get { return _mediaType; }
        }
        #endregion
        
        #region Size
        private Size _size = new Size(400, 300);
        public Size Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    IsVideo = true;
                    NotifyPropertyChanged("Size");
                }
            }
        }
        #endregion
    }
}
