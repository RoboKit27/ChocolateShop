using ChocolateShop.BLL;
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
            StackPanelCompanyField.Children.Clear();
            List<CompanyOutputModel> outputModels = this._chocolateManager.GetAllCompanies();
            foreach (CompanyOutputModel company in outputModels)
            {
                this.AddCompanyFilter(company.Name);
            }
        }

        public void LoadTypeFilters()
        {
            StackPanelTypeField.Children.Clear();
            List<TypeOutputModel> outputModels = this._chocolateManager.GetAllTypes();
            foreach (TypeOutputModel type in outputModels)
            {
                this.AddTypeFilter(type.Name);
            }
        }

        public void LoadChocolateCards()
        {
            WrapPanelSearchChocolates.Children.Clear();
            List<ChocolateOutputModel> filteredOutputModels = this.FilteringChocolates();
            foreach (ChocolateOutputModel chocolate in filteredOutputModels)
            {
                this.AddChocolateCard(chocolate);
            }
        }

        public List<FilterCheckBox> GetCompanyEnabledFilters()
        {
            List<FilterCheckBox> result = new List<FilterCheckBox>();
            foreach (var companyFilter in StackPanelCompanyField.Children)
            {
                if (companyFilter.GetType().ToString().Split()[0] == "FilterCheckBox")
                {
                    if (((FilterCheckBox)companyFilter).IsEnable)
                    {
                        result.Add((FilterCheckBox)companyFilter);
                    }
                }
            }
            return result;
        }

        public List<ChocolateOutputModel> FilteringChocolates()
        {
            var result = this._chocolateManager.GetAllChocolates();
            if (this._searchBar.TextBoxSearch.Text.ToLower().StartsWith("id:"))
            {
                int expectedId = Convert.ToInt32(this._searchBar.TextBoxSearch.Text.ToLower().Split(":")[1]);
                foreach (ChocolateOutputModel chocolate in result)
                {
                    if (chocolate.Id != expectedId)
                    {
                        result.Remove(chocolate);
                    }
                }
            }
            else {
                if (this.GetCompanyEnabledFilters().Count != 0)
                {
                    var companyFilters = this.GetCompanyEnabledFilters();
                    foreach (ChocolateOutputModel chocolate in result)
                    {
                        foreach (FilterCheckBox companyFilter in companyFilters)
                        {
                            if (chocolate.CompanyName != companyFilter.Name)
                            {
                                result.Remove(chocolate);
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void Update()
        {
            this.LoadChocolateCards();
        }

    }
}
