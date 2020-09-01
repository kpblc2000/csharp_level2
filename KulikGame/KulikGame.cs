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
		private static int _width;
		private static int _height;

		private static CBullet _bullet;
		private static CAsteroid[] _asteroids;

		public static BufferedGraphics Buffer;
		public static CBaseObject[] BaseObjectArray;

		/// <summary>
		/// Ширина "игрового поля"
		/// </summary>
		public static int Width
		{
			get { return _width; }
			set
			{
				if (value > 1000 || value <= 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				else
					_width = value;
			}
		}

		/// <summary>
		/// Высота "игрового поля"
		/// </summary>
		public static int Height
		{
			get { return _height; }
			set
			{
				if (value > 1000 || value <= 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				else
					_height = value;
			}
		}

		static KulikGame() { }

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

			#region С первого урока
			/*
			Random rndPos = new Random();
			Random rndSpeed = new Random();
			Random rndSize = new Random();
			Random rndPower = new Random();

			BaseObjectArray = new CBaseObject[CrossRange + StarRange];
			for (int i = 0; i < StarRange; i++)
			{
				int tempSize = rndSize.Next(25, 55);
				BaseObjectArray[i] = new Asteroid(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize), rndPos.Next(3,10));
			}
			for (int i = StarRange; i < BaseObjectArray.Length; i++)
			{
				int tempSize = rndSize.Next(3, 35);
				BaseObjectArray[i] = new CStar(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize));
			}
			*/
			#endregion

			#region Урок 2. Добавление астероидов
			BaseObjectArray = new CBaseObject[30];
			Random _r = new Random();
			_bullet = new CBullet(new Point(0, 200), new Point(_r.Next(0, 10), _r.Next(0, 10)), new Size(4, 1));
			_asteroids = new CAsteroid[3];
			var rnd = new Random();
			for (var i = 0; i < BaseObjectArray.Length; i++)
			{
				int r = rnd.Next(5, 50);
				BaseObjectArray[i] = new CStar(new Point(1000, rnd.Next(0, KulikGame.Height)), new Point(-r, r), new Size(3, 3));
			}
			for (var i = 0; i < _asteroids.Length; i++)
			{
				int r = rnd.Next(5, 50);
				_asteroids[i] = new CAsteroid(new Point(1000, rnd.Next(0, KulikGame.Height)), new Point(-r / 5, r), new Size(r, r));
			}

#if DEBUG
			// Тест факта столкновения
			Point pt = new Point(-_bullet.DirectionP.X, 0);
			_asteroids[_asteroids.Length - 1].DirectionP = pt;
			pt.X = KulikGame.Width / 2;
			pt.Y = _bullet.PositionP.Y;
			_asteroids[_asteroids.Length - 1].PositionP = pt;
#endif

			#endregion

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
			{ item.Draw(); }
			_bullet.Draw();
			foreach (CAsteroid item in _asteroids)
			{ item.Draw(); }
			Buffer.Render();
		}

		public static void Update()
		{
			foreach (CBaseObject obj in BaseObjectArray)
			{ obj.Update(); }
			foreach (CAsteroid _ast in _asteroids)
			{
				if (_ast.CrossToBullet(_bullet))
				{
					Random rndPos = new Random();
					_bullet.PositionP = new Point(rndPos.Next(0, KulikGame.Width), rndPos.Next(0, KulikGame.Height));
					_ast.PositionP = new Point(rndPos.Next(0, KulikGame.Width), rndPos.Next(0, KulikGame.Height));
				}
				_ast.Update();
			}
			_bullet.Update();
		}

	}
}
