using System;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace ExpoZebra
{
    public class ExpoZebra : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        /**
         * Variable for the device id, as well as the object used to 
         * get the variable value and set/update it
         */
        private String device_id = "";
        public String DeviceId
        {
            get 
            { 
                return device_id; 
            }
            set
            {
                if (device_id != value)
                {
                    device_id = value;
                    NotifyPropertyChanged("DeviceId");
                }
            }
        }

        private String token = "";
        public String Token
        {
            get
            {
                return token;
            }
            set
            {
                if(token != value)
                {
                    token = value;
                    NotifyPropertyChanged("Token");
                }
            }
        }

        private String badge_id = "";
        public String BadgeId
        {
            get
            {
                return badge_id;
            }
            set
            {
                if(badge_id != value)
                {
                    badge_id = value;
                    NotifyPropertyChanged("BadgeId");
                }
            }
        }

        private String api_response = "";
        public String ApiResponse
        {
            get
            {
                return api_response;
            }
            set
            {
                if(api_response != value)
                {
                    api_response = value;
                    NotifyPropertyChanged("ApiResponse");
                }
            }
        }

        public event EventHandler RequestComplete;
        public void DoGetRequest()
        {
            // https://ws.expoleads.net/scan?device_id=95BBF370ED1A80B193AF522C556C752B&token=E0591C28-ECCC-47F2-841A-025181DBED58&scanCode=59278445
            String uri = "https://ws.expoleads.net/scan?deviceId=" + device_id + "&token=" + token + "&scanCode=" + badge_id;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var expoleadsApiResponse = QuickType.ExpoleadsApiResponse.FromJson(reader.ReadToEnd());
                ApiResponse = expoleadsApiResponse.Data.Attendee.NameFirst;
                RequestComplete(this, null);
            }
        }
    }
}