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
    public partial class startGameFrm : Form
    {
        private int numOfPlayers = 2;
        private TextBox[] names = new TextBox[4];
        private Label[] labels;
       
        public startGameFrm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
         
            names = new TextBox[] { textBox1, textBox2, textBox3, textBox4 };
            labels = new Label[] { label5, label3,label3, label4 };
            Hide(2);
        }
        private void Hide (int c)
        {
            for (int i = 0; i < c; i++)
            {
                names[i].Visible = true;
                labels[i].Visible = true;
            }
            for (int i = c; i < 4; i++)
            {
                names[i].Visible = false;
                labels[i].Visible = false;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox1.SelectedItem);
                this.numOfPlayers = x;
                
                Hide(x);
            }
            catch (Exception ex)

            { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            bool ok = true;
            for (int i = 0; i < numOfPlayers && ok; i++)
            {
                if (names[i].Text.Trim().Length == 0)
                {
                    ok = false;
                }
                g.AddPlayer(names[i].Text);
            }
            if (!ok)
                MessageBox.Show("Missing names");
            else
            {
                this.Hide();
                new Form1( g).ShowDialog();
                this.Close();
            }
        }

      
    }
}
