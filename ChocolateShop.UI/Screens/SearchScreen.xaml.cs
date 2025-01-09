using ChocolateShop.BLL;
using ChocolateShop.Core.OutputModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {

        private ChocolateManager _chocolateManager;
        private Brush _unvisibleColor;

        public SearchScreen()
        {
            _chocolateManager = new ChocolateManager();
            InitializeComponent();
            this._unvisibleColor = LabelNotFound.Foreground;
            this.InitilizeSortFilters();
            this.LoadCompanyFilters();
            this.LoadTypeFilters();
            this.LoadCountryFilters();
            this.Search();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void InitilizeSortFilters()
        {
            var popularFilter = new FilterCheckBox("По популярности")
            {
                OnSymbol = "🔺",
                OffSymbol = "🔻"
            };
            popularFilter.Margin = new Thickness(4, 0, 0, 0);
            PopularFilterBorder.Child = popularFilter;
            popularFilter.Show();

            var costFilter = new FilterCheckBox("По цене")
            {
                OnSymbol = "🔺",
                OffSymbol = "🔻"
            };
            costFilter.Margin = new Thickness(4, 0, 0, 0);
            CostFilterBorder.Child = costFilter;
            costFilter.Show();
        }

        public void LoadCompanyFilters()
        {
            CompanyStackPanel.Children.Clear();
            CompanyStackPanel.Children.Add(new Label() { Content = "Компания", FontSize = 32, FontWeight = FontWeights.Bold });
            List<CompanyOutputModel> outputModels = this._chocolateManager.GetAllCompanies();
            foreach (CompanyOutputModel company in outputModels)
            {
                var filter = new FilterCheckBox(company.Name)
                {
                    OnSymbol = "❌"
                };
                filter.Margin = new Thickness(20, 0, 0, 2);
                CompanyStackPanel.Children.Add(filter);
            }
        }

        public void LoadTypeFilters()
        {
            ChocolateTypeStackPanel.Children.Clear();
            ChocolateTypeStackPanel.Children.Add(new Label() { Content = "Тип шоколада", FontSize = 32, FontWeight = FontWeights.Bold });
            List<TypeOutputModel> outputModels = this._chocolateManager.GetAllTypes();
            foreach (TypeOutputModel type in outputModels)
            {
                var filter = new FilterCheckBox(type.Name)
                {
                    OnSymbol = "❌"
                };
                filter.Margin = new Thickness(20, 0, 0, 2);
                ChocolateTypeStackPanel.Children.Add(filter);
            }
        }

        public void LoadCountryFilters()
        {
            CountryStackPanel.Children.Clear();
            CountryStackPanel.Children.Add(new Label() { Content = "Страна", FontSize = 32, FontWeight = FontWeights.Bold });
            List<CountryOutputModel> outputModels = this._chocolateManager.GetAllCountries();
            foreach (CountryOutputModel country in outputModels)
            {
                var filter = new FilterCheckBox(country.Name)
                {
                    OnSymbol = "❌"
                };
                filter.Margin = new Thickness(20, 0, 0, 2);
                CountryStackPanel.Children.Add(filter);
            }
        }

        public List<ChocolateOutputModel> FilterChocolatesByName(List<ChocolateOutputModel> given)
        {
            if (ScreensKeeper.SearchBar.TextBoxSearch.Text.Length > 0)
            {
                var result = new List<ChocolateOutputModel>();
                foreach (ChocolateOutputModel chocolate in given)
                {
                    if (chocolate.Name.ToLower().StartsWith(ScreensKeeper.SearchBar.TextBoxSearch.Text.ToLower()))
                    {
                        result.Add(chocolate);
                    }
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public List<ChocolateOutputModel> FilterChocolatesByCompany(List<ChocolateOutputModel> given)
        {
            var enabledCompanies = this.GetEnabledCompanyFilters();
            if (enabledCompanies.Count > 0)
            {
                var result = new List<ChocolateOutputModel>();
                foreach (ChocolateOutputModel chocolate in given)
                {
                    if (enabledCompanies.IndexOf(chocolate.Company) != -1)
                    {
                        result.Add(chocolate);
                    }
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public List<ChocolateOutputModel> FilterChocolatesByType(List<ChocolateOutputModel> given)
        {
            var enabledTypes = this.GetEnabledTypeFilters();
            if (enabledTypes.Count > 0)
            {
                var result = new List<ChocolateOutputModel>();
                foreach (ChocolateOutputModel chocolate in given)
                {
                    if (enabledTypes.IndexOf(chocolate.Type) != -1)
                    {
                        result.Add(chocolate);
                    }
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public List<ChocolateOutputModel> FilterChocolatesByCountry(List<ChocolateOutputModel> given)
        {
            var enabledCountries = this.GetEnabledCountryFilters();
            if (enabledCountries.Count > 0)
            {
                var result = new List<ChocolateOutputModel>();
                foreach (ChocolateOutputModel chocolate in given)
                {
                    if (enabledCountries.IndexOf(chocolate.Country) != -1)
                    {
                        result.Add(chocolate);
                    }
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public List<ChocolateOutputModel> FilterChocolatesByCost(List<ChocolateOutputModel> given)
        {
            if (TextBoxMinCost.Text != "" && TextBoxMaxCost.Text != "")
            {
                var result = new List<ChocolateOutputModel>();
                decimal minCost = Convert.ToDecimal(TextBoxMinCost.Text);
                decimal maxCost = Convert.ToDecimal(TextBoxMaxCost.Text);
                foreach (ChocolateOutputModel chocolate in given)
                {
                    if (chocolate.Cost >= minCost && chocolate.Cost <= maxCost)
                    {
                        result.Add(chocolate);
                    }
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public List<string> GetEnabledCompanyFilters()
        {
            var result = new List<string>();
            foreach (UIElement element in CompanyStackPanel.Children)
            {
                if (CompanyStackPanel.Children.IndexOf(element) != 0)
                {
                    var filter = (FilterCheckBox)((UserControl)element);
                    if (filter.IsEnable)
                    {
                        result.Add(filter.FilterName);
                    }
                }
            }
            return result;
        }

        public List<string> GetEnabledTypeFilters()
        {
            var result = new List<string>();
            foreach (UIElement element in ChocolateTypeStackPanel.Children)
            {
                if (ChocolateTypeStackPanel.Children.IndexOf(element) != 0)
                {
                    var filter = (FilterCheckBox)((UserControl)element);
                    if (filter.IsEnable)
                    {
                        result.Add(filter.FilterName);
                    }
                }
            }
            return result;
        }

        public List<string> GetEnabledCountryFilters()
        {
            var result = new List<string>();
            foreach (UIElement element in CountryStackPanel.Children)
            {
                if (CountryStackPanel.Children.IndexOf(element) != 0)
                {
                    var filter = (FilterCheckBox)((UserControl)element);
                    if (filter.IsEnable)
                    {
                        result.Add(filter.FilterName);
                    }
                }
            }
            return result;
        }

        public List<ChocolateOutputModel> SortLotToLittleByCost(List<ChocolateOutputModel> given)
        {
            if (CostFilterBorder.Child != null)
            {
                var result = new List<ChocolateOutputModel>();
                bool filter = ((FilterCheckBox)(UserControl)CostFilterBorder.Child).IsEnable;
                if (!filter)
                {
                    result = given.OrderByDescending(x => x.Cost).ToList();
                }
                else
                {
                    result = given.OrderBy(x => x.Cost).ToList();
                }
                return result;
            }
            else
            {
                return given;
            }
        }

        public void Search()
        {
            var result = this._chocolateManager.GetAllChocolates();
            result = this.FilterChocolatesByName(result);
            result = this.FilterChocolatesByCompany(result);
            result = this.FilterChocolatesByType(result);
            result = this.FilterChocolatesByCountry(result);
            result = this.FilterChocolatesByCost(result);
            result = this.SortLotToLittleByCost(result);
            WrapPanelChocolateCards.Children.Clear();
            if (result.Count > 0)
            {
                LabelNotFound.Foreground = this._unvisibleColor;
                foreach (ChocolateOutputModel chocolate in result)
                {
                    WrapPanelChocolateCards.Children.Add(new ProductCard(
                        chocolate.Id,
                        chocolate.Name,
                        chocolate.Cost
                    ));
                }
            }
            else
            {
                LabelNotFound.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            }
        }
    }
}
