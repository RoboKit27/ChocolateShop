using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Windows
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

        public void SetName(string name)
        {
            //<WrapPanel Name="WrapPanelChocolateName" Margin="5 -12 0 0"/>
            ////<Label Name="LabelChocolateName" Grid.Row="1" Content="Шоколадка" Margin="5 -12 0 0" FontFamily="Cascadia Code" FontSize="20"/>
            //LabelChocolateId.Content = $"ID: {name.Length}";

            ////if (name.Length > 14)
            ////{
            ////    LabelChocolateName.FontSize = (int)(LabelChocolateName.FontSize * (0.8)); 
            ////}
            //LabelChocolateName.Content = "aaaaaaaaaaaaaa";


            //WrapPanelChocolateName.Children.Clear();
            //foreach (string word in name.Split())
            //{
            //    Thickness margin = new Thickness(0, 0, 0, 0);
            //    if (((Label)WrapPanelChocolateName.Children[WrapPanelChocolateName.Children.Count-1]).Content.Length +)
            //    {
            //        margin = new Thickness(0, -18, 0, 0);
            //    }
            //    WrapPanelChocolateName.Children.Add(new Label()
            //    {
            //        Content = word,
            //        FontSize = 20,
            //        FontFamily = new FontFamily("Cascadia Code"),
            //        Margin = margin
            //    });
            //}
        }

    }
}
