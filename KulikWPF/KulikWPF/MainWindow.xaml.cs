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
        public ObservableCollection<Department> departments;
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

            departments = new ObservableCollection<Department>()
            {
                new Department("Тестирование"),
                new Department("Разработка"),
                new Department("Документирование")
            };

            lstDep.ItemsSource = departments;

        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            DepProp = null;
            var frm = new WinEditDepart(this);
            frm.EventNewEditDepart += MainAddNewDepart;
            frm.ShowDialog();
        }

        private void MainAddNewDepart(string DepartmentName)
        {
            departments.Add(new Department(DepartmentName));
        }

        private void btnEditDep_Click(object sender, RoutedEventArgs e)
        {
            if (lstDep.SelectedIndex >= 0)
            {
                DepProp = departments[lstDep.SelectedIndex];
                var frm = new WinEditDepart(this);
                frm.EventNewEditDepart += MainEditDeparts;
                frm.ShowDialog();
            }
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            EmplProp = null;
            var frm = new WinEditEmpl(this);

            frm.EventAddNewEmpl += MainAddNewEmployee;

            frm.ShowDialog();

        }

        private void btnEditEmpl_Click(object sender, RoutedEventArgs e)
        {
            EmplProp = lstEmp.SelectedItem as Employee;
            if (EmplProp != null)
            {
                var frm = new WinEditEmpl(this);
                frm.EventAddNewEmpl += MainEditEmployee;
                frm.ShowDialog();
            }
        }

        private void MainEditDeparts(string DepartmentName)
        {
            DepProp.DepartName = DepartmentName;
        }

        private void MainEditEmployee(string EmployeeName, int SelectedDepartment)
        {
            if (SelectedDepartment >= 0)
            {
                EmplProp.DepName = departments[SelectedDepartment];
            }
        }

        private void MainAddNewEmployee(string EmployeeName, int SelDepartIndex)
        {
            Employee item = new Employee(EmployeeName);
            if (SelDepartIndex >= 0)
            {
                item.DepName = departments[SelDepartIndex];
            }
            employees.Add(item);
        }
    }
}
