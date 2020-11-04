using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TwentyOneGui.model;

namespace TwentyOneGui.gui
{
    public class PlayerDisplayC
    {
        private List<PictureBox> pictures;
        private Label lname;
        private Player player;
        private CardImage img;
        private int displayed = 0;// how many cards shown
        public PlayerDisplayC (Label l, List<PictureBox>p, Player player, CardImage img)
        {
            this.pictures = p;
            this.lname = l;
            this.player = player;
            this.img = img;
            lname.Text = player.GetName();
            foreach (PictureBox b in pictures)
            {
                b.Visible = false;
            }
        }
        public void ShowNewCard ()
        {
            pictures[displayed].Visible = true;
            pictures[displayed].Image = img.GetCardImage(player.GetCards()[displayed]);
            displayed++;
        }
        public void ShowCurrentPlayer()
        {
            this.lname.ForeColor = Color.Red;
            this.lname.Font = new Font(lname.Font.FontFamily, 12, FontStyle.Bold);
        }
        public void UnshowCurrentPlayer ()
        {
            this.lname.ForeColor = Color.Black;
            this.lname.Font = new Font(lname.Font.FontFamily, 12);
        }
        public void LostPlayer()
        {
            this.lname.ForeColor = Color.Green;
            this.lname.Font = new Font(lname.Font.FontFamily, 12);
        }
        public bool PlayerLost()
        {
            return this.player.Lost();
        }
        public void EraseCards()
        {
            foreach (PictureBox pb in this.pictures)
                pb.Visible = false;
            this.displayed = 0;
        }
        
    }
}
