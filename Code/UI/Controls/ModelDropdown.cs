using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.UI.Controls
{
    class ModelDropdown : ComboBox
    {

        

        public ModelDropdown ()   // Constructor
        {
            // :thinking:
        }

        protected override void OnDropDown(EventArgs e)
        {
            // if (!IsRunning())
            //    return;
            base.OnDropDown(e);
            UIHelpers.FillModelComboBox(this, false);
        }
    }
}
