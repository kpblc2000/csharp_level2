using System.Drawing;
using System.Windows.Forms;

namespace KulikLev2
{
    class Ship : BaseObject
    {
        private int _energy = 100;

        public int Energy => _energy;

        public static event Message MessageDie;

        public void EnergyLow(int Value)
        { _energy -= Value; }
        public Ship(Point Position, Point Direction, Size Size) : base(Position, Direction, Size) { }

        public new Point Position { get { return base.Position; } set { base.Position = value; } }

        public new Point Direction { get { return base.Direction; } set { base.Direction = value; } }

        public new Size Size { get { return base.Size; } set { base.Size = value; } }

        public override void Draw()
        {
            KulikGame.Buffer.Graphics.FillEllipse(Brushes.Wheat, Position.X , Position.Y , Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void MoveUp()
        {
            if (Position.Y > 0) Position = new Point(Position.X, Position.Y - Direction.Y);
        }

        public void MoveDown()
        {
            if (Position.Y < KulikGame.Height - Size.Height) Position = new Point(Position.X, Position.Y + Direction.Y);
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
