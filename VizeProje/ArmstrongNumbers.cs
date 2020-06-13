using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje
{
    public class ArmstrongNumbers
    {
        public void StartArmstrong(int lowerLimit, int upperLimit, ListBox listBox)
        {
            for (int i = lowerLimit; i < upperLimit; i++)
            {
                if (ArmstrongControl(i) != 0)
                {
                    listBox.Items.Add(i);
                }
            }
        }
        public int ReviewStep(int number)
        {
            int stepNumber=0;
            while (number != 0)
            {
                number /= 10;
                ++stepNumber;
            }
            return stepNumber;
        }

        public int ArmstrongControl(int number)
        {
            int reserve= number;
            int stepNumber = ReviewStep(reserve);
            double result=0;
            while (reserve != 0)
            {
                int remainder = reserve % 10;
                result += Math.Pow(remainder, stepNumber);
                reserve /= 10;
            }
            if (result == number)
            {
                return number;
            }
            return 0;
        }
    }
}
