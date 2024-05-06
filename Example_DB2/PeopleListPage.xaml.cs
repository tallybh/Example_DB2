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

namespace Example_DB2
{
    /// <summary>
    /// Interaction logic for PeopleListPage.xaml
    /// </summary>
    public abstract partial class PeopleListPage : Page
    {

        private List<People> lst;
        protected abstract List<People> GetList();


        public PeopleListPage()
        {
            InitializeComponent();
            lst = this.GetList();
            this.lstView.ItemsSource = lst;
        }

        private void RefreshUserList()
        {
            this.lstView.ItemsSource = null;
            this.lstView.ItemsSource = lst;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
