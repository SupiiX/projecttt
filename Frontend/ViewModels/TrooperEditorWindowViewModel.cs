using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Actual { get; set; }
        public void Setup(Trooper actual)
        {
            Actual = actual;
        }
        public TrooperEditorWindowViewModel()
        {

        }

    }
}
