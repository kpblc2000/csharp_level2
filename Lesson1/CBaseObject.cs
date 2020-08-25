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

		public CBaseObject(Point PositionPoint, Point Direction, Size Size)
		{
			this.Position = PositionPoint;
			this.Direction = Direction;
			this.Size = Size;
		}

		public virtual void Draw()
		{
			KulikGame.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
		}

		public virtual void Update()
		{
			Position.X += Direction.X;
			Position.Y += Direction.Y;
			if ((Position.X < 0) || (Position.X > KulikGame.Width - Size.Width)) Direction.X = -Direction.X;
			if ((Position.Y < 0) || (Position.Y > KulikGame.Height - Size.Height)) Direction.Y = -Direction.Y;
		}
	}
}
