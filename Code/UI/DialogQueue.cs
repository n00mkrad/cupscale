using Cupscale.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.UI
{
    class DialogQueue
    {
        static bool running = false;
        public static Queue<MsgBox> queue = new Queue<MsgBox>(); 

        public static void Init ()
        {
            if(!running)
                ShowQueue();
        }

        static async Task ShowQueue ()
        {
            running = true;
            while (true)
            {
                if (queue.Count > 0)
                {
                    MsgBox currentDialog = queue.Peek();
                    //Logger.Log("Showing msg - " + )
                    Program.mainForm.Activate();
                    currentDialog.ShowDialog();
                    currentDialog.BringToFront();
                    await Task.Delay(100);
                }
                await Task.Delay(1);
            }
        }

        public static void CloseCurrent ()
        {
            if (queue.Count <= 0)
                return;
            MsgBox currentDialog = queue.Dequeue();
            currentDialog.Close();
        }

        public static void ShowDialog (MsgBox form)
        {
            queue.Enqueue(form);
        }

        public static bool IsOpen (MsgBox form)
        {
            return queue.Contains(form);
        }
    }
}
