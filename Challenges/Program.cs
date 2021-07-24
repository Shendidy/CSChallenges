using System;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var chicken1 = new Chicken();
            var egg = chicken1.Lay();
            var childChicken = egg.Hatch();
            Console.WriteLine(childChicken.GetType());

            var chicken2 = new Chicken2();
            var egg2 = chicken2.Lay();
            var childChicken2 = egg2.Hatch();
            Console.WriteLine(childChicken2.GetType());
        }
    }

    public interface IBird
    {
        Egg Lay();
    }

    public class Chicken : IBird
    {
        public Chicken()
        {
        }

        public Egg Lay()
        {
            return new Egg(() => this);
        }
    }

    public class Chicken2 : IBird
    {
        public Chicken2()
        {
        }

        public Egg Lay()
        {
            return new Egg(() => this);
        }
    }

    public class Egg
    {
        private bool hatched = false;
        private readonly Func<IBird> _createBird;

        public Egg(Func<IBird> createBird)
        {
            _createBird = createBird;
        }

        public IBird Hatch()
        {
            if (!hatched)
            {
                hatched = true;
                return _createBird();
            }

            throw new System.InvalidOperationException("This egg has hatched already!");
        }
    }
}