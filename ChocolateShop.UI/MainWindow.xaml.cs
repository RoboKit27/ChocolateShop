using ChocolateShop.UI.Screens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChocolateShop.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string ScreenName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.SetSearchBar(new SearchBar(this));
            this.SetScreen(new MainScreen());
        }

        public void SetSearchBar(UserControl bar)
        {
            Grid.SetRow(bar, 0);
            GridScreens.Children.Add(bar);
        }

        public void SetScreen(UserControl screen)
        {
            List<string> newScreenName = screen.GetType().ToString().Split(".").ToList();
            this.ScreenName = newScreenName[newScreenName.Count - 1];
            Grid.SetRow(screen, 1);
            GridScreens.Children.Add(screen);
        }
    }
}