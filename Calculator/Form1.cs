using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double A, B, res;
        private char op = '0'; // zero means no operator
        private readonly string[] ops = { "x", "÷", "+", "-" };
        private bool error = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void C_Click(object sender, EventArgs e)
        {
            error = false;
            result.Text = "0";
            B = A = 0;
            op = '0';
        }

        private void Result_TextChanged(object sender, EventArgs e)
        {
            if (op == '=') { op = '0'; }
            if (error)
            {
                result.Text = " Math Error";
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (error || op == '=')
            {
                error = false;
                result.Text = "0";
            }
            else if (result.Text.Length == 1)
            {
                result.Text = "0";
            }
            else
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
            }
        }

        private void Div_Click(object sender, EventArgs e)
        {
            if (!error)
            {
                if (!ops.Contains(result.Text) && op != '=' && op != '0')
                {
                    B = Convert.ToDouble(result.Text);
                    A = Calculate();
                }
                else if (!ops.Contains(result.Text))
                {
                    A = Convert.ToDouble(result.Text);
                }
                op = '/';
                result.Text = "÷";
            }
        }

        private void Multi_Click(object sender, EventArgs e)
        {
            if (!error)
            {
                if (!ops.Contains(result.Text) && op != '=' && op != '0')
                {
                    B = Convert.ToDouble(result.Text);
                    A = Calculate();
                }
                else if (!ops.Contains(result.Text))

                {
                    A = Convert.ToDouble(result.Text);
                }
                op = '*';
                result.Text = "x";
            }
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            if (!error)
            {
                if (result.Text == "0" || ops.Contains(result.Text))
                {
                    result.Text = "-";
                }
                else if (!ops.Contains(result.Text) && op != '=' && op != '0')
                {
                    B = Convert.ToDouble(result.Text);
                    A = Calculate();
                    result.Text = "-";
                    op = '-';
                }
                else
                {
                    A = Convert.ToDouble(result.Text);
                    result.Text = "-";
                    op = '-';
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!error)
            {
                if (!ops.Contains(result.Text) && op != '=' && op != '0')
                {
                    B = Convert.ToDouble(result.Text);
                    A = Calculate();
                }
                else if (!ops.Contains(result.Text))
                {
                    A = Convert.ToDouble(result.Text);
                }
                op = '+';
                result.Text = "+";
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            try
            {
                if (ops.Contains(result.Text))
                {
                    result.Text = A.ToString();
                }
                else if (op == '=' || op == '0')
                {
                    result.Text = "" + double.Parse(result.Text);
                }
                else
                {
                    B = Convert.ToDouble(result.Text);
                    A = Calculate();
                    if (double.IsInfinity(res))
                        throw new Exception();
                    result.Text = res.ToString();
                }
                op = '=';
            }
            catch
            {
                error = true;
                result.Text = " Math Error";
                op = '=';
            }
        }

        private void B7_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "7";
                else
                    result.Text = "7";
            }
            else
                result.Text += "7";
        }

        private void B8_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "8";
                else
                    result.Text = "8";
            }
            else
                result.Text += "8";
        }

        private void B6_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "6";
                else
                    result.Text = "6";
            }
            else
                result.Text += "6";
        }

        private void B3_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "3";
                else
                    result.Text = "3";
            }
            else
                result.Text += "3";
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            if (op == '=' || op != '0' || ops.Contains(result.Text))
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "0.";
                else
                    result.Text = "0.";
            }
            //don't add dot again if it exists
            else if (!result.Text.Contains('.'))
            {
                result.Text += ".";
            }
        }

        private void B0_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "0";
                else
                    result.Text = "0";
            }
            else
                result.Text += "0";

            this.Focus();
        }

        private void B2_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "2";
                else
                    result.Text = "2";
            }
            else
                result.Text += "2";
        }

        private void B5_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "5";
                else
                    result.Text = "5";
            }
            else
                result.Text += "5";
        }

        private void B4_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "4";
                else
                    result.Text = "4";
            }
            else
                result.Text += "4";
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "1";
                else
                    result.Text = "1";
            }
            else
                result.Text += "1";
        }

        private void Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    B0_Click(sender, e);
                    b0.Focus();
                    break;

                case '1':
                    B1_Click(sender, e);
                    b1.Focus();
                    break;

                case '2':
                    B2_Click(sender, e);
                    b2.Focus();
                    break;

                case '3':
                    B3_Click(sender, e);
                    b3.Focus();
                    break;

                case '4':
                    B4_Click(sender, e);
                    b4.Focus();
                    break;

                case '5':
                    B5_Click(sender, e);
                    b5.Focus();
                    break;

                case '6':
                    B6_Click(sender, e);
                    b6.Focus();
                    break;

                case '7':
                    B7_Click(sender, e);
                    b7.Focus();
                    break;

                case '8':
                    B8_Click(sender, e);
                    b8.Focus();
                    break;

                case '9':
                    B9_Click(sender, e);
                    b9.Focus();
                    break;

                case '.':
                    Dot_Click(sender, e);
                    dot.Focus();
                    break;

                case (char)Keys.Back:
                    Delete_Click(sender, e);
                    delete.Focus();
                    break;

                case '=':
                    Equal_Click(sender, e);
                    equal.Focus();
                    break;

                case '/':
                    Div_Click(sender, e);
                    div.Focus();
                    break;

                case '+':
                    Add_Click(sender, e);
                    add.Focus();
                    break;

                case '-':
                    Sub_Click(sender, e);
                    sub.Focus();
                    break;

                case '*':
                    Multi_Click(sender, e);
                    multi.Focus();
                    break;
            }
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    B0_Click(sender, e);
                    b0.Focus();
                    break;

                case '1':
                    B1_Click(sender, e);
                    b1.Focus();
                    break;

                case '2':
                    B2_Click(sender, e);
                    b2.Focus();
                    break;

                case '3':
                    B3_Click(sender, e);
                    b3.Focus();
                    break;

                case '4':
                    B4_Click(sender, e);
                    b4.Focus();
                    break;

                case '5':
                    B5_Click(sender, e);
                    b5.Focus();
                    break;

                case '6':
                    B6_Click(sender, e);
                    b6.Focus();
                    break;

                case '7':
                    B7_Click(sender, e);
                    b7.Focus();
                    break;

                case '8':
                    B8_Click(sender, e);
                    b8.Focus();
                    break;

                case '9':
                    B9_Click(sender, e);
                    b9.Focus();
                    break;

                case '.':
                    Dot_Click(sender, e);
                    dot.Focus();
                    break;

                case (char)Keys.Back:
                    Delete_Click(sender, e);
                    delete.Focus();
                    break;

                case '=':
                    Equal_Click(sender, e);
                    equal.Focus();
                    break;

                case '/':
                    Div_Click(sender, e);
                    div.Focus();
                    break;

                case '+':
                    Add_Click(sender, e);
                    add.Focus();
                    break;

                case '-':
                    Sub_Click(sender, e);
                    sub.Focus();
                    break;

                case '*':
                    Multi_Click(sender, e);
                    multi.Focus();
                    break;
            }
        }

        private void B9_Click(object sender, EventArgs e)
        {
            if (ops.Contains(result.Text) || op == '=' || result.Text == "0")
            {
                if (result.Text == "-" && op != '-')
                    result.Text += "9";
                else
                    result.Text = "9";
            }
            else
                result.Text += "9";
        }

        private double Calculate()
        {
            switch (op)
            {
                case '+':
                    res = A + B;
                    break;

                case '-':
                    res = A - B;
                    break;

                case '*':
                    res = A * B;
                    break;

                case '/':
                    res = A / B;
                    break;
            }
            return res;
        }
    }
}