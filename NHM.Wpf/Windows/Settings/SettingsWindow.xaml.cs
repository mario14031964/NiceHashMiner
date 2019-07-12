﻿using System.Linq;
using NHM.Wpf.ViewModels.Settings;
using System.Windows;
using NHM.Wpf.Windows.Common;

namespace NHM.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly SettingsVM _vm;

        public SettingsWindow()
        {
            InitializeComponent();

            if (DataContext is SettingsVM vm)
                _vm = vm;
            else
            {
                _vm = new SettingsVM();
                DataContext = _vm;
            }

            WindowUtils.Translate(this);
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is SettingsContainerVM cvm)
                _vm.SelectedPageVM = cvm.Children.FirstOrDefault();
            else if (e.NewValue is SettingsBaseVM svm)
                _vm.SelectedPageVM = svm;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.Revert();
            Close();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DefaultsButton_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.SetDefaults();
        }
    }
}
