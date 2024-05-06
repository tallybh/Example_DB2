using Model;
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
using ViewModel;

namespace Example_DB2
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void btnClick_Students(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new StudentListPage());
        }

        private void btnClick_Teachers(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new LecturerListPage());
        }
    }
}
