using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace autodownloader
{
    class SleepToTarget
    {
        private DateTime TargetTime;
        private Action MyAction;
        private const int MinSleepMilliseconds = 250;

        public SleepToTarget(DateTime TargetTime,Action MyAction)
        {
            this.TargetTime = TargetTime;
            this.MyAction = MyAction;
        }

        public void Start(ThreadManager manager)
        {
                //new Thread(new ThreadStart(ProcessTimer)).Start();
                //ProcessTimer();

                //paco = new System.Threading.Thread(() => ProcessTimer());
                //threadDownloadRoute.Start();

                DateTime Now = DateTime.Now;

                while (Now < TargetTime & manager.GetStopThread() == false)
                {
                    int SleepMilliseconds = (int)Math.Round((TargetTime - Now).TotalMilliseconds / 2);
                    Console.WriteLine("Time to sleep until wake up: " + SleepMilliseconds + ", Wake up at: " + TargetTime);
                    manager.SendFeedbackToView("Time to sleep until wake up: " + SleepMilliseconds + ", Wake up at: " + TargetTime);
                    Thread.Sleep(SleepMilliseconds > MinSleepMilliseconds ? SleepMilliseconds : MinSleepMilliseconds);
                    Now = DateTime.Now;

                    // Compruebo si se ha solicitado el stop desde la vista
                    //if (DealWithThreads.CloseThisThread(view, null)) return;
                }

                /*
                    lblProcent.SafeInvoke(d => d.Text = "Written by the background thread");
                    progressBar1.SafeInvoke(d => d.Value = i);

                    //or call a methode thread safe. That method is executed on the same thread as the form
                    this.SafeInvoke(d => d.UpdateFormItems("test1", "test2"));
                 */
        }

        private void ProcessTimer( )
        {
            DateTime Now = DateTime.Now;

            while (Now < TargetTime)
            {
                int SleepMilliseconds = (int) Math.Round((TargetTime - Now).TotalMilliseconds / 2);
                Console.WriteLine("Time to sleep until wake up: " + SleepMilliseconds + ", Wake up at: " + TargetTime);
                Thread.Sleep(SleepMilliseconds > MinSleepMilliseconds ? SleepMilliseconds : MinSleepMilliseconds);
                Now = DateTime.Now;
                // Compruebo si se ha solicitado el stop desde la vista
                //if (DealWithThreads.CloseThisThread(view, null)) return;
            }

            MyAction();
        }


    }
}


/*  ESTE ES EL ORIGINAL, ANTES DE QUE YO LO MUTILARA
 * https://stackoverflow.com/questions/1493203/alarm-clock-application-in-net
 * 
 * 
 class Program
{
    static void Main(string[] args)
    {
        SleepToTarget Temp = new SleepToTarget(DateTime.Now.AddSeconds(30),Done);
        Temp.Start();
        Console.ReadLine();
    }

    static void Done()
    {
        Console.WriteLine("Done");
    }
}

class SleepToTarget
{
    private DateTime TargetTime;
    private Action MyAction;
    private const int MinSleepMilliseconds = 250;

    public SleepToTarget(DateTime TargetTime,Action MyAction)
    {
        this.TargetTime = TargetTime;
        this.MyAction = MyAction;
    }

    public void Start()
    {
        new Thread(new ThreadStart(ProcessTimer)).Start();
    }

    private void ProcessTimer()
    {
        DateTime Now = DateTime.Now;

        while (Now < TargetTime)
        {
            int SleepMilliseconds = (int) Math.Round((TargetTime - Now).TotalMilliseconds / 2);
            Console.WriteLine(SleepMilliseconds);
            Thread.Sleep(SleepMilliseconds > MinSleepMilliseconds ? SleepMilliseconds : MinSleepMilliseconds);
            Now = DateTime.Now;
        }

        MyAction();
    }
} 
 */

