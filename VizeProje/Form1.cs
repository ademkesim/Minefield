using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Minefield minefield = new Minefield();
        ArmstrongNumbers armstrongNumbers = new ArmstrongNumbers();
        public int mineNumber { get; set; }
        public Button[] btn { get; set; }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            btn=new Button[49];
            btn = minefield.AddButton(panel1,btn);
            timer1.Interval = 1000;
            armstrongNumbers.ArmstrongControl(153);
        }
        
        private Form2 form2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (minefield.ScoreUnder)
            {
                var result = MessageBox.Show("Oyunu yeniden başlatmak istediğinize emin misiniz?",
                    "Bilgilendirme Ekranı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    btn=new Button[49];
                    minefield.AddButton(panel1, btn);
                }
            }

            minefield.Counter = (int) timerNumber.Value;
            mineNumber = (int) mineCount.Value;
            if (form2!=null)
            {
                form2.Close();
            }
            form2 = new Form2(mineNumber, btn);
            bool control = minefield.Control(mineNumber, btn,form2, minefield.Counter);
            if(control)
            {
                timer1.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RemainingTime.Text = "Kalan Süre=" + minefield.Counter;
            if (minefield.Counter == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süreniz Bitti");
                minefield.ScoreUnder = false;
            }
            minefield.Counter--;
        }
        private void Limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            screen.Items.Clear();
            int lowerLimit = Int32.Parse(this.lowerLimit.Text);
            int upperLimit = Int32.Parse(this.upperLimit.Text);
            armstrongNumbers.StartArmstrong(lowerLimit, upperLimit, screen);
        }
    }
}
