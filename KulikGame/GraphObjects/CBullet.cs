using System.Drawing;

namespace KulikLev2
{
	/// <summary>
	/// Астероиды
	/// </summary>
	class CBullet : CBaseObject
	{

		/// <summary>
		/// Создает экземпляр класса пуля
		/// </summary>
		/// <param name="Position">Левый верхний угол отрисовки</param>
		/// <param name="Direction">Направление движения (положительные числа - влево и вниз)</param>
		/// <param name="Size">Размер астероида</param>
		/// <param name="Power">Мощность астероида</param>
		public CBullet(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
		{
		}

		public Point PositionP { get { return Position; } set { Position = value; } }

		public Point DirectionP { get { return Direction; } set { Direction = value; } }

		public Size SizeP { get { return Size; } set { Size = value; } }
		/// <summary>
		/// Отрисовка объекта пуля
		/// </summary>
		public override void Draw()
		{
			KulikGame.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Position.X, Position.Y, Size.Width, Size.Height);
		}

		/// <summary>
		/// Обновление и проверка положения пуля
		/// </summary>
		public override void Update()
		{
			this.Position.X = this.Position.X + 10;
			//Position.X += Direction.X;
			//Position.Y += Direction.Y;

			if (Position.X < 0)
				Position.X = KulikGame.Width;
			else if (Position.X > KulikGame.Width)
				Position.X = 0;

		}
	}
}
