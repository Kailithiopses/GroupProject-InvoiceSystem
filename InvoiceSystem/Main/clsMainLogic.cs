using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using InvoiceSystem.Common;

namespace InvoiceSystem.Main
{
    /// <summary>
    /// Contains all business logic for the Main window (wndMain). The
    /// code-behind for wndMain.xaml calls into this class rather than
    /// executing SQL or holding logic itself.
    /// </summary>
    internal class clsMainLogic
    {
        private clsMainSQL clsSQL = new clsMainSQL();
        private clsDataAccess db = new clsDataAccess();

        // Holds the invoice currently loaded/being created in the Main window.
        // "TBD" for InvoiceNum until the invoice has been saved.
        private clsInvoice currentInvoice;

        /// <summary>
        /// Gets all items from the ItemDesc def table for populating the
        /// item drop-down box on the Main window.
        /// </summary>
        /// <returns>List of all items.</returns>
        public List<clsItem> GetAllItems()
        {
            try
            {
                List<clsItem> lstItems = new List<clsItem>();
                int iRet = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSQL.GetAllItems(), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsItem item = new clsItem();
                    item.ItemCode = dr[0].ToString();
                    item.ItemDesc = dr[1].ToString();
                    item.Cost = dr[2].ToString();
                    lstItems.Add(item);
                }

                return lstItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Loads an invoice's header and line items for read-only viewing,
        /// used after an invoice is selected on the Search window.
        ///
        /// INTERFACE COMMENT (Search -> Main):
        /// wndSearch exposes the selected invoice through a public property
        /// (matching the "SelectedInvoiceID" property already planned in
        /// wndSearch.xaml.cs), set inside btnSelectInvoice_Click right
        /// before the window closes itself. In wndMain's mnuSearchInvoice_Click,
        /// after wndSearch is shown with ShowDialog(), Main reads that
        /// property: if it's non-empty, Main calls LoadInvoice(id) here to
        /// query the header (GetInvoiceHeader) and line items
        /// (GetInvoiceLineItems), bind them to the UI, and switch to
        /// read-only mode. If the user hit Cancel the property stays
        /// empty/null and Main does nothing.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice number to load.</param>
        public clsInvoice LoadInvoice(string sInvoiceNum)
        {
            try
            {
                // TODO (final project): query GetInvoiceHeader + GetInvoiceLineItems,
                // populate a clsInvoice with its clsItem list, set currentInvoice, return it.
                return currentInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Called when the Items window closes, so Main can refresh anything
        /// that depends on the ItemDesc def table.
        ///
        /// INTERFACE COMMENT (Items -> Main):
        /// wndItems will expose a public bool property (e.g. ItemsWereModified)
        /// set to true whenever an item is added, edited, or deleted while
        /// the window is open. In wndMain's mnuUpdateItems_Click, after
        /// wndItems is shown with ShowDialog(), Main checks that flag: if
        /// true, Main calls GetAllItems() again to refresh cboItems. Note
        /// LineItems.Cost is stored independently of ItemDesc.Cost, so an
        /// edited default cost does NOT retroactively change costs already
        /// saved on an existing invoice - only the item descriptions shown
        /// need to stay current, which GetInvoiceLineItems already covers.
        /// </summary>
        public void RefreshItemsAfterItemsWindowClosed()
        {
            // Dont need but thought I would put it in here just because.
        }

        /// <summary>
        /// Adds an item selected in the combo box as a new line item on the
        /// invoice currently being created/edited, at the next LineItemNum
        /// position. Supports adding the same item multiple times.
        /// </summary>
        public void AddLineItem(string sItemCode, string sCost)
        {
            // TODO (final project): append a clsItem to currentInvoice.ItemsList
            // and recalculate the running total.
        }

        /// <summary>
        /// Removes a line item (by its grid position) from the invoice
        /// currently being created/edited and recalculates the running total.
        /// </summary>
        public void RemoveLineItem(int iLineItemNum)
        {
            // TODO (final project): remove from currentInvoice.ItemsList and
            // recalculate the running total.
        }

        /// <summary>
        /// Saves the current invoice (header + all line items). For a new
        /// invoice: inserts the header, retrieves the AutoNumber InvoiceNum
        /// via GetMaxInvoiceNumber, then inserts each line item. For an
        /// existing invoice being re-saved: clears old line items with
        /// DeleteInvoiceLineItems before re-inserting the current set.
        /// Validates that an invoice date has been entered before saving.
        /// </summary>
        public void SaveInvoice(DateTime? dInvoiceDate)
        {
            try
            {
                if (dInvoiceDate == null)
                {
                    throw new Exception("An invoice date is required before saving.");
                }

                // TODO (final project): insert/clear+reinsert line items as
                // described above, update total via UpdateInvoiceTotal, set
                // currentInvoice.InvoiceNum from GetMaxInvoiceNumber, switch
                // UI to read-only mode.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
