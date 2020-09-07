using System.Drawing;

namespace KulikLev2
{

    /// <summary>
    /// Астероиды
    /// </summary>
    class Asteroid : BaseObject
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
        public Asteroid(Point Position, Point Direction, Size Size, int Power) : base(Position, Direction, Size)
        {
            this.Power = Power;
        }

        /// <summary>
        /// Создает экземпляр класса астероид
        /// </summary>
        /// <param name="Position">Левый верхний угол отрисовки</param>
        /// <param name="Direction">Направление движения (положительные числа - влево и вниз)</param>
        /// <param name="Size">Размер астероида</param>
        public Asteroid(Point Position, Point Direction, Size Size) : this(Position, Direction, Size, Size.Width)
        { }

        public new Point Position { get { return base.Position; } set { base.Position = value; } }

        public new Point Direction { get { return base.Direction; } set { base.Direction = value; } }

        /// <summary>
        /// Отрисовка объекта Астероид
        /// </summary>
        public override void Draw()
        {
            KulikGame.Buffer.Graphics.FillEllipse(Brushes.Yellow, Position.X, Position.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление и проверка положения астероида
        /// </summary>
        public override void Update()
        {
            Position = new Point(Position.X + Direction.X, Position.Y + Direction.Y);

            if (Position.X < 0)
                Position = new Point(KulikGame.Width, Position.Y + Direction.Y);
            else if (Position.X > KulikGame.Width - Size.Width)
                Position = new Point(Position.X, Position.Y + Direction.Y);
            if (Position.Y < 0)
                Position = new Point(Position.X, KulikGame.Height);
            else if (Position.Y > KulikGame.Height - Size.Height)
                Position = new Point(0);

        }

        //private bool PointInRectangle(Point CheckPoint, Point RectangleBasePoint, Size RectangleSize)
        //{
        //    return (CheckPoint.X >= RectangleBasePoint.X && CheckPoint.X <= RectangleBasePoint.X + RectangleSize.Width && CheckPoint.Y >= RectangleBasePoint.Y && CheckPoint.Y <= RectangleBasePoint.Y + RectangleSize.Height);
        //}

        public bool Collision(BaseObject baseObject)
        {
            //if ((PointInRectangle(baseObject.Position, Position, Size) || PointInRectangle(new Point(baseObject.Position.X + baseObject.Size.Width, baseObject.Position.Y + baseObject.Size.Height), Position, Size)))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return ((PointInRectangle(baseObject.Position, Position, Size) || PointInRectangle(new Point(baseObject.Position.X + baseObject.Size.Width, baseObject.Position.Y + baseObject.Size.Height), Position, Size)));
        }

    }
}
