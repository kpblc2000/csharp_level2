using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulikWPF
{
    class Datas
    {

        public static ObservableCollection<Department> departments = new ObservableCollection<Department>();
        public static ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public Datas()
        {
            departments.Add(new Department("Продажи"));
            departments.Add(new Department("Разработка"));
            departments.Add(new Department("Тестирование"));

            employees.Add(new Employee("John", "Lennon"));
            employees.Add(new Employee("Paul", "McCartney"));
            employees.Add(new Employee("Mel", "Gibson"));
            employees.Add(new Employee("John", "Kennedy"));
            employees.Add(new Employee("Michael", "Jackson"));

        }

    }
}
