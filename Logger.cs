using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecorder
{

    internal class Logger
    {
        static TraceListener logger;

        const string logFileName = "FlightRecorder";

        static string GetCallingMethodName()
        {
            try
            {
                // Get the StackTrace
                StackTrace stackTrace = new StackTrace(true);
                // Get the calling method
                StackFrame frame = stackTrace.GetFrame(2);
                MethodBase method = frame.GetMethod();
                int lineNumber = frame.GetFileLineNumber();
                string fileName = Path.GetFileName(frame.GetFileName());
                // Return the name of the calling method
                return (method.Name +" in "+ fileName + ":" + lineNumber);
            }catch(Exception e)
            {
                Trace.WriteLine("Error while getting func infos"+e.Message);
            }
            return "<unknown func>";
        }

        public static void init()
        {
            // Get the application name
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            // Get the path to the user's AppData folder
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the AppData path with the folder name
            string fullPath = Path.Combine(appDataPath, appName);

            // Ensure the directory exists, if not, create it
            Directory.CreateDirectory(fullPath);

            string logFile = Path.Combine(fullPath, logFileName);

            if (File.Exists(logFile+".log"))
            {
                File.Move(logFile + ".log", logFile + ".bak", true);
            }
            logger = new TextWriterTraceListener(logFile + ".log");
            Trace.Listeners.Add(logger);
            Trace.AutoFlush = true;
        }

        public static void Dispose()
        {
            logger.Flush();
            logger.Close();
            Trace.Listeners.Remove(logger);
        }

        public static void WriteLine(string message) {
            string callingFunc = GetCallingMethodName();
            Trace.WriteLine(DateTime.Now.ToLongTimeString()+ " : " + callingFunc + " : " + message);
        }
    }
}
