//version 0.0.1

using System.Diagnostics;

namespace BenchTimer;

    public class BenchTimer
    {
        private enum OutFormat
        {
            MILLIS, 
            SECONDS, 
            NANOS, 
            NANOYEAR
        }
        
        private enum WorkMode
        {
            DEBUG, 
            RELEASE
        }
        
        private enum LogIn //if change this enum - change destructor to save result
        {
            FILE,
            CONSOLE //add custom output stream
        }
        
        //todo: add logger ang abstract method .log
        //todo: add method to out time in current type

        private static uint id = 0;
        private uint _id;
        
        private OutFormat _cuurentType = OutFormat.MILLIS;
        private WorkMode _currentMode = WorkMode.DEBUG;
        private LogIn _log = LogIn.CONSOLE; 
        private Stopwatch _time = new Stopwatch();

        private String _elapsedFormat = new String("{0:00}:{1:00}:{2:00}.{3:00}");

        //private FileStream logFile;
        
        
        
        
        public BenchTimer()
        {
            this._id = id;
            id++;
            _time.Start();
        }

        public long elapsedAsLong()
        {
            return _time.ElapsedMilliseconds;
        }

        public String elapsedAsString()
        {
            TimeSpan ts = _time.Elapsed;
            return String.Format(_elapsedFormat, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }

        public void stop()
        {
            _time.Stop();
            switch (_log)
            {
                case LogIn.CONSOLE:
                    Console.WriteLine(elapsedAsLong());
                    break;
                case LogIn.FILE:
                    break;
            }
        }
    }