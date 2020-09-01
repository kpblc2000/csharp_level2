using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Алексей Кули kpblc2000@yandex.ru
/// C#, уровень 2. Задача 1
/// Построить три класса (базовый и 2 потомка), описывающих работников с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок):
/// а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
/// Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; 
/// для  работников  с  фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
/// б) Создать на базе абстрактного класса массив сотрудников и заполнить его
/// </summary>
namespace Lesson2Task1
{

	abstract class Employee
	{
		public abstract string Name { get; set; }
		public Employee(string Name)
		{
			this.Name = Name;
		}
		public abstract double Monthly();
	}

	class EmployeeFixedPayment : Employee
	{
		public override string Name { get; set; }
		public double Payment { get; set; }
		public EmployeeFixedPayment(string Name, double Payment) : base(Name)
		{
			this.Payment = Payment;
		}
		public override double Monthly()
		{
			return Payment;
		}
	}

	class EmployeeTimePayment : Employee
	{
		public override string Name { get; set; }
		public double Payment { get; set; }
		public EmployeeTimePayment(string Name, double Payment) : base(Name)
		{
			this.Payment = Payment;
		}
		public override double Monthly()
		{
			return Payment * 20.8 * 8;
		}
	}
	//class Employee
	//{
	//	private string _firstName;
	//	private string _lastName;
	//	private int _birthYear;

	//	protected Employee(string FirstName, string LastName, int BirthYear)
	//	{
	//		_firstName = FirstName;
	//		_lastName = LastName;
	//		_birthYear = BirthYear;
	//	}

	//	public string Name { get { return _lastName + " " + _firstName; } }
	//	public int Age { get { return DateTime.Now.Year - _birthYear; } }
	//	public int BirthYear { get { return _birthYear; } }
	//}

	//class FixedPayment : Employee
	//{

	//	public double Payment { get; set; }

	//	public FixedPayment(string FirstName, string LastName, int BirthYear) : base (FirstName, LastName, BirthYear)
	//	{
	//		Payment = 0.0;
	//	}

	//}

	class Program
	{
		static void Main()
		{
			Employee man = new EmployeeFixedPayment("Фиксированный", 2000);
			Console.WriteLine($"{man.Name} -> {man.Monthly()}");
			man = new EmployeeTimePayment("Повременно", 10);
			Console.WriteLine($"{man.Name} -> {man.Monthly()}");

			Console.WriteLine("Работа с массивом работников:");

			Employee[] employees = new Employee[]
			{
				new EmployeeFixedPayment("Фикс1", 6000),
				new EmployeeFixedPayment("Фикс2", 3000),
				new EmployeeTimePayment("Врем1", 12),
				new EmployeeTimePayment("Врем2", 13)
			};

			foreach (Employee item in employees)
			{
				Console.WriteLine($"{item.Name} -> {item.Monthly()}");
			}

			Console.WriteLine("\n***\nНажмите любую клавишу");
			Console.ReadKey();
		}
	}
}
