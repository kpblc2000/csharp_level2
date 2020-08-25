using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KulikLev2
{
	static class KulikGame
	{
		private static BufferedGraphicsContext _context;
		public static BufferedGraphics Buffer;
		public static CBaseObject[] BaseObjectArray;

		/// <summary>
		/// Ширина "игрового поля"
		/// </summary>
		public static int Width { get; set; }

		/// <summary>
		/// Высота "игрового поля"
		/// </summary>
		public static int Height { get; set; }

		static KulikGame()
		{
		}

		/// <summary>
		/// Инициализация графики для формы
		/// </summary>
		/// <param name="form"></param>
		public static void Init(KulikForm form)
		{
			Graphics gr;
			_context = BufferedGraphicsManager.Current;
			gr = form.CreateGraphics();
			Width = form.ClientSize.Width;
			Height = form.ClientSize.Height;
			Buffer = _context.Allocate(gr, new Rectangle(0, 0, Width, Height));
			// Д.б. в Load()
			BaseObjectArray = new CBaseObject[26];
			for (int i = 0; i < BaseObjectArray.Length / 2; i++)
			{
				BaseObjectArray[i] = new CBaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(10, 10));
			}
			for (int i = BaseObjectArray.Length / 2; i < BaseObjectArray.Length; i++)
			{
				BaseObjectArray[i] = new CStar(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(5, 5));
			}


			Timer timer = new Timer();
			timer.Interval = 100;
			timer.Start();
			timer.Tick += TimerTick;
		}

		private static void TimerTick(object sender, EventArgs e)
		{
			Draw();
			Update();
		}

		public static void Draw()
		{
			Buffer.Graphics.Clear(Color.Black);
			//Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
			//Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
			foreach (CBaseObject item in BaseObjectArray)
			{
				item.Draw();
			}
			Buffer.Render();
		}

		public static void Update()
		{
			foreach (CBaseObject obj in BaseObjectArray)
			{
				obj.Update();
			}
		}

	}
}
