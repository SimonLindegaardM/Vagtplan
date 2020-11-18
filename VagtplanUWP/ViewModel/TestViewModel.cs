using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VagtplanUWP.Database;
using System.Text;
using System.Threading.Tasks;

namespace VagtplanUWP.ViewModel
{
    public class TestViewModel
    {

        public ObservableCollection<Afdelingsplan> kage { get; set; }
        public ObservableCollection<Medarbejdersplan> kage2 { get; set; }
        
        public TestViewModel()
        {
            kage = DataHelper.GetAfdelingsplan();
            kage2 = DataHelper.GetMedarbejdersplan();
        }

    }
}
