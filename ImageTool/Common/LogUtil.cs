using System;
using System.IO;

namespace Common.Logging
{
    public delegate void OnPrintLine(string line);
    class LogPrintStream : StreamWriter
    {
        public OnPrintLine OnPrinted;
        private string LogFile = null;

        public LogPrintStream(string log_txt) : base(log_txt == null ? new MemoryStream(): (Stream)File.Open(log_txt, FileMode.Create))
        {
            LogFile = log_txt;
        }

        public override void Write(string value)
        {
            base.Write(value);
            OnPrinted?.Invoke(value);
        }

        public override void WriteLine(string value)
        {
            base.WriteLine(value);
            OnPrinted?.Invoke(value+"\r\n");
        }

        public void SmartFlush()
        {
            base.Close();
            if(LogFile != null && new FileInfo(LogFile).Length ==0)
            {
                File.Delete(LogFile);
            }
        }
    }
    public interface ILogger
    {
        void PrintLine(LogLevel priority, string tag, string msg, Exception e = null);
    }
    public enum LogLevel:byte
    {
        NULL = 0,
        /**
        * Priority constant for the PrintLine method, use Log.v.
        */
        VERBOSE = 1,

        /**
         * Priority constant for the PrintLine method, use Log.d.
         */
        DEBUG = 2,

        /**
         * Priority constant for the PrintLine method, use Log.i.
         */
        INFO = 3,

        /**
         * Priority constant for the PrintLine method, use Log.w.
         */
        WARN = 4,

        /**
         * Priority constant for the PrintLine method, use Log.e.
         */
        ERROR = 5,

        /**
         * Priority constant for the PrintLine method.
         * Priority constant for the PrintLine method.
         */
        ASSERT = 6,
    }
    public class Slog : ILogger
    {
        public static LogLevel Level = LogLevel.WARN;
        private static LogPrintStream LastLogPrintStream = null;
        public static void Setup(OnPrintLine listener, LogLevel logLevel = LogLevel.WARN, string logfile = null)
        {
            string dir = Path.GetDirectoryName(logfile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var logger = new LogPrintStream(logfile);
            logger.OnPrinted = listener;
            LastLogPrintStream = logger;
            Level = logLevel;
            Console.SetOut(logger);
        }

        public static void Flush()
        {
            if(LastLogPrintStream != null)
            {
                LastLogPrintStream.SmartFlush();
            }
        }

        private static ILogger Logger = new Slog();


        public static void setLogger(ILogger logger)
        {
            Logger = logger;
        }

        private static string ToLine(string format, object[] args)
        {
            if(args.Length == 0)
            {
                return format;
            }
            return string.Format(format, args);
        }

        public static void v(string tag, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.VERBOSE, tag,ToLine(msg, args));
        }

        public static void d(string tag, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.DEBUG, tag,ToLine(msg, args));
        }

        public static void i(string tag, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.INFO, tag,ToLine(msg, args));
        }

        public static void w(string tag, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.WARN, tag,ToLine(msg, args));
        }

        public static void e(string tag, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.ERROR, tag,ToLine(msg, args));
        }

        public static void w2(string tag, Exception e, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.WARN, tag,ToLine(msg, args), e);
        }

        public static void e2(string tag, Exception e, string msg, params object[] args)
        {
            Logger.PrintLine(LogLevel.ERROR, tag,ToLine(msg, args), e);
        }

        public void PrintLine(LogLevel priority, string tag, string msg, Exception e = null)
        {
            if((int)priority < (int)Level)
            {
                return;
            }
            if (e != null)
            {
                msg += "\n" + e.Message;
                msg += "\n" + e.StackTrace;
            }
            Console.WriteLine(priority + " " + tag + ": " + msg);
        }
    }
}
