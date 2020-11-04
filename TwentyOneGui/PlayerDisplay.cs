using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class PlayerDisplay : UserControl
    {
        private Player p;
        private CardImage img;
        private PictureBox[] cards;
        public PlayerDisplay(Player p, CardImage img)
        {
            InitializeComponent();
            this.p = p;
            this.img = img;
            this.label1.Text = p.GetName();
            cards = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            foreach (PictureBox b in cards)
            {
                b.Visible = false;
            }
        }
        public void ShowCards()
        {
            List<Card> cardsP = p.GetCards();
            int i = 0;
            foreach (Card c in cardsP)
            {
                cards[i].Visible = true;
                cards[i++].Image = img.GetCardImage(c);
            }
        }
        
    }
}
