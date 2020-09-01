using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# уровень 2. Создание игры
/// </summary>
namespace KulikLev2
{
	class Program
	{
		static void Main()
		{
			KulikForm frm = new KulikForm();
			frm.Width = 800;
			frm.Height = 600;
			KulikGame.Init(frm, 40, 5);
			frm.Show();
			KulikGame.Draw();
			Application.Run(frm);
		}
	}
}
