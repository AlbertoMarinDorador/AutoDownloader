using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * 
     */
    class ThreadManager
    {
        private static Interface viewInstance;
        private volatile static bool stopThread;

        /*
         * 
         */
        public void SetViewInstance(Interface value)
        {
            viewInstance = value;
        }

        /*
         * 
         */
        public void SetStopThread(bool value)
        {
            stopThread = value;
            Console.WriteLine("En el Stop: " + stopThread);
        }

        /*
         * 
         */
        public bool GetStopThread()
        {
            Console.WriteLine("En 'GetStopThread': " + stopThread);
            return stopThread;
        }

        /*
         * 
         */
        public void SendFeedbackToView(string feedback)
        {
            viewInstance.MostrarFeedback(feedback);
        }

        /*
         * 
         */
        public void CreateSleepToTargetThread()
        {
            SleepToTarget Temp = new SleepToTarget(DateTime.Now.AddSeconds(10), LastActionOfThread);
            System.Threading.Thread threadScheludedTime = new System.Threading.Thread(() => DoWork(Temp));
            threadScheludedTime.Start();
        }

        /*
         * 
         */
        private void DoWork(SleepToTarget Temp)
        {
            Console.WriteLine("Al principio del thread: " );            
            Temp.Start(this);
        }

        /*
         * 
         */
        private static void LastActionOfThread()
        {
            stopThread = false;
            Console.WriteLine("Al final del thread: ");
        }
    }
}
