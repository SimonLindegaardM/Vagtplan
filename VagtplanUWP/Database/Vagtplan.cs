using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagtplanUWP.Database
{
    public class Vagtplan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int VagtID { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
