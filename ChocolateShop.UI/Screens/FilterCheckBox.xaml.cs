using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for FilterCheckBox.xaml
    /// </summary>
    public partial class FilterCheckBox : UserControl
    {

        public string FilterName { get; set; }
        public string? OnSymbol { get; set; }
        public string? OffSymbol {  get; set; }
        public bool IsEnable = false;
        public bool IsDisable = false;

        public FilterCheckBox(string filterName)
        {
            this.FilterName = filterName;
            this.Height = 30;
            this.Margin = new Thickness(0,0,0,2);
            InitializeComponent();
            LabelFilterName.Content = this.FilterName;
        }
        
        public void Disable()
        {
            this.IsDisable = true;
            LabelFilterName.Foreground = Brushes.Gray;
        }

        public void Enable()
        {
            this.IsDisable = false;
            LabelFilterName.Foreground = Brushes.Black;
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
            if (!this.IsDisable)
            {
                this.IsEnable = !this.IsEnable;
                this.Show();
            }
        }
    }
}
