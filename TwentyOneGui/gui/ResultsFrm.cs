using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwentyOneGui.gui
{
    public partial class ResultsFrm : Form
    {
        private string name1;
        private string name2;
        private int points1;
        private int points2;
        public ResultsFrm()
        {
            InitializeComponent();
        }
        public void InitLabelOne (string playerName, int points)
        {
            this.label1.Text = $"Player: {playerName}  has {points} points";
            this.name1 = playerName;
            this.points1 = points;
        }
        public void InitLabelTwo (string playerName, int points)
        {
            this.label2.Text = $"Player: {playerName}  has {points} points";
            this.name2 = playerName;
            this.points2 = points;
        }
        public void SetResults ()
        {
            if (points1 == 21)
                this.label3.Text = $"{name1} won with 21 points";
            else
                if (points2 == 21)
                this.label3.Text = $"{name2} won with 21 points";
            else
                if (points1 > 21 && points2 > 21)
                this.label3.Text = $"Both players lost";
            else
                if (points1 > 21)
                this.label3.Text = $"{name2} won with {points2}";
            else
                     if (points2 > 21)
                this.label3.Text = $"{name1} won with {points1}";
            else
                this.label3.Text = points1 == points2 ? "It is a tie" : points1 > points2 ? $"{name1} won with  {points1}  points" : $"{name2} won with {points2} points";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
