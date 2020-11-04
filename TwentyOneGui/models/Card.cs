using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGui.model
{
  public  class Card
    {
        private Shape shape;
        private int value;
        public Card (Shape s, int v)
        {
            this.shape = s;
            if (v < 1 || v > 13)
                throw new Exception("ILLEGAL CARD VALUE");
            this.value = v;
        }
        public int GetValue() => value;
        public Shape GetShape() => shape;
        // returns true if this is an ace card
        public bool IsAce() => throw new NotImplementedException();
        // returns true if it is a card with jack, queen and king
        public bool IsPictureCard() => throw new NotImplementedException();
    }
}
