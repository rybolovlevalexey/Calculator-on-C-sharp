using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        int binar_deyst = 0;  // 1 - сложение, 2 - вычитание, 3 - произведение, 4 - деление, 5 - степень
        bool double_flag = false;
        bool should_go_up = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButtonPushed(object sender, EventArgs e)
        {
            if (should_go_up)
            {
                string name = Convert.ToString((sender as Button).Text);
                bool is_double = false;
                string st = textBox1.Text;
                foreach (var el in st)
                {
                    if (Convert.ToString(el) == ",")
                    {
                        is_double = true;
                    }
                }
                st = st.Remove(st.Length - 2);
                if (!(is_double))
                {
                    st = st + ",0";
                }
                label1.Text = st;
                label2.Text = Convert.ToString(textBox1.Text[textBox1.Text.Length - 1]);
                should_go_up = false;
                if (name == ",")
                {
                    double_flag = true;
                    textBox1.Text = "0" + name;
                } else
                {
                    textBox1.Text = name;
                }
                
            } else
            {
                string name = Convert.ToString((sender as Button).Text);
                if (name == ",")
                {
                    double_flag = true;
                }
                if (name == "," && textBox1.Text.Length == 0)
                {
                    textBox1.Text = "0" + name;
                } else
                {
                    textBox1.Text = textBox1.Text + name;
                }
                
            }
            if (binar_deyst != 0)
            {
                MakeBinarResult();
            }
        }

        private void UnarOperatorButtonPushed(object sender, EventArgs e)
        {
            string text_in_button = (sender as Button).Text;

            if (text_in_button == "+/-")
            {
                bool is_double_in_box1 = false;
                foreach (var el in textBox1.Text)
                {
                    if (Convert.ToString(el) == ",")
                    {
                        is_double_in_box1 = true;
                    }
                }
                if (is_double_in_box1)
                {
                    textBox1.Text = Convert.ToString(-1 * Convert.ToDouble(textBox1.Text));
                } else
                {
                    textBox1.Text = Convert.ToString(-1 * Convert.ToInt32(textBox1.Text));
                }
                if (binar_deyst != 0)
                {
                    MakeBinarResult();
                }
            }
        }
        private void OperatorButtonPushed(object sender, EventArgs e)
        {
            string text_in_button = (sender as Button).Text;
            if (binar_deyst == 0)
            {
                textBox1.Text = textBox1.Text + " " + text_in_button[0];
            }
            else if (label1.Text.Length == 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 2) + " " + text_in_button[0];
            }
            else
            {
                string last_ans = textBox2.Text;
                textBox1.Text = last_ans + " " + (sender as Button).Text;
                label1.Text = "";
                label2.Text = "";
            }
            should_go_up = true;
            switch (text_in_button[0])
            {
                case '+':
                    binar_deyst = 1;
                    break;
                case '-':
                    binar_deyst = 2;
                    break;
                case '*':
                    binar_deyst = 3;
                    break;
                case '/':
                    binar_deyst = 4;
                    break;
                case '^':
                    binar_deyst = 5;
                    break;
            }
            
        }

        private void MakeBinarResult()
        {
            double result = 0.0; // результат вычислений
            string first_st = label1.Text;
            string second_st = textBox1.Text;
            bool is_second_double = false;
            foreach (var el in second_st)
            {
                if (Convert.ToString(el) == ",")
                {
                    is_second_double = true;
                }
            }
            if (!(is_second_double))
            {
                second_st = second_st + ",0";
            }
            double first = Convert.ToDouble(first_st);
            double second = Convert.ToDouble(second_st);
            string oper = label2.Text;
            switch (Convert.ToString(oper))
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                case "^":
                    result = Math.Pow(first, second);
                    break;
            }
            textBox2.Text = Convert.ToString(result);
        }

        private void CleanAllPushed(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            binar_deyst = 0;
            should_go_up = false;
        }

        private void EqualPushed(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            textBox1.Text = textBox2.Text;
            textBox2.Text = "";
            binar_deyst = 0;
            should_go_up = false;
        }
    }
}
