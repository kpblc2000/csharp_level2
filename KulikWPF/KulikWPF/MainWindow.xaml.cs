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

        public static List<Department> departments = new List<Department>();
        public static List<Employee> employees = new List<Employee>();


        public MainWindow()
        {
            InitializeComponent();

            departments.Add(new Department("Продажи"));
            departments.Add(new Department("Разработка"));
            departments.Add(new Department("Тестирование"));

            lstDepart.ItemsSource = departments;
            lstDepart.SelectedIndex = 0;

            employees.Add(new Employee("John", "Lennon"));
            employees.Add(new Employee("Paul", "McCartney"));
            employees.Add(new Employee("Mel", "Gibson"));
            employees.Add(new Employee("John", "Kennedy"));
            employees.Add(new Employee("Michael", "Jackson"));

            lstEmployee.ItemsSource = employees;

            bAddEditDep.Click += delegate { Department.AddEdit(); };
            bAddEditEmployee.Click += delegate { Employee.AddEdit(); };
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
