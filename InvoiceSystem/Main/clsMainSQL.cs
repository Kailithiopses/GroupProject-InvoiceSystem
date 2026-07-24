using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InvoiceSystem.Main
{
    /// <summary>
    /// Contains all SQL statements needed by the Main window (wndMain).
    /// This class holds SQL only - no business logic.
    /// Schema: Invoices (InvoiceNum [AutoNumber], InvoiceDate, TotalCost),
    /// ItemDesc (ItemCode, ItemDesc, Cost), LineItems (InvoiceNum, LineItemNum, ItemCode, Cost)
    /// </summary>
    internal class clsMainSQL
    {
        /// <summary>
        /// Gets all items from the ItemDesc def table, ordered by description,
        /// used to populate the item drop-down box.
        /// </summary>
        /// <returns>SQL statement to select all items.</returns>
        public string GetAllItems()
        {
            try
            {
                return "select ItemCode, ItemDesc, Cost from ItemDesc order by ItemDesc";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the description and default cost for a single item, used when
        /// an item is selected in the drop-down to populate the read-only cost box.
        /// </summary>
        /// <param name="sItemCode">The code of the selected item.</param>
        /// <returns>SQL statement to select one item's data.</returns>
        public string GetItemByCode(string sItemCode)
        {
            try
            {
                return $"select ItemCode, ItemDesc, Cost from ItemDesc where ItemCode = '{sItemCode}'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new invoice header row. InvoiceNum is an AutoNumber in
        /// Access, so it is never included - it must be retrieved afterward
        /// with GetMaxInvoiceNumber.
        /// </summary>
        /// <param name="sInvoiceDate">The invoice date, formatted as M/d/yyyy.</param>
        /// <returns>SQL statement to insert a new invoice.</returns>
        public string InsertInvoice(string sInvoiceDate)
        {
            try
            {
                return $"INSERT INTO Invoices (InvoiceDate, TotalCost) Values (#{sInvoiceDate}#, 0)";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the max InvoiceNum from the Invoices table. Called immediately
        /// after InsertInvoice to retrieve the AutoNumber value Access generated.
        /// </summary>
        /// <returns>SQL statement to select the max invoice number.</returns>
        public string GetMaxInvoiceNumber()
        {
            try
            {
                return "SELECT MAX(InvoiceNum) FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the invoice header (number, date, total) for a single invoice,
        /// used when loading an invoice selected from Search.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice number to retrieve.</param>
        /// <returns>SQL statement to select one invoice's header data.</returns>
        public string GetInvoiceHeader(string sInvoiceNum)
        {
            try
            {
                return $"SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = {sInvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a single line item onto an invoice. LineItemNum tracks the
        /// item's position in the grid. Cost is stored per line (not looked up
        /// from ItemDesc later) because the user can change the cost per invoice.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice this item belongs to.</param>
        /// <param name="iLineItemNum">The position of this item in the grid.</param>
        /// <param name="sItemCode">The item being added.</param>
        /// <param name="sCost">The cost for this line item.</param>
        /// <returns>SQL statement to insert an invoice line item.</returns>
        public string InsertLineItem(string sInvoiceNum, int iLineItemNum, string sItemCode, string sCost)
        {
            try
            {
                return $"INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode, Cost) Values ({sInvoiceNum}, {iLineItemNum}, '{sItemCode}', {sCost})";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes all line items for an invoice. Used before re-inserting the
        /// current set of line items when an existing invoice is edited and re-saved.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice whose line items should be cleared.</param>
        /// <returns>SQL statement to delete all line items for an invoice.</returns>
        public string DeleteInvoiceLineItems(string sInvoiceNum)
        {
            try
            {
                return $"DELETE FROM LineItems WHERE InvoiceNum = {sInvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all line items for a given invoice, joined with ItemDesc for
        /// the description, for display in the DataGrid.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice to retrieve line items for.</param>
        /// <returns>SQL statement to select all line items for an invoice.</returns>
        public string GetInvoiceLineItems(string sInvoiceNum)
        {
            try
            {
                return "SELECT LineItems.LineItemNum, LineItems.ItemCode, ItemDesc.ItemDesc, LineItems.Cost " +
                       "FROM LineItems, ItemDesc " +
                       $"WHERE LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = {sInvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the TotalCost on the invoice header after items are added,
        /// removed, or the invoice is saved.
        /// </summary>
        /// <param name="sInvoiceNum">The invoice to update.</param>
        /// <param name="sTotalCost">The new total cost.</param>
        /// <returns>SQL statement to update the invoice total.</returns>
        public string UpdateInvoiceTotal(string sInvoiceNum, string sTotalCost)
        {
            try
            {
                return $"UPDATE Invoices SET TotalCost = {sTotalCost} WHERE InvoiceNum = {sInvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
