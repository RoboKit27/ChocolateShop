using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for ProductCard.xaml
    /// </summary>
    public partial class ProductCard : UserControl
    {
        public ProductCard(int id, string name, decimal cost)
        {
            InitializeComponent();
            this.Height = 300;
            this.Width = 200;
            this.Margin = new Thickness(10);
            LabelChocolateName.Content = new AccessText()
            {
                Text = name,
                TextWrapping = TextWrapping.Wrap
            };
            LabelChocolateCost.Content = $"{cost}₽";
            LabelChocolateId.Content = $"ID: {id}";
        }
    }
}