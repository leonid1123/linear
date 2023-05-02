using System;
using System.Windows.Forms;

namespace LenaerInterp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String textErr = "Ошибка!. Введены символы";
            String valueErr = "X не входит в диапазон (x0,x1)";
            String resMessage = "Расчетное значение: ";
            double result;
            double x0;
            bool x0Try = Double.TryParse(textBox1.Text, out x0);
            double y0;
            bool y0Try = Double.TryParse(textBox4.Text, out y0);
            double x1;
            bool x1Try = Double.TryParse(textBox2.Text, out x1);
            double y1;
            bool y1Try = Double.TryParse(textBox3.Text, out y1);
            double x;
            bool xTry = Double.TryParse(textBox5.Text, out x);

            bool xOK = false;
            if (x > x0 && x < x1)
            {
                xOK= true;
                valueErr = "";
            }
            else
            {
                resMessage = "";
            }
            if (x0Try && y0Try && x1Try && y1Try && xTry && xOK)
            {
                result = LI(x0, y0, x1, y1, x);
                textErr = "";
                resMessage += result.ToString();
            }
            else
            {
                resMessage = "";
            }

            label3.Text = resMessage +"\n"+textErr + "\n" + valueErr;
        }
        double LI(double _x0, double _y0, double _x1, double _y1, double _x)
        {
            return _y0 + ((_y1 - _y0) / (_x1 - _x0)) * (_x - _x0);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;
            char a;
            if (myTextBox.Text.Length > 0)
            {
                a = myTextBox.Text[myTextBox.Text.Length - 1];
                if (a == '.')
                {
                    myTextBox.Text = myTextBox.Text.Replace('.', ',');
                    myTextBox.SelectionStart = myTextBox.Text.Length;
                }
            }
        }
    }
}