using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace KulikLev2
{
	class CBaseObject
	{
		protected Point Position;
		protected Point Direction;
		protected Size Size;

		private Image _img;

		public CBaseObject(Point PositionPoint, Point Direction, Size Size)
		{
			this.Position = PositionPoint;
			this.Direction = Direction;
			this.Size = Size;

			Random rnd = new Random();
			int val = rnd.Next(1, 4);

			switch (val)
			{
				case 1:
					_img = Resource1.star1;
					break;
				case 2:
					_img = Resource1.star2;
					break;
				case 3:
					_img = Resource1.star3;
					break;
				case 4:
					_img = Resource1.star4;
					break;
				default:
					_img = Resource1.star5;
					break;
			}
		}

		public virtual void Draw()
		{
			// KulikGame.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
			Rectangle rec = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
			KulikGame.Buffer.Graphics.DrawImage(_img, Position.X, Position.Y, Size.Width, Size.Height);
		}

		public virtual void Update()
		{
			Position.X += Direction.X;
			Position.Y += Direction.Y;

			if (Position.X < 0)
				Position.X = KulikGame.Width;
			else if (Position.X > KulikGame.Width)
				Position.X = 0;
		}
	}
}
