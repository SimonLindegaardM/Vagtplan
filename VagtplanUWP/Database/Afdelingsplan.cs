using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagtplanUWP.Database
{
    public class Afdelingsplan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int MedarbejderID { get; set; }
        public int VagtID { get; set; }
        public int VirksomhedsID { get; set; }
        public DateTime Dato { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Afdelingsplan()
        {

        }

    }
}
