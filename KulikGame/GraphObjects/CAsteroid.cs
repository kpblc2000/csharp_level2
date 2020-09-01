using System.Drawing;

namespace KulikLev2
{
	/// <summary>
	/// Астероиды
	/// </summary>
	class CAsteroid : CBaseObject
	{
		/// <summary>
		/// Мощность астероида
		/// </summary>
		public int Power { get; set; }

		/// <summary>
		/// Создает экземпляр класса астероид
		/// </summary>
		/// <param name="Position">Левый верхний угол отрисовки</param>
		/// <param name="Direction">Направление движения (положительные числа - влево и вниз)</param>
		/// <param name="Size">Размер астероида</param>
		/// <param name="Power">Мощность астероида</param>
		public CAsteroid(Point Position, Point Direction, Size Size, int Power) : base(Position, Direction, Size)
		{
			this.Power = Power;
		}

		/// <summary>
		/// Создает экземпляр класса астероид
		/// </summary>
		/// <param name="Position">Левый верхний угол отрисовки</param>
		/// <param name="Direction">Направление движения (положительные числа - влево и вниз)</param>
		/// <param name="Size">Размер астероида</param>
		public CAsteroid(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
		{
			this.Power = 0;
		}

		/// <summary>
		/// Отрисовка объекта Астероид
		/// </summary>
		public override void Draw()
		{
			KulikGame.Buffer.Graphics.FillEllipse(Brushes.White, Position.X, Position.Y, Size.Width, Size.Height);
		}

		/// <summary>
		/// Обновление и проверка положения астероида
		/// </summary>
		public override void Update()
		{
			{
				Position.X += Direction.X;
				Position.Y += Direction.Y;

				if (Position.X < 0)
					Position.X = KulikGame.Width;
				else if (Position.X > KulikGame.Width)
					Position.X = 0;
				if (Position.Y < 0)
					Position.Y = KulikGame.Height;
				else if (Position.Y > KulikGame.Height)
					Position.Y = 0;
			}
		}

		public bool CrossToBullet(CBullet Bullet)
		{
			bool res =
			(
			(Position.X >= Bullet.PositionP.X && Position.X <= Bullet.PositionP.X + Bullet.SizeP.Width) &&
			(Position.Y >= Bullet.PositionP.Y && Position.Y <= Bullet.PositionP.Y + Bullet.SizeP.Height)
			)
			||
			(
			(Position.X+Size.Width >= Bullet.PositionP.X && Position.X + Size.Width <= Bullet.PositionP.X + Bullet.SizeP.Width) &&
			(Position.Y+Size.Height >= Bullet.PositionP.Y && Position.Y + Size.Height <= Bullet.PositionP.Y + Bullet.SizeP.Height)
			)
			;


			return res;

		}

		public Point PositionP { get { return Position; } set { Position = value; } }

		public Point DirectionP { get { return Direction; } set { Direction = value; } }

		public Size SizeP { get { return Size; } set { Size = value; } }
	}
}
