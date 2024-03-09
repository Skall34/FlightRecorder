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
            if (File.Exists("Flightrec.log"))
            {
                File.Move("Flightrec.log", "Flightrec.bak", true);
            }
            logger = new TextWriterTraceListener("Flightrec.log");
            Trace.Listeners.Add(logger);
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
