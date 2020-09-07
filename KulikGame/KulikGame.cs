using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using System.Collections;

namespace KulikLev2
{

    static class KulikGame
    {
        private static BufferedGraphicsContext _context;
        private static int _width;
        private static int _height;

        private static int AsteroidRange = 4;


        private static Dictionary<int, Bullet> dictBullet = new Dictionary<int, Bullet>();

        private static List<Bullet> listBullets = new List<Bullet>();

        private static List<int> erasedBullets = new List<int>();
        private static Asteroid[] _asteroids;
        private static HealthKit[] _kits;
        private static int FightAster = 0;

        private static Timer _timer = new Timer();

        public static BufferedGraphics Buffer;
        public static BaseObject[] BaseObjectArray;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(15, 5), new Size(10, 10));

        /// <summary>
        /// Ширина "игрового поля"
        /// </summary>
        public static int Width
        {
            get { return _width; }
            set
            {
                if (value > 1000 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    _width = value;
            }
        }

        /// <summary>
        /// Высота "игрового поля"
        /// </summary>
        public static int Height
        {
            get { return _height; }
            set
            {
                if (value > 1000 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    _height = value;
            }
        }

        static KulikGame() { }

        private static void InitAsteroids(int Range)
        {
            _asteroids = new Asteroid[Range];
            var rnd = new Random();
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(0, 50);
                int s = rnd.Next(11, 20);
                _asteroids[i] = new Asteroid(new Point(rnd.Next(KulikGame.Width / 4, KulikGame.Width), rnd.Next(0, KulikGame.Height)), 
                    new Point(-r, 0),
                    new Size(s, s));
            }
        }

        /// <summary>
        /// Инициализация графики для формы
        /// </summary>
        /// <param name="form">Форма, на которой будет выполняться работа</param>
        /// <param name="CrossRange">Количество "крестиков". По умолчанию = 15</param>
        /// <param name="StarRange">Количество изображений звезд. По умолчанию = 6</param>
        public static void Init(KulikForm form, int CrossRange = 15, int StarRange = 6)
        {

            Graphics gr;
            _context = BufferedGraphicsManager.Current;
            gr = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(gr, new Rectangle(0, 0, Width, Height));
            form.KeyDown += form_KeyDown;

            // Load()

            #region С первого урока
            /*
            Random rndPos = new Random();
            Random rndSpeed = new Random();
            Random rndSize = new Random();
            Random rndPower = new Random();

            BaseObjectArray = new CBaseObject[CrossRange + StarRange];
            for (int i = 0; i < StarRange; i++)
            {
                int tempSize = rndSize.Next(25, 55);
                BaseObjectArray[i] = new Asteroid(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize), rndPos.Next(3,10));
            }
            for (int i = StarRange; i < BaseObjectArray.Length; i++)
            {
                int tempSize = rndSize.Next(3, 35);
                BaseObjectArray[i] = new CStar(new Point(rndPos.Next(1, Width), rndPos.Next(1, Height)), new Point(rndSpeed.Next(10, 30), 0), new Size(tempSize, tempSize));
            }
            */
            #endregion

            #region Урок 2. Добавление астероидов

            // Звезды
            BaseObjectArray = new BaseObject[30];
            var rnd = new Random();
            for (var i = 0; i < BaseObjectArray.Length; i++)
            {
                int r = rnd.Next(-50, 50);
                BaseObjectArray[i] = new Star(new Point(rnd.Next(0, KulikGame.Width), rnd.Next(0, KulikGame.Height)), new Point(-r, r), new Size(3, 3));
            }

            // Астероиды
            InitAsteroids(AsteroidRange);
            //_asteroids = new Asteroid[4];
            //for (int i = 0; i < _asteroids.Length; i++)
            //{
            //    int r = rnd.Next(0, 50);
            //    int s = rnd.Next(11, 20);
            //    _asteroids[i] = new Asteroid(new Point(rnd.Next(KulikGame.Width / 4, KulikGame.Width), rnd.Next(0, KulikGame.Height)), new Point(-r, r / 10), new Size(s, s));
            //}

            // Аптечки
            _kits = new HealthKit[5];
            for (int i = 0; i < _kits.Length; i++)
            {
                int r = rnd.Next(0, 50);
                int s = rnd.Next(11, 20);
                _kits[i] = new HealthKit(new Point(rnd.Next(KulikGame.Width / 4, KulikGame.Width), rnd.Next(0, KulikGame.Height)), new Point(-r, r / 10), new Size(s, s));
            }

            #endregion

            _timer.Interval = 70;
            _timer.Start();
            _timer.Tick += TimerTick;

            Ship.eventMessage += Finish;
            Ship.eventMessage += FinishConsole;

            Ship.eventHealth += Health;
            Ship.eventStatus += Status;

        }

        public static void Status(object sender, KeyEventArgs args)
        {

            // Keys.Control.Equals(args.KeyCode);
            switch (args.KeyCode)
            {
                case Keys.ControlKey:
                    Console.WriteLine("Выстрел");
                    break;
                case Keys.Down:
                    Console.WriteLine("Вниз");
                    break;
                case Keys.Up:
                    Console.WriteLine("Вверх");
                    break;
                default:
                    break;
            }
        }

        public static void Health(int Value)
        {
            Console.WriteLine($"Здоровья : {_ship.Energy}");
        }

        private static void form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    listBullets.Add(new Bullet(new Point(_ship.Position.X + _ship.Size.Width, _ship.Position.Y + _ship.Size.Height / 2),
                        new Point(4, 0),
                        new Size(4, 1)));
                    break;
                case Keys.Up:
                    _ship.MoveUp();
                    break;
                case Keys.Down:
                    _ship.MoveDown();
                    break;
            }

