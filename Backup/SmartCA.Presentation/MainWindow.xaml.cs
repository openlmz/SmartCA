using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using SmartCA.Presentation.Views;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using SmartCA.Infrastructure.UI;

namespace SmartCA.Presentation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void selectProjectButton_Clicked(object sender, RoutedEventArgs e)
        {
            IView view = new SelectProjectView();
            view.Show();
        }

        private void projectInformationButton_Clicked(object sender, RoutedEventArgs e)
        {
            IView view = new ProjectInformationView();
            view.Show();
        }
    }
}
