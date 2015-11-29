using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Petrofsky.Photography.FilterTemperature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int computeFilterValue(int temperature, int miredShift)
        {
            //zero energy case (left clipping)
            if (temperature == 0)
                return 0;

            double mired = 1000000.0 / (double)temperature;
            mired += miredShift;

            //0 or negative mired case (right clipping)
            if (mired <= 0)
                return 50000;

            int ret = (int)(Math.Round((1000000.0 / mired)));
            //another right clipping case
            if (ret > 50000)
                return 50000;

            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();

            //get the temperature
            int temperature = 0;
            try
            {
                temperature = int.Parse(textBox1.Text);
            }
            catch (System.FormatException)
            {
                temperature = -1;
            }
            catch (System.ArgumentNullException)
            {
                temperature = -1;
            }
            catch (System.OverflowException)
            {
                temperature = -1;
            }
            if (temperature < 0)
            {
                MessageBox.Show("Invalid temperature format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check upper bound
            if (temperature > 50000)
            {
                MessageBox.Show("This version only supports temperatures up to 50,000K!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            button1.Focus();

            //compute the filters
            txtWarm81.Text = computeFilterValue(temperature, -9).ToString();
            txtWarm81A.Text = computeFilterValue(temperature, -18).ToString();
            txtWarm81B.Text = computeFilterValue(temperature, -27).ToString();
            txtWarm81C.Text = computeFilterValue(temperature, -35).ToString();
            txtWarm81D.Text = computeFilterValue(temperature, -42).ToString();
            txtWarm81EF.Text = computeFilterValue(temperature, -53).ToString();
            txtWarm85C.Text = computeFilterValue(temperature, -81).ToString();
            txtWarm85.Text = computeFilterValue(temperature, -112).ToString();
            txtWarm85EB.Text = computeFilterValue(temperature, -131).ToString();

            txtCool82.Text = computeFilterValue(temperature, 10).ToString();
            txtCool82A.Text = computeFilterValue(temperature, 21).ToString();
            txtCool82B.Text = computeFilterValue(temperature, 32).ToString();
            txtCool82C.Text = computeFilterValue(temperature, 45).ToString();
            txtCool80D.Text = computeFilterValue(temperature, 56).ToString();
            txtCool80C.Text = computeFilterValue(temperature, 81).ToString();
            txtCool80B.Text = computeFilterValue(temperature, 112).ToString();
            txtCool80A.Text = computeFilterValue(temperature, 131).ToString();
        }

        private void btnWarm81_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81.Text);
        }

        private void btnWarm81A_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81A.Text);
        }

        private void btnWarm81B_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81B.Text);
        }

        private void btnWarm81C_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81C.Text);
        }

        private void btnWarm81D_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81D.Text);
        }

        private void btnCool82_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool82.Text);
        }

        private void btnCool82A_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool82A.Text);
        }

        private void btnCool82B_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool82B.Text);
        }

        private void btnCool82C_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool82C.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != CHAR_BACKSPACE && (e.KeyChar < '0' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void btnWarm81EF_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm81EF.Text);
        }

        private void btnWarm85C_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm85C.Text);
        }

        private void btnWarm85_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm85.Text);
        }

        private void btnWarm85EB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWarm85EB.Text);
        }

        private void btnCool80D_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool80D.Text);
        }

        private void btnCool80C_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool80C.Text);
        }

        private void btnCool80B_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool80B.Text);
        }

        private void btnCool80A_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCool80A.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        const char CHAR_BACKSPACE = (char)8;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
