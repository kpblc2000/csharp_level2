using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulikLev2
{
	class CStar : CBaseObject
	{
		public CStar(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
		{ }

		public override void Draw()
		{
			KulikGame.Buffer.Graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
			KulikGame.Buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
		}

		public override void Update()
		{
			Position.X = Position.X - Direction.X;
			if (Position.X<0)
			{
				Position.X = KulikGame.Width + Size.Width;
			}
		}

	}
}
