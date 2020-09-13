using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.UI.Controls
{
    class ModelBox : ComboBox
    {
		
        //bool initialized = false;

        public ModelBox()   // Constructor
        {
            // :thinking:
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
            UIHelpers.FillModelComboBox(this, false);
        }

		/*
        bool IsRunning()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        }
		*/
    }
}
