using System.Globalization;
using System.Runtime.CompilerServices;

namespace SplitTheBill
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int noPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }
        private void CalculateTotal()
        {
            // Caculate Tip Amount
            var totaltip = (bill * tip) / 100;

            //Tip By Person
            var tipbyperson = (totaltip / noPersons);
            lblTipByPerson.Text = string.Format(new CultureInfo("en-GB"), "{0:C}", tipbyperson);

            //Subtotal
            var subtotal = (bill / noPersons);
            lblSubtotal.Text = string.Format(new CultureInfo("en-GB"), "{0:C}", subtotal);

            // Total to be paid by each person
            var totaleach = (bill + totaltip) / noPersons;
            lblTotal.Text = string.Format(new CultureInfo("en-GB"), "{0:C}", totaleach);
        }


        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%",""));
                sldTip.Value = percentage;
            }
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip} %";
            CalculateTotal();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
            {
                noPersons--;
            }
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
             noPersons++;
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal() ;
        }
    }

}
