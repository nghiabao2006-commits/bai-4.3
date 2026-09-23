using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_4._3
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private string currentOp = string.Empty;
        private bool isNewEntry = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            // Shared handler for btn0..btn9
            Button btn = (Button)sender;
            if (isNewEntry || txtDisplay.Text == "0")
            {
                txtDisplay.Text = btn.Text;
                isNewEntry = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double parsed;
            if (double.TryParse(txtDisplay.Text, out parsed))
            {
                if (!string.IsNullOrEmpty(currentOp))
                {
                    currentValue = Calculate(currentValue, parsed, currentOp);
                    txtDisplay.Text = currentValue.ToString();
                }
                else
                {
                    currentValue = parsed;
                }
            }

            currentOp = btn.Text;
            isNewEntry = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double parsed;
            if (double.TryParse(txtDisplay.Text, out parsed) && !string.IsNullOrEmpty(currentOp))
            {
                currentValue = Calculate(currentValue, parsed, currentOp);
                txtDisplay.Text = currentValue.ToString();
                currentOp = string.Empty;
                isNewEntry = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            currentOp = string.Empty;
            isNewEntry = true;
        }

        private double Calculate(double left, double right, string op)
        {
            switch (op)
            {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/": return right == 0 ? 0 : left / right;
                default: return right;
            }
        }
    }
}
