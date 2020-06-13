using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje
{
    class MinefieldNumber
    {
        public int Number;
        public string Text => Number.ToString();
    }
    public class Minefield
    {
        private MinefieldNumber[] minefieldNumber = new MinefieldNumber[50];
        public bool ScoreUnder { get; set; }
        public Button[] Form2Mine { get; set; }
        public int Counter { get; set; }
        public int ConstantCounter { get; set; }
        public bool Control(int mineCount, Button[] btn, Form2 form,int sayac)
        {
            if (mineCount == 0)
            {
                MessageBox.Show("Lütfen Mayın Sayısını Sıfırdan Farklı Giriniz", "Bilgilendirme Penceresi");
                return false;
            }
            if (sayac == 0)
            {
                MessageBox.Show("Lütfen Saniyeyi Sıfırdan Farklı Giriniz", "Bilgilendirme Penceresi");
                return false;
            }

            ConstantCounter = Counter;
            form.Show();
            Form2Mine = form.button;
            ScoreUnder = true;
            return true;

        }
        public Button[] AddButton(Panel panel,Button[] btn, int rank=0)
        {
            panel.Controls.Clear();
            for (int i = 0; i < 49; i++)
            {
                btn[i] = new Button();
                
            }
            int[] sinir = new[] {12, 19, 26, 33, 40};
            int e = 8;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    btn[e].Size = new Size(40, 40);
                    btn[e].Location = new Point((j * 43) + 10, (i * 43) + 10);
                    btn[e].BackColor = Color.Gray;
                    btn[e].Click += new EventHandler(MineControl);
                    if (rank != 0)
                    {
                        btn[e].BackColor= Color.Green;
                        ScoreUnder = false;
                    }
                    panel.Controls.Add(btn[e]);
                    if (e == sinir[i]){e += 2;}
                    e++;
                }
            }

            return btn;
        }

        public void MineControl(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            for (int i = 0; i < Form2Mine.Length; i++)
            {
                Button buton= Form2Mine[i];
                if (clickedButton.Location == buton.Location)
                {
                    clickedButton.BackColor = buton.BackColor;
                    clickedButton.Text = buton.Text;
                    if (buton.BackColor==Color.Red)
                    {
                        MessageBox.Show("Oyun Bitti");
                        ScoreUnder = false;
                    }
                }
            }
            if(ScoreUnder)
            {
                Counter = ConstantCounter;
            }


        }
        public Button[] AddMine(int mine, Panel panel, Button[] btn)
        {
            AddButton(panel, btn,1);
            var rand = new Random();
            int[] mineIndex=new int[mine];
            for (int i = 0; i < mine; i++)
            {
                int a= rand.Next(36);
                if (btn[a].BackColor == Color.Green)
                {
                    btn[a].BackColor = Color.Red;
                    DistanceMine(btn,a);
                }
                else{i--;}
            }
            return btn;
        }

        public void DistanceMine(Button[] btn,int index)
        {
            int[] mineControl =  {-6,-7,-8,-1,1,8,7,6};
            for (int i = 0; i < mineControl.Length; i++)
            {
                if (btn[index + mineControl[i]].Text == "")
                {
                    minefieldNumber[index + mineControl[i]] = new MinefieldNumber();
                }
                minefieldNumber[index + mineControl[i]].Number++;
                btn[index + mineControl[i]].Text = minefieldNumber[index + mineControl[i]].Text;
            }
            
        }
        
    }
}
