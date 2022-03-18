using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

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
    }
}