using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {

        public MainWindow mainWindow {  get; set; }

        public SearchBar(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text != "Search..." && this.mainWindow.ScreenName != "SearchScreen")
            {
                this.mainWindow.SetScreen(new SearchScreen());
            }
        }
        private void ButtonBackMain_Click(object sender, RoutedEventArgs e)
        {
            if (this.mainWindow.ScreenName != "MainScreen")
            {
                this.mainWindow.SetScreen(new MainScreen());
                if (TextBoxSearch.Text != "Search...")
                {
                    TextBoxSearch.Text = "Search...";
                }
            }
        }
    }
}
