using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            btnAC.Click += BtnAC_Click;
            btnPlusMinus.Click += BtnPlusMinus_Click;
            btnPercentage.Click += BtnPercentage_Click;
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = 0;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            //When an Operation button is clicked, assign the last number to lastNumber and reset the UI 
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnMultiply)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivide)
                selectedOperator = SelectedOperator.Division;
            if (sender == btnPlus)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btnMinus)
                selectedOperator = SelectedOperator.Sustraction;
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }
}
