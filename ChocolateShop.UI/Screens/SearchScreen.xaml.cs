using ChocolateShop.BLL;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;
using ChocolateShop.UI.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {

        private ChocolateManager _chocolateManager;
        private SearchBar _searchBar;

        public SearchScreen(SearchBar searchBar)
        {
            this._chocolateManager = new ChocolateManager();
            InitializeComponent();
            this._searchBar = searchBar;
            this.AddSortFilter("По популярности");
            this.AddSortFilter("По цене");
            this.LoadCompanyFilters();
            this.LoadTypeFilters();
            this.LoadChocolateCards();
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

        public void AddChocolateCard(ChocolateOutputModel chocolate)
        {
            WrapPanelSearchChocolates.Children.Add(new ProductCard(chocolate.Id, chocolate.Name, chocolate.Cost));
        }

        public void LoadCompanyFilters()
        {
            List<CompanyOutputModel> outputModels = this._chocolateManager.GetAllCompanies();
            foreach (CompanyOutputModel company in outputModels)
            {
                this.AddCompanyFilter(company.Name);
            }
        }

        public void LoadTypeFilters()
        {
            List<TypeOutputModel> outputModels = this._chocolateManager.GetAllTypes();
            foreach (TypeOutputModel type in outputModels)
            {
                this.AddTypeFilter(type.Name);
            }
        }

        public void LoadChocolateCards()
        {
            List<ChocolateOutputModel> outputModels = this._chocolateManager.GetAllChocolates();
            List<ChocolateOutputModel> filteredOutputModels = this.FilteringChocolates(outputModels);
            foreach (ChocolateOutputModel chocolate in outputModels)
            {
                this.AddChocolateCard(chocolate);
            }
        }

        public List<ChocolateOutputModel> FilteringChocolates(List<ChocolateOutputModel> allChocolates)
        {
            var result = new List<ChocolateOutputModel>();
            if (this._searchBar.TextBoxSearch.Text.ToLower().StartsWith("id:"))
            {
                int expectedId = Convert.ToInt32(this._searchBar.TextBoxSearch.Text.ToLower().Split(":")[1]);
                foreach (ChocolateOutputModel chocolate in allChocolates)
                {
                    if (chocolate.Id == expectedId)
                    {
                        result.Add(chocolate);
                    }
                }
            }
            return result;
        }

    }
}
