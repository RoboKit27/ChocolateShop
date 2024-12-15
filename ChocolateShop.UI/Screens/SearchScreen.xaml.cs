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
            this.AddPopularFilter();
            this.AddCostFilter();
        }

        public void AddCompanyFilter(string companyFilter)
        {
            StackPanelCompanyFilters.Children.Add(new FilterCheckBox(companyFilter)
            {
                OnSymbol="❌"
            });
        }
        public void AddTypeFilter(string typeFilter)
        {
            StackPanelTypeFilters.Children.Add(new FilterCheckBox(typeFilter)
            {
                OnSymbol = "❌"
            });
        }
        public void AddPopularFilter()
        {
            var filter = new FilterCheckBox("По популярности")
            {
                OnSymbol = "🔺",
                OffSymbol = "🔻"
            };
            StackPanelOtherFilters.Children.Add(filter);
            filter.Show();
        }
        public void AddCostFilter()
        {
            var filter = new FilterCheckBox("По цене")
            {
                OnSymbol = "🔺",
                OffSymbol = "🔻"
            };
            StackPanelOtherFilters.Children.Add(filter);
            filter.Show();
        }

    }
}
