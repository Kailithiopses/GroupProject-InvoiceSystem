using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InvoiceSystem.Search
{
    internal class clsSearchSQL
    {

        // This GetInvoices method has 3 optional parameters. By default, each is set to null.
        // If only one of the filters needs to be applied, such as InvoiceDate, then you simply pass in
        // null for the other two parameters, i.e. GetInvoices(null, "2026-05-03", null);

        /// <summary>
        /// Conditionally returns required SQL Query string based on applied filters
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="InvoiceDate"></param>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        public string GetInvoices(string InvoiceNum = null, string InvoiceDate = null, string TotalCost = null)
        {
            try
            {
                string query = "SELECT * FROM Invoices";

                if (InvoiceNum is not null && InvoiceDate is null && TotalCost is null) // Only InvoiceNum
                {
                    query += $" WHERE InvoiceNum = {InvoiceNum}";
                }
                else if (InvoiceNum is null && InvoiceDate is not null && TotalCost is null) // Only InvoiceDate
                {
                    query += $" WHERE InvoiceDate = {InvoiceDate}";
                }
                else if (InvoiceNum is null && InvoiceDate is null && TotalCost is not null) // Only TotalCost
                {
                    query += $" WHERE TotalCost = {TotalCost}";
                }
                else if (InvoiceNum is not null && InvoiceDate is not null && TotalCost is null) // Only InvoiceNum and InvoiceDate 
                {
                    query += $" WHERE InvoiceNum = {InvoiceNum} AND InvoiceDate = {InvoiceDate}";
                }
                else if (InvoiceNum is not null && InvoiceDate is null && TotalCost is not null) // Only InvoiceNum and TotalCost
                {
                    query += $" WHERE InvoiceNum = {InvoiceNum} AND TotalCost = {TotalCost}";
                }
                else if (InvoiceNum is null && InvoiceDate is not null && TotalCost is not null) // Only InvoiceDate and TotalCost
                {
                    query += $" WHERE InvoiceDate = {InvoiceDate} AND TotalCost = {TotalCost}";
                }
                else if (InvoiceNum is not null && InvoiceDate is not null && TotalCost is not null) // All three filters
                {
                    query += $" WHERE InvoiceNum = {InvoiceNum} AND InvoiceDate = {InvoiceDate} AND TotalCost = {TotalCost}";
                }


                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Return all unique Invoice IDs
        /// </summary>
        /// <returns></returns>
        public string GetDistinctIDs()
        {
            try
            {
                return "SELECT DISTINCT InvoiceNum FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Return all unique Invoice Dates
        /// </summary>
        /// <returns></returns>
        public string GetDistinctDates()
        {
            try
            {
                return "SELECT DISTINCT InvoiceDate FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Return all unique Invoice total costs
        /// </summary>
        /// <returns></returns>
        public string GetDistinctTotalCosts()
        {
            try
            {
                return "SELECT DISTINCT TotalCost FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Return all items for a given invoice
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public string GetItems(string InvoiceNum)
        {
            try
            {
                return $"SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc" +
                       $"WHERE LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = {InvoiceNum}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
