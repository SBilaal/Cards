using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Numify
{
    class Detect: INotifyPropertyChanged
    {
        
        public string Provider { get; set; }
        
        private string provider;
        
        public Detect()
        {
            UpdateProvider();
        }

        
        List<string> NetworkNo = new List<string>()
        {
            "0803","0806","0703","0706","0813","0816","0810","0814","0903","0805",
            "0807","0705","0815","0811","0905","0802","0808","0708","0812","0701",
            "0902","0809","0818","0817","0909"
        };

        List<string> NetworkNa = new List<string>()
        {
            "MTN","MTN","MTN","MTN","MTN","MTN","MTN","MTN","MTN","GLO","GLO","GLO",
            "GLO","GLO","GLO","Airtel","Airtel","Airtel","Airtel","Airtel","Airtel",
            "Etisalat","Etisalat","Etisalat","Etisalat"
        };

        public void DetectNumber(string number)
        {
            
            string splicedNumber;
            if(number != "")
            {
                splicedNumber = number.Substring(0,4);
                for(int i = 0; i < NetworkNa.Count; i++)
                {
                    if(splicedNumber == NetworkNo[i])
                    {
                        provider = NetworkNa[i];
                    }
                }
            }
            else
            {
                provider = "Enter a number";
            }
        }

        public void UpdateProvider()
        {
            Provider = provider;
            OnPropertyChanged("Provider");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if(propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
