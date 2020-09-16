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

namespace KulikWPF
{
    /// <summary>
    /// Логика взаимодействия для WinEditEmpl.xaml
    /// </summary>
    public partial class WinEditEmpl : Window
    {

        private bool isAdd;
        private Employee dataSource;
        private MainWindow mainWin;

        public WinEditEmpl()
        {
            InitializeComponent();
            //btnOk.Click += delegate { this.DialogResult = true; };
            //btnCancel.Click += delegate { this.DialogResult = false; };
        }

        public WinEditEmpl(Employee e) : this()
        {
            dataSource = e;
            MainGrid.DataContext = dataSource;
        }

        public WinEditEmpl(MainWindow w):this()
        {
            dataSource = w.EmplProp;
            MainGrid.DataContext = dataSource;
        }

        public WinEditEmpl(MainWindow w, bool AddMode):this()
        {
            isAdd = true;
            dataSource  = new Employee("");
            mainWin = w;
            MainGrid.DataContext = dataSource;
            
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                mainWin.EmplProp = dataSource;
            }
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
