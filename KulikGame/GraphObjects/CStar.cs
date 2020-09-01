using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulikLev2
{

	/// <summary>
	/// Класс "рисования" крестиков
	/// </summary>
	class CStar : CBaseObject
	{
		/// <summary>
		/// Создание объекта для "рисования" крестиков
		/// </summary>
		/// <param name="Position">Левая верхняя точка позиционирования крестика</param>
		/// <param name="Direction">Направление перемещения (положительное первое число - направо; положительное второе число - налево). Значения определяют скорость перемещения объекта</param>
		/// <param name="Size">Размер объекта, ед.формы.</param>
		public CStar(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
		{ }

		/// <summary>
		/// Рисует крестик
		/// </summary>
		public override void Draw()
		{
			KulikGame.Buffer.Graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
			KulikGame.Buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
		}

		/// <summary>
		/// Обновление объекта
		/// </summary>
		public override void Update()
		{
			Position.X += Direction.X;
			if (Position.X < 0)
				Position.X = KulikGame.Width;
			else if (Position.X > KulikGame.Width)
				Position.X = -Size.Width;
		}

	}
}
