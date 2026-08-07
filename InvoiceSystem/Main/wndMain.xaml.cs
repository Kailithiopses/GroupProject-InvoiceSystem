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
using InvoiceSystem.Common;
using InvoiceSystem.Search;

namespace InvoiceSystem.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        // Instantiate MainLogic class
        private clsMainLogic MainLogic = new clsMainLogic();

        wndSearch wndSearchInvoices = new wndSearch();// REMOVE THIS

        // Tracks whether an invoice is currently being created/edited, so
        // "Update Items" on the menu can be disabled while that's true
        // (per requirement: Items window only opens when not editing/entering an invoice)
        private bool isEditingInvoice = false;

        public wndMain()
        {
            InitializeComponent();

            // Populate the item combo box from the def table
            // cboItems.ItemsSource = MainLogic.GetAllItems();
        }

        // Skeleton even though we dont have another group memeber.
        /// <summary>
        /// Opens the Items window to update the ItemDesc def table.
        /// Only enabled when no invoice is being created/edited.
        /// </summary>
        private void mnuUpdateItems_Click(object sender, RoutedEventArgs e)
        {
            // Open wndItems with ShowDialog(). After it returns, check its
            // exposed "ItemsWereModified" property - if true, call
            // MainLogic.RefreshItemsAfterItemsWindowClosed() and rebind cboItems.
        }

        /// <summary>
        /// Opens the Search window so the user can find and select an invoice.
        /// </summary>
        private void mnuSearchInvoice_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new InvoiceSystem.Search.wndSearch();
            searchWindow.ShowDialog();
            // once wndSearch exposes SelectedInvoiceID, read it here and call
            // MainLogic.LoadInvoice(...) — that part can stay a TODO for now
        }

        /// <summary>
        /// Updates the read-only cost box with the selected item's default cost.
        /// </summary>
        private void cboItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // txtItemCost.Text = ((clsItem)cboItems.SelectedItem)?.Cost;
        }

        /// <summary>
        /// Adds the selected item (and entered cost) as a new line item.
        /// Allows the same item to be added more than once.
        /// </summary>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            // MainLogic.AddLineItem(selected ItemCode, txtItemCost.Text);
            // Rebind dgInvoiceItems and recalc txtTotalCost.
        }

        /// <summary>
        /// Removes the line item associated with the clicked row.
        /// </summary>
        private void btnDeleteLineItem_Click(object sender, RoutedEventArgs e)
        {
            // MainLogic.RemoveLineItem(lineItemNum of the clicked row);
            // Rebind dgInvoiceItems and recalc txtTotalCost.
        }

        /// <summary>
        /// Clears the form so the user can enter a brand new invoice.
        /// </summary>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            // Reset txtInvoiceNum to "TBD", clear dpInvoiceDate, clear
            // dgInvoiceItems, reset txtTotalCost to 0, unlock editable fields.

            // REMOVE THIS
            this.Hide();
            wndSearchInvoices.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Unlocks the currently displayed invoice for editing.
        /// </summary>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            // isEditingInvoice = true; unlock the relevant fields.
        }

        /// <summary>
        /// Saves the current invoice and switches the form to read-only mode.
        /// </summary>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            // MainLogic.SaveInvoice(dpInvoiceDate.SelectedDate);
            // Update txtInvoiceNum from the saved invoice, isEditingInvoice = false,
            // lock fields back to read-only.
        }
    }
}
