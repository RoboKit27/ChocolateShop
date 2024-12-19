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

        private void ButtonBackMain_Click(object sender, RoutedEventArgs e)
        {
            if (this.mainWindow.ScreenName != "MainScreen")
            {
                if (TextBoxSearch.Text != "")
                {
                    TextBoxSearch.Text = "";
                }
                this.mainWindow.SetScreen(new MainScreen());
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (this.mainWindow.ScreenName != "SearchScreen")
            {
                this.mainWindow.SetScreen(new SearchScreen(this));
            }
        }
    }
}
