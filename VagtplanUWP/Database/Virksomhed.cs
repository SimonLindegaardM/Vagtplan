using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagtplanUWP.Database
{
    public class Virksomhed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int VirksomhedsID { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int Nummber { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
