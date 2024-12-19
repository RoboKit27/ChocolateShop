using ChocolateShop.Core;
using ChocolateShop.UI.Screens.RegisterMainScreens;
using System.Windows.Controls;

namespace ChocolateShop.UI.Screens
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
            this.ResetScreen();
        }

        public void ResetScreen()
        {
            GridScreen.Children.Clear();
            UserControl screen;
            if (Options.RegisteredClient)
            {
                screen = new RegisteredScreen();
            }
            else
            {
                screen = new UnregisteredScreen();
            }
            GridScreen.Children.Add(screen);
        }

    }
}
