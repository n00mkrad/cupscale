using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    class ModelCombox : ComboBox
    {

        //bool initialized = false;

        public ModelCombox ()   // Constructor
        {
            base.Text = "Open the dropdown to select a model.";
        }

        /*
        protected override void OnVisibleChanged(EventArgs e)
        {
			
            if (!IsRunning())
                return;
            base.Text = "running";

            base.OnVisibleChanged(e);

            if (!initialized)
            {
            UIHelpers.FillModelComboBox(this, false);
            initialized = true;
            }
			
        }
        */

        protected override void OnDropDown(EventArgs e)
        {
            // if (!IsRunning())
            //    return;
            base.OnDropDown(e);
            Cupscale.UiHelpers.FillModelComboBox(this, false);
        }

        /*
        bool IsRunning()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        }
		*/
    }
}
