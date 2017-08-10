using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Dispatcher_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, TimerClass.TimerClassCallbacks
    {
        private TimerClass _timerClass;

        public MainWindow()
        {
            InitializeComponent();
            
            _timerClass = new TimerClass(this);
        }

        /// <summary>
        /// Representing the UI element modification
        /// </summary>
        /// <param name="count"></param>
        private void updateUIElement(int count)
        {
            labelTimerValue.Content = count;
        }

        public void OnTick(int count)
        {
            //Incase you're testing 2.1, 2.2 or 2.3, uncomment this line only
            //For testing 1.1,1.2 or 1.3 this has to be commented
            //this.updateUIElement(count);

            #region 1.1 Approach

            //1.1
            //Calling the Dispatcher Synchronously through the Dispatcher of the UI element
            //Dispatcher.Invoke((Action)(() =>
            //{
            //    this.updateUIElement(count);
            //}));
            #endregion

            #region 1.2 Approach

            //1.2
            //Calling the Dispatcher ASynchronously through the Dispatcher of the UI element
            //Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    this.updateUIElement(count);
            //}));
            #endregion

            #region 1.3 Approach

            //1.3
            //Calling the Dispatcher through the Dispatcher of the UI element
            //If the user is unsure whether the executing thread has the access to modify UI elements,
            //first check it using CheckAccess() method            
            //if (!Dispatcher.CheckAccess())
            //{
            //    //If the executing thread doesn't have permission, go through the Dispatcher
            //    Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        this.updateUIElement(count);
            //    }));
            //}
            //else
            //{
            //    //If the executing thread has the permission, do it directly
            //    this.updateUIElement(count);
            //}
            #endregion
        }
    }
}
