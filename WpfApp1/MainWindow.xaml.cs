using ScottPlot.AxisPanels;
using ScottPlot.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.cs;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private TimerA timerA;
        readonly ScottPlot.Plottables.DataLogger Logger1;
        private bool stoped;
        // ScottPlot.DataGenerators.RandomWalker Walker1 = new(0, multiplier: 0.01);
        public MainWindow()
        {
           

            InitializeComponent();
            stoped=false;
            timerA = new TimerA();
            this.DataContext = timerA; //设置之后绑定才会有效

            //double[] dataX = { 1, 2, 3, 4, 5 };
            //double[] dataY = { 1, 4, 9, 16, 25 };
            //WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            //WpfPlot1.Refresh();


            timerA.PropertyChanged += timerAPropertyChanged;

            WpfPlot1.Interaction.Disable();
            Logger1 = WpfPlot1.Plot.Add.DataLogger();

            RightAxis axis1 = (RightAxis)WpfPlot1.Plot.Axes.Right;
            Logger1.Axes.YAxis = axis1;
            axis1.Color(Logger1.Color);


        }
        void timerAPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!stoped&&e.PropertyName == "Points")
            {
                Logger1.Add(timerA.Points.X, timerA.Points.Y);
                WpfPlot1.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stoped=true;
            timerA.PropertyChanged -= timerAPropertyChanged;//取消事件触发

            DataLoggerSource a = new DataLoggerSource();
            a = Logger1.Data;
            List<Double> B = new List<Double>();
            List<Double> C = new List<Double>();
            foreach (var item in a.Coordinates) {
                B.Add(item.X);
                C.Add(item.Y);
            }
            WpfPlot1.Plot.Clear();
            WpfPlot1.Interaction.Enable();
            WpfPlot1.Plot.Add.Scatter(B, C);
            WpfPlot1.Refresh();
        }
    }
}