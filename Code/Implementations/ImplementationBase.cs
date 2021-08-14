using Cupscale.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Implementations
{
    public abstract class ImplementationBase
    {
        public static bool CheckIfExeExists (Implementation implementation, string exeName)
        {
            if (!File.Exists(Path.Combine(Paths.binPath, implementation.dir, exeName)))
            {
                Program.ShowMessage($"Error: The executable is missing:\n\n{exeName}\n\nPossibly your installation is incomplete?", "Error");
                return false;
            }

            return true;
        }
    }
}
