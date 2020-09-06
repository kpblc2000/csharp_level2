using System.Drawing;

namespace KulikLev2
{
    /// <summary>
    /// Астероиды
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Создает экземпляр класса пуля
        /// </summary>
        /// <param name="Position">Левый верхний угол отрисовки</param>
        /// <param name="Direction">Направление движения (положительные числа - влево и вниз)</param>
        /// <param name="Size">Размер астероида</param>
        /// <param name="Power">Мощность астероида</param>
        public Bullet(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
        }

        public new Point Position { get { return base.Position; } set { base.Position = value; } }

        public new Point Direction { get { return base.Direction; } set { base.Direction = value; } }

        public Size Size { get { return base.Size; } set { base.Size = value; } }
        /// <summary>
        /// Отрисовка объекта пуля
        /// </summary>
        public override void Draw()
        {
            KulikGame.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Position.X - base.Size.Width / 2, Position.Y - base.Size.Height / 2, base.Size.Width, base.Size.Height);
        }

        /// <summary>
        /// Обновление и проверка положения пуля
        /// </summary>
        public override void Update()
        {
            Position = new Point(Position.X + Direction.X, Position.Y);

            if (Position.X < 0)
                Position = new Point(KulikGame.Width, Position.Y);
            else if (Position.X > KulikGame.Width)
                Position = new Point(0, Position.Y);
        }
    }
}
