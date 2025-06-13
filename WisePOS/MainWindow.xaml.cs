using System;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WisePOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        decimal calcValue = 0;
        decimal numOne = 0;
        decimal numTwo = 0;
        //string operation = "";
        bool isDecimal = false;
        bool hasQuantity = false;
        bool hasPrice = false;
        int decimalPlaces = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void numPadClick(object sender, RoutedEventArgs e)
        {

            if (calcDisplay.Text.Length < 11)
            {
                Button b = (Button)sender;
                if (isDecimal)
                {
                    decimalPlaces++;
                    calcValue += decimal.Parse(b.Content.ToString()) / (decimal)Math.Pow(10, decimalPlaces);
                    calcDisplay.Text = calcValue.ToString();

                }
                else
                {
                    calcValue = (calcValue * 10) + decimal.Parse(b.Content.ToString());
                    calcDisplay.Text = calcValue.ToString();
                }
            }

        }

        private void periodEntryClick(object sender, EventArgs e)
        {
            if (calcDisplay.Text.Length < 12 && isDecimal != true)
            {
                calcDisplay.Text += ".";
                isDecimal = true;
            }
        }

        // x button
        private void timesButtonClick(object sender, RoutedEventArgs e)
        {
            if (calcValue == 0)
            {
                MessageBox.Show("Please enter a price first.");
                return;
            }
            hasPrice = true;
            numOne = calcValue;
            calcDisplay.Text = "0";
            calcValue = 0;

        }


        // add button
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            numTwo = calcValue;
            calcDisplay.Text = "0";
            calcValue = 0;
            hasQuantity = true;
        }
    }
}