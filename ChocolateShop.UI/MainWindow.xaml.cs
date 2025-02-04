﻿using ChocolateShop.UI.Screens;
using System.Windows;
using System.Windows.Controls;

namespace ChocolateShop.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetConfig();
            this.SetScreen(ScreensKeeper.MainScreen);
        }

        public void SetScreen(UserControl screen)
        {
            ScreensStackPanel.Children.Clear();
            ScreensStackPanel.Children.Add(ScreensKeeper.SearchBar);
            ScreensStackPanel.Children.Add(screen);
        }

        public void SetConfig()
        {
            ScreensKeeper.MainWindow = this;
            ScreensKeeper.SearchBar.Width = 1920;
            ScreensKeeper.SearchBar.Height = 50;
            ScreensKeeper.SearchScreen.Width = 1920;
            ScreensKeeper.SearchScreen.Height = 966;
            ScreensKeeper.MainScreen.Width = 1920;
            ScreensKeeper.MainScreen.Height = 966;
        }
    }
}
