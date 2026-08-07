using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InvoiceSystem.Common;

namespace InvoiceSystem.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Private variable to hold selected invoice ID
        /// </summary>
        private string sSelectedInvoiceID;

        /// <summary>
        /// Public property to set private sSelectedInvoiceID
        /// </summary>
        public string SelectedInvoiceID 
        { 
            get { 
                return sSelectedInvoiceID; 
            }
            set
            {
                sSelectedInvoiceID = value;
            } 
        }


        /// <summary>
        /// Instance of InvoiceManager class to interact with data from database
        /// </summary>
        clsInvoiceManager InvoiceManager = new clsInvoiceManager();

        /// <summary>
        /// Constructor for search window. Populates datagrid and combo boxes
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            try
            {
                dgInvoiceDisplay.ItemsSource = InvoiceManager.GetInvoices();

                cbInvoiceNumFilter.ItemsSource = InvoiceManager.GetDistinctInvoiceNums();
                cbInvoiceDateFilter.ItemsSource = InvoiceManager.GetDistinctInvoiceDates();
                cbInvoiceTotalCostFilter.ItemsSource = InvoiceManager.GetDistinctInvoiceCosts();
            }

            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Handle logic for cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close this window and return to main menu without setting sSelectedInvoice
            SelectedInvoiceID = null;
            this.Hide();
        }

        /// <summary>
        /// Handle logic for clicking select invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected item from the datagrid
            // Close search window and return to main window
            clsInvoice selectedRow = dgInvoiceDisplay.SelectedItem as clsInvoice;
            if (selectedRow is not null)
            {
                SelectedInvoiceID = (string)selectedRow.InvoiceNum;
            }

            // Clear filters
            cbInvoiceNumFilter.SelectedIndex = -1;
            cbInvoiceDateFilter.SelectedIndex = -1;
            cbInvoiceTotalCostFilter.SelectedIndex = -1;

            this.Hide();
        }

        /// <summary>
        /// Handle logic for clicking clear filter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            // Programmatically change the selected items in all 3 combo boxes to null
            cbInvoiceNumFilter.SelectedIndex = -1;
            cbInvoiceDateFilter.SelectedIndex = -1;
            cbInvoiceTotalCostFilter.SelectedIndex = -1;
        }

        /// <summary>
        /// Handle logic for when a combo box selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Call GetInvoices method, pass in the values of each combo box
            dgInvoiceDisplay.ItemsSource = InvoiceManager.GetInvoices((string)cbInvoiceNumFilter.SelectedItem, (string)cbInvoiceDateFilter.SelectedItem, (string)cbInvoiceTotalCostFilter.SelectedItem);
        }

        /// <summary>
        /// Handle logic for user clicking a row in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgInvoiceDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable select button
            if (dgInvoiceDisplay.SelectedIndex != -1)
            {
                btnSelectInvoice.IsEnabled = true;
                // Set SelectedInvoiceID to selected item
            }
            else if (dgInvoiceDisplay.SelectedIndex == -1)
            {
                btnSelectInvoice.IsEnabled = false;
                // Set SelectedInvoiceID to null
            }
        }

        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

    }
}
