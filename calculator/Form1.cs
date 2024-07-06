using System;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        private string input = string.Empty;
        private string input2 = string.Empty; 
        private string operand1 = string.Empty;    
        private string operand2 = string.Empty;    
        private char operation;                     
        private double result = 0.0;               

        public Form1()
        {
            InitializeComponent();
            textBoxDisplay.Text = "0";
        }

        private void btnnumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            input += button.Text;
            input2 += button.Text;
            textBoxDisplay.Text = input;
            textBox1.Text = input2;
        }

        private void clear(object sender, EventArgs e)
        {
            input = string.Empty;
            input2 = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            result = 0.0;
            textBoxDisplay.Text = string.Empty;
            textBox1.Clear();
        }

        private void opretor(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operand1 = input;
            operation = button.Text[0];
            input = string.Empty;
            input2 += button.Text;
            textBox1.Text = input2;
        }

        private void equal(object sender, EventArgs e)
        {
            operand2 = input;

            double num1, num2;
            bool isValidNum1 = double.TryParse(operand1, out num1);
            bool isValidNum2 = double.TryParse(operand2, out num2);

            if (!isValidNum1 || !isValidNum2)
            {
                textBoxDisplay.Text = "Invalid number";
                return;
            }

            try
            {
                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            textBoxDisplay.Text = "Cannot divide by zero";
                            return;
                        }
                        break;
                    default:
                        textBoxDisplay.Text = "Unknown operation";
                        return;
                }

                textBoxDisplay.Text = result.ToString();
                input = result.ToString();
                input2 = result.ToString(); // Update input2 as well to reflect the result
            }
            catch (Exception ex)
            {
                textBoxDisplay.Text = $"Error: {ex.Message}";
            }
        }

        private void backone(object sender, EventArgs e)
        {
            if (input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                input2 = input2.Substring(0, input2.Length - 1);
                textBoxDisplay.Text = input;
                textBox1.Text = input2;
            }
        }
    }
}
