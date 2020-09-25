using Cupscale.IO;
using Cupscale.Main;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupscale.Cupscale
{
    class PostProcessingQueue
    {
        public static Queue<string> outputFileQueue = new Queue<string>();
        public static List<string> processedFiles = new List<string>();
        public static List<string> outputFiles = new List<string>();

        public static bool run;
        public static string currentOutPath;

        public static void Start (string outpath)
        {
            run = true;
            currentOutPath = outpath;
            outputFileQueue.Clear();
            processedFiles.Clear();
            outputFiles.Clear();
        }

        public static void Stop ()
        {
            run = false;
        }

        public static async Task Update ()
        {
            while (run || IOUtils.GetCompatibleFiles(Paths.imgOutPath, true).Length > 0)
            {
                string[] outFiles = Directory.GetFiles(Paths.imgOutPath, "*.tmp", SearchOption.AllDirectories); // IOUtils.Get(Paths.imgOutPath, true);
                Logger.Log("Queue Update() - " + outFiles.Length + " files in out folder");
                foreach (string file in outFiles)
                {
                    if (!outputFileQueue.Contains(file) && !processedFiles.Contains(file) && !outputFiles.Contains(file))
                    {
                        processedFiles.Add(file);
                        outputFileQueue.Enqueue(file);
                        Logger.Log("[Queue] Enqueued " + Path.GetFileName(file));
                    }
                    else
                    {
                        Logger.Log("Skipped " + file + " - Is In Queue: " + outputFileQueue.Contains(file) + " - Is Processed: " + processedFiles.Contains(file) + " - Is Outfile: " + outputFiles.Contains(file));
                    }
                }
                await Task.Delay(1000);
            }
        }

        public static string lastOutfile;

        public static async Task ProcessQueue ()
        {
            Stopwatch sw = new Stopwatch();
            while (run || IOUtils.GetCompatibleFiles(Paths.imgOutPath, true).Length > 0)
            {
                if (outputFileQueue.Count > 0)
                {
                    string file = outputFileQueue.Dequeue();
                    Logger.Log("[Queue] Post-Processing " + Path.GetFileName(file));
                    sw.Restart();
                    await Upscale.PostprocessingSingle(file, true);
                    Logger.Log("changing outfilename (not)");
                    string outFilename = Upscale.FilenamePostprocessingSingle(lastOutfile);
                    outputFiles.Add(outFilename);
                    Logger.Log("[Queue] Done Post-Processing " + Path.GetFileName(file) + " in " + sw.ElapsedMilliseconds + "ms");

                    if(Upscale.overwriteMode == Upscale.Overwrite.Yes)
                    {
                        string suffixToRemove = "-" + Program.lastModelName.Replace(":", ".").Replace(">>", "+");
                        Logger.Log("[Remove Suffix] Copying " + outFilename + " to " + Path.Combine(currentOutPath, Path.GetFileName(outFilename).Replace(suffixToRemove, "")));
                        File.Copy(outFilename, Path.Combine(currentOutPath, Path.GetFileName(outFilename).Replace(suffixToRemove, "")), true);
                        File.Delete(outFilename);
                    }
                    else
                    {
                        Logger.Log("[Keep Suffix] Copying " + outFilename + " to " + Path.GetFileName(outFilename));
                        File.Copy(outFilename, Path.Combine(currentOutPath, Path.GetFileName(outFilename)), true);
                        File.Delete(outFilename);
                    }
                    BatchUpscaleUI.upscaledImages++;
                }
                await Task.Delay(250);
            }
        }
    }
}
