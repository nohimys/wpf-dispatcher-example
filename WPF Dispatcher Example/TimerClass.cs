using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace WPF_Dispatcher_Example
{
    /// <summary>
    /// This class is to represent the different thread
    /// </summary>
    class TimerClass
    {
        private Timer _timer;
        private int _timerCount;

        private TimerClassCallbacks _timerClassCallbacks;

        public TimerClass(TimerClassCallbacks timerClassCallbacks)
        {
            this._timerClassCallbacks = timerClassCallbacks;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;

            _timer.Start();
        }

        
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //This is the representation for callbacks from a different Thread to modify UI elements

            //Incase you're testing 1.1, 1.2 or 1.3, uncomment this line only
            //For testing 2.1,2.2 or 2.3 this has to be commented
            //this._timerClassCallbacks.OnTick(_timerCount++);


            #region 2.1 Approach

            //2.1
            //Calling the Dispatcher Synchronously by getting the current Dispatcher from Application
            //Doesn't required to have access to the UI element to get the Dispatcher
            //Application.Current.Dispatcher.Invoke((Action)(() =>
            //{
            //    this._timerClassCallbacks.OnTick(_timerCount++);
            //}));
            #endregion

            #region 2.2 Approach

            //2.2
            //Calling the Dispatcher ASynchronously by getting the current Dispatcher from Application
            //Doesn't required to have access to the UI element to get the Dispatcher
            //Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    this._timerClassCallbacks.OnTick(_timerCount++);
            //}));
            #endregion

            #region 2.3 Approach

            //2.3
            //Calling the Dispatcher ASynchronously by getting the current Dispatcher from Application
            //If the user is unsure whether the executing thread has the access to modify UI elements,
            //first check it using CheckAccess() method  
            //if (!Application.Current.Dispatcher.CheckAccess())
            //{
            //    //If the executing thread doesn't have permission, go through the Dispatcher
            //    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        this._timerClassCallbacks.OnTick(_timerCount++);
            //    }));
            //}
            //else
            //{
            //    //If the executing thread has the permission, do it directly
            //    this._timerClassCallbacks.OnTick(_timerCount++);
            //}
            #endregion
        }

        /// <summary>
        /// This interface is implemented to MainWindow and used to access it's UI elements
        /// </summary>
        public interface TimerClassCallbacks
        {
            /// <summary>
            /// This method will be called in every tick of the timer
            /// </summary>
            /// <param name="count">incrimenting count</param>
            void OnTick(int count);
        }
    }
}
