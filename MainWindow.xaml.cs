using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
{

    public partial class MainWindow : Window
    {
        float a, b;
        int count;
        bool znak = true;
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)  //объект на основе класса UIEl, перебираем список Mainroot
            {
                if (el is Button) //относится ли объект эл объектом на основе класса button
                {
                    ((Button)el).Click += Button_Click;  //преобразовываем к классу button
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content; //получаем текст с нажатой кнопки

            if (str == "C")
                textLabel.Text = "";
            else if (str == "+")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 1;
                textLabel2.Text = a.ToString() + "+";
                znak = true;
            }
            else if (str == "-")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 2;
                textLabel2.Text = a.ToString() + "-";
                znak = true;
            }
            else if (str == "*")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 3;
                textLabel2.Text = a.ToString() + "*";
                znak = true;
            }
            else if (str == "/")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 4;
                textLabel2.Text = a.ToString() + "/";
                znak = true;
            }
            else if (str == "x²")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 6;
                textLabel2.Text = a.ToString() + "^2";
                znak = true;
            }
            else if (str == "√")
            {
                a = float.Parse(textLabel.Text);
                textLabel.Clear();
                count = 5;
                textLabel2.Text = "√" + a.ToString();
                znak = true;
            }
            else if (str == "=")
            {
                calculate();
                textLabel2.Text = "";
            }
            else if (str == "±")
            {
                if (znak == true)
                {
                    textLabel.Text = "-" + textLabel.Text;
                    znak = false;
                }
                else if (znak == false)
                {
                    textLabel.Text = textLabel.Text.Replace("-", "");
                    znak = true;
                }
            }
            else
                textLabel.Text += str;
        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textLabel.Text);
                    textLabel.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textLabel.Text);
                    textLabel.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textLabel.Text);
                    textLabel.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(textLabel.Text);
                    textLabel.Text = b.ToString();
                    break;
                case 5:
                    b = (float)Math.Sqrt(a);
                    textLabel.Text = b.ToString();
                    break;
                case 6:
                    b = (float)Math.Pow(a, 2);
                    textLabel.Text = b.ToString();
                    break;
                default:
                    break;
            }

        }

    }
}