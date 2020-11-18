using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagtplanUWP.Database
{
    public class Medarbejdersplan : INotifyPropertyChanged
    {
        public int MedarbejderID { get; set; }
        public string MedarbejderNavn { get; set; }
        public string Adresse { get; set; }
        public int Nummer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
