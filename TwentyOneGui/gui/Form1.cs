using TwentyOneGui.gui;
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwentyOneGui.model;


namespace TwentyOneGui.gui
{
    public partial class Form1 : Form
    {
        private Game g;
        private CardImage img;
        private List<PlayerDisplayC> displays;
       
        public Form1(Game g)
        {
            InitializeComponent();
            img = new CardImage();
            this.g = g;
            displays = new List<PlayerDisplayC>();
            pictureBox2.Image = img.GetBackOfCard();
            List<PictureBox>p  = new List<PictureBox>(new PictureBox[]{ p1,p2,p3, p4, p5,p6});
            PlayerDisplayC pd = new PlayerDisplayC(player1Name, p, g.GetPlayer(0), img);
            g.GetPlayer(0).AddDisplay(pd);
            displays.Add(pd);
            pd = new PlayerDisplayC(playerName2, new List<PictureBox>(new PictureBox[] { pp1, pp2, pp3, pp4, pp5, pp6 }), g.GetPlayer(1), img);
            g.GetPlayer(1).AddDisplay(pd);
            displays.Add(pd);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < g.CountPlayers(); j++)
                {
                    g.GetPlayer(j).AddCard(g.GetDeck().Deal());
                }
            displays[g.GetCurrentPlayer()].ShowCurrentPlayer();
        }
        public void StartNewGame()
        {

        }
        public void SessionOver()
        {
            foreach (PlayerDisplayC c in displays)
            {
               if (!c.PlayerLost())
                    c.UnshowCurrentPlayer();
            }
            button1.Enabled = false;
            button2.Enabled = false;
            ResultsFrm f = new ResultsFrm();
            f.InitLabelOne(g.GetPlayer(0).GetName(), g.GetPlayer(0).GetPoints());
            f.InitLabelTwo(g.GetPlayer(1).GetName(), g.GetPlayer(1).GetPoints());
            f.SetResults();
            f.ShowDialog();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!g.GetDeck().IsEmpty())
            {
                pictureBox2.Image = img.GetBackOfCard();// Add card to currentplayer and go to next player
                g.GetPlayer(g.GetCurrentPlayer()).AddCard(g.GetDeck().Deal());
                if (!g.Finished())
                {
                    g.NextPlayer();
                }
                else
                {
                    SessionOver();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.GetPlayer(g.GetCurrentPlayer()).StopBid();
            displays[g.GetCurrentPlayer()].UnshowCurrentPlayer();
            if (!g.Finished())
            { 
                g.NextPlayer();
                displays[g.GetCurrentPlayer()].ShowCurrentPlayer();
            }
            else
            {
                SessionOver();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            g.StartGame();
            button1.Enabled = true;
            button2.Enabled = true;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < g.CountPlayers(); j++)
                {
                    g.GetPlayer(j).AddCard(g.GetDeck().Deal());
                }
            g.GetPlayer(g.GetCurrentPlayer()).SetTurn();
        }
    }
}
