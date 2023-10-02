using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_dataMVP
{
    public interface IView
    {
        string name { get; set; }

        string age { get; set; }

        string keyWord { get; set; }



        event EventHandler<EventArgs> SaveDataEvent;
    }
}
