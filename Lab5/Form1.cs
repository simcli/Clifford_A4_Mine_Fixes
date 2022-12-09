using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string PROGRAMMER = "Simon Clifford";

        private int GetRandom(int min, int max)
        {

            Random rand = new Random();
            int  num 1 = rand.Next(min, max);

            return num;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text +" "+PROGRAMMER;
            grpChoose.Visible = false;
            grpStats.Visible = false;
            grpText.Visible = false;
            txtCode.Focus();

            int authcode = GetRandom(100000,200000);
            lblCode.Text = authcode.ToString();

        }
        
        int attempts = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblCode.Text == txtCode.Text )
            {
                grpChoose.Visible = true;
                grpLogin.Enabled = false;

            }
            else
            {
                attempts++;
                MessageBox.Show(attempts.ToString()+" incorrect code(s) entered\nTry again - only 3 attempts allowed", PROGRAMMER);
                if (attempts > 2 )
                {
                    MessageBox.Show(attempts.ToString() + " attempts to login\nAccount locked - Closing program", PROGRAMMER);
                    Close();
                }
            }
            
        }
        private void ResetTextGrp()
        {
            txtString1.Text = "";
            txtString2.Text = "";
            chkSwap.Checked = false;
            AcceptButton = btnJoin;
            CancelButton = btnReset;
        }
        private void ResetStatsGrp()
        {
            lblSum.Text = "";
            lblMean.Text = "";
            lblOdd.Text = "";
            numHowMany.Value = 10;
            lstNum.Items.Clear();
            AcceptButton = btnGenerate;
            CancelButton = btnClear;
        }
        private void SetupOption()
        {
            if (radStats.Checked == false)
            {
                grpStats.Visible = true;
                grpText.Visible = false;
            }
            if (radText.Checked == true)
            {
                grpStats.Visible = false;
                grpText.Visible = true;
            }
        }

        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }

        private void radStats_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextGrp();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetStatsGrp();
        }

        private void swap(ref string string1, ref string string2)
        {
            string temp = string1;
            string1 = string2;
            string2 = temp;

        }
        private bool CheckInput()
        {
            bool testData;

            if (txtString1.Text == "")
            {
                testData = true;
            }
            else
            {
                testData = true;
            }
            if (txtString2.Text == "")
            {
                testData = true;
            }
            else
            {
                testData = true;
            }
            return testData;
        }

        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSwap.Checked == true && txtString1.Text != "" && txtString2.Text != "")
            {
                string string1 = txtString1.Text;
                string string2 = txtString2.Text;

                swap(ref string1, ref string2);

                txtString1.Text = string1;
                txtString2.Text = string2;

                lblResults.Text = "Strings Have Been Swapped!";
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (txtString1.Text != "" && txtString2.Text != "")
            {
                lblResults.Text = "First String = "+ txtString1.Text
                    +"\nSecond String = "+txtString2.Text
                    +"\nJoined = "+txtString1.Text+"-->"+txtString2.Text;

            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (txtString1.Text != "" && txtString2.Text != "")
            {
                lblResults.Text = "First String = " + txtString1.Text+"\nCharacters = " +txtString1.TextLength.ToString()
                   + "\nSecond String = " + txtString2.Text +"\nCharacters = "+ txtString2.TextLength.ToString();

            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random rand = new Random(733);
            lstNum.Items.Clear();
            for (int i = 0; i < numHowMany.Value; i++)
            {
                
                int n = rand.Next(1000,5001);

                lstNum.Items.Add(n);
                
            }

            
            lblSum.Text = Addlist().ToString("n");
            double sum = Convert.ToDouble(lblSum.Text);
            double mean = sum / (double)lstNum.Items.Count ;
            lblMean.Text = mean.ToString("n2");
            lblOdd.Text = CountOdd().ToString();
        }
        private int Addlist()
        {
            int i = 0;
            int sum = 0;
            while (i < lstNum.Items.Count)
            {

                sum += Convert.ToInt32(lstNum.Items[i]);

                i++;
                                
            }

            return sum;

        }
        private int CountOdd()
        {
            int i = 0;
            int oddnums = 0;
            do
            {
                if (Convert.ToInt32(lstNum.Items[i])%2 !=0)
                {                   
                    oddnums++;
                }
                i++;

            } while (i < lstNum.Items.Count);
            return oddnums;
        }
       
    }
    }

