using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for FilterCheckBox.xaml
    /// </summary>
    public partial class FilterCheckBox : UserControl
    {

        public string Name;
        public string? OnSymbol { get; set; }
        public string? OffSymbol {  get; set; }
        public bool IsEnable = false;

        public FilterCheckBox(string name)
        {
            this.Name = name;
            this.Height = 30;
            this.Margin = new Thickness(0,0,0,2);
            InitializeComponent();
            LabelFilterName.Content = this.Name;
        }
        
        public void Show()
        {
            if (this.IsEnable)
            {
                if (this.OnSymbol != null)
                {
                    ButtonEnableFilter.Content = this.OnSymbol;
                }
                else
                {
                    ButtonEnableFilter.Content = "";
                }
            }
            else
            {
                if (this.OffSymbol != null)
                {
                    ButtonEnableFilter.Content = this.OffSymbol;
                }
                else
                {
                    ButtonEnableFilter.Content = "";
                }
            }
        }

        private void ButtonEnableFilter_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnable = !this.IsEnable;
            this.Show();
        }
    }
}
