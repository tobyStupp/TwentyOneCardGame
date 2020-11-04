using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyOneGui.model;

namespace TwentyOneGui.gui
{
    public class CardImage
    {
        private Image[,] cards;
        private Image backOfCard;
        public CardImage ()
        {
           
            Image img = Image.FromFile("abc.png");
            int width = img.Width;
            int height = img.Height;
            int deltaW = width / 13;
            int deltaH = height / 5;
            cards = new Image[4, 13];
            for (int i = 0; i < 4; i++)
                for (int j=0; j< 13; j++)
                {
                    cards[i, j] = new Bitmap(deltaW, deltaH);
                    Graphics g = Graphics.FromImage(cards[i, j]);
                    g.DrawImage(img, new Rectangle(0, 0, deltaW, deltaH), j * deltaW, i * deltaH, deltaW, deltaH, GraphicsUnit.Pixel);
                    g.Dispose();
                }
            backOfCard = new Bitmap(deltaW, deltaH);
            Graphics g1 = Graphics.FromImage(backOfCard);
            g1.DrawImage(img, new Rectangle(0, 0, deltaW, deltaH), 2 * deltaW, 4 * deltaH, deltaW, deltaH, GraphicsUnit.Pixel);
            g1.Dispose();
        }
        public Image GetImage(int x, int y) => cards[x, y];
        public Image GetBackOfCard() => backOfCard;
        public Image GetCardImage(Card c) =>  cards[(int)c.GetShape(), c.GetValue()-1];
    }
}
