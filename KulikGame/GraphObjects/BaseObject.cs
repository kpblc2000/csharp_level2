using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization.Advanced;

namespace KulikLev2
{
    /// <summary>
    /// Делегат для вывода сообщений
    /// </summary>
    public delegate void Message();
    /// <summary>
    /// Делегат для обработки состовния корабля (какие кнопки были нажаты)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ShipStatus(object sender, KeyEventArgs e);

    /// <summary>
    /// Делегат для обработки здоровья корабля
    /// </summary>
    /// <param name="HealthValue"></param>
    public delegate void ShipHealth(int HealthValue);

    abstract class BaseObject
    {
        public Point Position;
        public Point Direction;
        public Size Size;

        // private Image _img;

        public BaseObject(Point PositionPoint, Point Direction, Size Size)
        {
            this.Position = PositionPoint;
            this.Direction = Direction;
            this.Size = Size;
        }

        public virtual void Draw()
        {
            Rectangle rec = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
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

        /// <summary>
        /// Проверка вхождения точки в указанный прямоугольник
        /// </summary>
        /// <param name="CheckPoint">Проверяемая точка</param>
        /// <param name="RectangleBasePoint">Начальная точка прямоугольника</param>
        /// <param name="RectangleSize">Размер прямоугольник</param>
        /// <returns></returns>
        public bool PointInRectangle(Point CheckPoint, Point RectangleBasePoint, Size RectangleSize)
        {
            return (CheckPoint.X >= RectangleBasePoint.X && CheckPoint.X <= RectangleBasePoint.X + RectangleSize.Width && CheckPoint.Y >= RectangleBasePoint.Y && CheckPoint.Y <= RectangleBasePoint.Y + RectangleSize.Height);
        }
    }
}
