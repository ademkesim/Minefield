using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje
{
    public partial class Form2 : Form
    {
        private int mineNumber;
        public Button[] button { get; set; }
        public Form2(int mineCount, Button[] button)
        {
            mineNumber = mineCount;
            this.button = button;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Minefield minefield = new Minefield();
            button = new Button[49];
            Button[] btn = minefield.AddMine(mineNumber, panel1, button);
        }
    }
}
