using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimalityTester
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void solve_Click(object sender, EventArgs e)
        {
            
            Int64 N = Convert.ToInt64(input.Text);
            Int64 k = Convert.ToInt64(kValue.Text);
            if (!(k < N))
            {
                output.Text = "ERROR. k value must be less than input.";
            }
            else if (Little_Fermi(N, k))
            {
                double prob = 1 - 1 / Math.Pow(2, k);
                output.Text = "Yes, with probability " + prob;
            }
            else
            {
                output.Text = "No.";
            }
            return;
        }

        private bool Little_Fermi(Int64 N, Int64 k)
        {
            Random rnd = new Random();
            HashSet<Int64> randomNums = new HashSet<Int64>();
            while (randomNums.Count() < k)
            {
                randomNums.Add(rnd.Next(1, (Int32)N));
            }
            foreach (Int64 num in randomNums)
            {
                if (Modular_Exponentiation(num, N - 1, N) != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private Int64 Modular_Exponentiation(Int64 x, Int64 y, Int64 N)
        {
            if (y == 0) { return 1; }
            double yHalved = y / 2;
            Int64 z = Modular_Exponentiation(x, (int)Math.Floor(yHalved), N);
            if (y % 2 == 0)
            {
                Int64 zSquared = (z % N) * (z % N);
                zSquared = zSquared % N;
                return (Int64)(zSquared);
            }
            else
            {
                Int64 zSquaredx = (((z % N) * (z % N)) % N) * (x % N);
                zSquaredx = zSquaredx % N;
                return (Int64)(zSquaredx);
            }
        }
    }
}
