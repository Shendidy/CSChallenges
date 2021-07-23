using System;

namespace Challenges
{
    public enum Side { None, Left, Right }

    class Program
    {
        static void Main(string[] args)
        {
            ChainLink left = new ChainLink();
            ChainLink middle = new ChainLink();
            ChainLink right = new ChainLink();
            left.Append(middle);
            middle.Append(right);
            Console.WriteLine(left.LongerSide());
        }
    }

    public class ChainLink
    {
        public ChainLink Left { get; private set; }
        public ChainLink Right { get; private set; }

        public void Append(ChainLink rightPart)
        {
            if (this.Right != null)
                throw new InvalidOperationException("Link is already connected.");

            this.Right = rightPart;
            rightPart.Left = this;
        }

        public Side LongerSide()
        {
            int rightLinks = 0;
            int leftLinks = 0;

            ChainLink currentLink = this;


            while (currentLink.Right != null)
            {
                rightLinks++;
                currentLink = currentLink.Right;
                if (currentLink == this) return (Side.None);
            }

            currentLink = this;

            while (currentLink.Left != null)
            {
                leftLinks++;
                currentLink = currentLink.Left;
                if (currentLink == this) return (Side.None);
            }

            return leftLinks == rightLinks ? 
                    Side.None :
                    rightLinks > leftLinks ? Side.Right : Side.Left;
        }
    }
}