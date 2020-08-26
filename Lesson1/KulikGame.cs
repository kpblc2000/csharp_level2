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
		/// <param name="form">Форма, на которой будет выполняться работа</param>
		/// <param name="CrossRange">Количество "крестиков". По умолчанию = 15</param>
		/// <param name="StarRange">Количество изображений звезд. По умолчанию = 6</param>
		public static void Init(KulikForm form, int CrossRange = 15, int StarRange = 6)
		{
			Graphics gr;
			_context = BufferedGraphicsManager.Current;
			gr = form.CreateGraphics();
			Width = form.ClientSize.Width;
			Height = form.ClientSize.Height;
			Buffer = _context.Allocate(gr, new Rectangle(0, 0, Width, Height));

			// Load()

			Random rndPos = new Random();
			Random rndSpeed = new Random();
			Random rndSize = new Random();

			BaseObjectArray = new CBaseObject[CrossRange + StarRange];
			for (int i = 0; i < StarRange; i++)
			{
				int tempSize = rndSize.Next(25, 55);
				BaseObjectArray[i] = new CBaseObject(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize));
			}
			for (int i = StarRange; i < BaseObjectArray.Length; i++)
			{
				int tempSize = rndSize.Next(3, 35);
				BaseObjectArray[i] = new CStar(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize));
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
