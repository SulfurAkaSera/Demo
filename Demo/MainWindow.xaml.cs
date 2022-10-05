using System;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using Demo.ViewModel;
using Demo.Model;
using Demo.Service;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataService dataService;
        public MainWindow()
        {
            InitializeComponent();
            dataService = new DataService(false);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           dataService.ConnectionDispose();
        }
    }
}
