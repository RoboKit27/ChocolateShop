using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {
        public SearchScreen()
        {
            InitializeComponent();
            this.AddSortFilter("По популярности");
            this.AddSortFilter("По цене");
        }

        public void AddCompanyFilter(string companyFilter)
        {
            StackPanelCompanyField.Children.Add(new FilterCheckBox(companyFilter)
            {
                OnSymbol = "❌"
            });
        }
        
        public void AddTypeFilter(string typeFilter)
        {
            StackPanelTypeField.Children.Add(new FilterCheckBox(typeFilter)
            {
                OnSymbol = "❌"
            });
        }
        
        public void AddSortFilter(string name)
        {
            var filter = new FilterCheckBox(name)
            {
                OnSymbol = "🔺",
                OffSymbol = "🔻"
            };
            if (StackPanelOtherFilters.Children.Count == 0)
            {
                filter.Margin = new(3, 0, 0, 0);
            }
            else
            {
                filter.Margin = new(-60, 0, 0, 0);
            }
            StackPanelOtherFilters.Children.Add(filter);
            filter.Show();
        }

    }
}
