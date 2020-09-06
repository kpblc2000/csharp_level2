using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace KulikLev2
{

    public delegate void Message();

    abstract class BaseObject
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        // private Image _img;

        public BaseObject(Point PositionPoint, Point Direction, Size Size)
        {
            this.Position = PositionPoint;
            this.Direction = Direction;
            this.Size = Size;
        }

        public virtual void Draw()
        {
            Rectangle rec = new Rectangle(Position.X , Position.Y , Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;
            if (Position.X < -Size.Width)
                Position.X = KulikGame.Width;
            else if (Position.X > KulikGame.Width)
                Position.X = -Size.Width;

            if (Position.Y < -Size.Height)
                Position.Y = KulikGame.Height;
            else if (Position.Y > KulikGame.Height)
                Position.Y = -Size.Height;
        }
    }
}
