using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = (SearchScreen)ScreensKeeper.MainWindow.ScreensStackPanel.Children[1];
            }
            catch (Exception ex)
            {
                ScreensKeeper.MainWindow.SetScreen(ScreensKeeper.SearchScreen);
            }
            ScreensKeeper.SearchScreen.Search();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = (MainScreen)ScreensKeeper.MainWindow.ScreensStackPanel.Children[1];
            }
            catch (Exception ex)
            {
                ScreensKeeper.MainWindow.SetScreen(ScreensKeeper.MainScreen);
                TextBoxSearch.Text = "";
            }
        }

        private void TextBoxSearch_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var temp = (SearchScreen)ScreensKeeper.MainWindow.ScreensStackPanel.Children[1];
            }
            catch (Exception ex)
            {
                ScreensKeeper.MainWindow.SetScreen(ScreensKeeper.SearchScreen);
            }
        }
    }
}
