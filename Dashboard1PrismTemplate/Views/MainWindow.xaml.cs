﻿using Prism.Modularity;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Dashboard1PrismTemplate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IModuleManager _moduleManager;

        public MainWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
            _moduleManager = moduleManager;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _moduleManager.LoadModule("MainModule");
        }
    }

}
