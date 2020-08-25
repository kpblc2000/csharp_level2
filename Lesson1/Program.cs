using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KulikLev2
{
	class Program
	{
		static void Main()
		{
			KulikForm frm = new KulikForm();
			frm.Width = 800;
			frm.Height = 600;
			KulikGame.Init(frm);
			frm.Show();
			KulikGame.Draw();
			Application.Run(frm);
		}
	}
}
