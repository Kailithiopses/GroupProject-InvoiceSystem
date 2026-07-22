using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceSystem.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        // Create a list of invoices populated from the data base
        public wndSearch()
        {
            InitializeComponent();
            // Populate the datagrid using the list of invoices
            // dgInvoiceDisplay.ItemsSource = InvoicesManager.GetInvoices();
        }
    }
}
