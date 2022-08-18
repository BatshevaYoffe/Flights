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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for DatesAndFlightsWindow.xaml
    /// </summary>
    public partial class DatesAndFlightsWindow : Window
    {
        VM.SelectDatesVM vm { get; set; }
        public DatesAndFlightsWindow()
        {
            InitializeComponent();
            vm = new VM.SelectDatesVM();
            this.DataContext = vm;
        }

        private void selectedDates(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
