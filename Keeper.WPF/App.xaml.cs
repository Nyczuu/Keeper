﻿using System.Windows;

namespace Keeper.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Installer.Run();
        }
    }
}
