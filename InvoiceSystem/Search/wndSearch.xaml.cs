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

        // Instantiate SearchLogic class

        // Create a list of invoices populated from the data base
        public wndSearch()
        {
            InitializeComponent();
            // Populate the datagrid using the list of invoices
            // dgInvoiceDisplay.ItemsSource = InvoicesManager.GetInvoices();

            // Populate combo boxes with distinct values for each filter
        }

        /// <summary>
        /// Handle logic for cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close this window and return to main menu without setting sSelectedInvoice
        }

        /// <summary>
        /// Handle logic for clicking select invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            // This button will be disabled by default. It will only be enabled if the user
            // has selected an item from the datagrid

            // Get the selected item from the datagrid
            // sSelectedInvoice = dgInvoiceDisplay.SelectedItem
            // Close search window and return to main window
            
        }

        /// <summary>
        /// Handle logic for clicking clear filter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            // Programmatically change the selected items in all 3 combo boxes to null
            // comboBox.SelectedIndex = -1; // this should clear the selection from the box, returning null
            // Selection changed method will automatically call SQL queries to update the datagrid
        }

        /// <summary>
        /// Handle logic for when a combo box selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Call GetInvoices method, pass in the values of each combo box
            // dgInvoiceDisplay.ItemsSource = GetInvoices(cbInvoiceNumFilter.SelectedItem, cbInvoiceDateFilter.SelectedItem, cbInvoiceTotalCostFilter.SelectedItem)
        }


        // sSelectedInvoiceID - Holds the invoice ID if the user selected one, and zero if no invoice selected.
        // SelectedInvoiceID - Property main window can access to get the selected invoice ID

    }
}