            _ship.funcStatus(sender, e);
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            int notNullLen = _asteroids.Length;
            foreach (var item in _asteroids)
            {
                notNullLen -= item == null ? 1 : 0;
            }
            if (notNullLen != 0)
            {
                foreach (BaseObject item in BaseObjectArray)
                { item.Draw(); }
                foreach (Asteroid item in _asteroids)
                { item?.Draw(); }
                foreach (HealthKit item in _kits)
                { item?.Draw(); }
                foreach (Bullet item in listBullets)
                {
                    item.Draw();
                }
                _ship?.Draw();
                if (_ship != null)
                    Buffer.Graphics.DrawString("Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

                Buffer.Render();
            }
            else
            {
                AsteroidRange += 1;
                InitAsteroids(AsteroidRange);
                Draw();
            }
        }

        public static void Update()
        {

            foreach (BaseObject obj in BaseObjectArray)
            { obj.Update(); }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                for (int b = 0; b < listBullets.Count; b++)
                {
                    if (_asteroids[i] != null && _asteroids[i].Collision(listBullets[b]))
                    {
                        listBullets.RemoveAt(b);
                        _asteroids[i] = null;
                        FightAster += 1;
                    }
                    else if (listBullets[b].Position.X >= KulikGame.Width)
                    {
                        listBullets.RemoveAt(b);
                    }
                    else
                    {
                        listBullets[b].Update();
                    }
                }

                if (_asteroids[i] != null && _asteroids[i].Collision(_ship))
                {
                    int lowEnergy = _asteroids[i].Power;
                    _ship?.EnergyLow(lowEnergy);
                    _ship?.funcHealth(lowEnergy);

                    System.Media.SystemSounds.Asterisk.Play();
                    _asteroids[i] = null;
                    if (_ship.Energy <= 0) _ship?.Die();
                }
            }

            for (int i = 0; i < _kits.Length; i++)
            {
                if (_kits[i] == null) continue;
                _kits[i].Update();
                if (_kits[i].Collision(_ship))
                {
                    int lowEnergy = _kits[i].Power;
                    _ship?.EnergyPlus(lowEnergy);
                    _ship?.funcHealth(lowEnergy);
                    _kits[i] = null;
                }
            }
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Graphics.DrawString("Сбито " + FightAster.ToString() + " астеродиов", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Underline), Brushes.White, 200, 200);

            Buffer.Render();
        }

        public static void FinishConsole()
        {
            Console.WriteLine("Корабль кончился");
        }

    }
}
