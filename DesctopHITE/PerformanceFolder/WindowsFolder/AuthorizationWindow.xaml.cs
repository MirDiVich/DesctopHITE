﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы окно перетаскивать 
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU001 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU002 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Rollup_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU003 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
