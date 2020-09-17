using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
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

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C#, уровень 2, урок 5
/// </summary>

namespace KulikWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public static List<Department> departments = new List<Department>();
        //public static List<Employee> employees = new List<Employee>();
        //public Datas DB;

        ObservableCollection<Employee> employees;
        public Employee EmplProp { get; set; }
        public Department DepProp { get; set; }

        //EmplCollection empl;

        public MainWindow()
        {

            //            DB = new Datas();
            //empl = new EmplCollection();

            InitializeComponent();

            //MainWinGrid.DataContext = DB;
            // lstDep.DataContext = empl;
            //lstDep.ItemsSource = DB.departments;
            // lstEmp.ItemsSource = DB.employees;
            // lstEmp.ItemsSource = empl;

            employees = new ObservableCollection<Employee>()
            {
                new Employee("John Lennon"),
                new Employee("Paul McCartney"),
                new Employee("Mel Gibson"),
                new Employee("John Kennedy"),
                new Employee("Michael Jackson")
            };

            lstEmp.DataContext = employees;
            lstEmp.ItemsSource = employees;

        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEditDep_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void btnEditEmpl_Click(object sender, RoutedEventArgs e)
        {
            EmplProp = lstEmp.SelectedItem as Employee;
            if (EmplProp != null)
            {
                var frm = new WinEditEmpl(this);
                
                frm.ShowDialog();

                if (frm.DialogResult.Value)
                {
                    
                }
            }
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            var frm = new WinEditEmpl();

            frm.AddNewEmpl += MainAddNewEmployee;

            frm.ShowDialog();

            frm.AddNewEmpl -= MainAddNewEmployee;
        }

        private void MainAddNewEmployee(string EmployeeName)
        {
            Employee item = new Employee(EmployeeName);
            employees.Add(item);
        }
    }
}
