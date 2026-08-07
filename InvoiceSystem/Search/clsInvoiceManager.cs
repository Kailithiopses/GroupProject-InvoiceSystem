using InvoiceSystem.Common;
using InvoiceSystem.Items;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace InvoiceSystem.Search
{
    internal class clsInvoiceManager
    {
        //public string InvoiceNum { get; set; }

        //public string InvoiceDate { get; set; }

        //public string TotalCost { get; set; }

        //// Hold the list of items that correspond to a particular invoice
        //public List<clsItem> ItemsList { get; set; }

        /// <summary>
        /// List of clsInvoice objects
        /// </summary>
        List<clsInvoice> lstInvoices;

        /// <summary>
        /// List of clsItem objects for an Invoice
        /// </summary>
        List<clsItem> lstItems;

        /// <summary>
        /// List of strings for InvoiceNum
        /// </summary>
        List<string> lstInvoiceNums;

        /// <summary>
        /// List of strings for InvoiceDate
        /// </summary>
        List<string> lstInvoiceDates;

        /// <summary>
        /// List of strings for TotalCost
        /// </summary>
        List<string> lstInvoiceCosts;

        /// <summary>
        /// Get a list of every InvoiceNum from Invoice database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctInvoiceNums()
        {
            try
            {
                // Data access instance and DataSet to hold query results
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();

                // Query string, int to track rows, and list to hold strings
                String sQuery = clsSearchSQL.GetDistinctIDs();
                int iRet = 0;
                lstInvoiceNums = new List<string>();

                // Execute the query, assign results to dataset
                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                // Loop through dataset, create InvoiceNum string, append to list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string InvoiceNum = dr[0].ToString();
                    lstInvoiceNums.Add(InvoiceNum);
                }

                // Return complete list of distinct Invoice Nums from database
                return lstInvoiceNums;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a list of every Invoice Date from Invoice database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctInvoiceDates()
        {
            try
            {
                // Data access instance and DataSet to hold query results
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();

                // Query string, int to track rows, and list to hold strings
                String sQuery = clsSearchSQL.GetDistinctDates();
                int iRet = 0;
                lstInvoiceDates = new List<string>();

                // Execute the query, assign results to dataset
                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                // Loop through dataset, create InvoiceDate string, append to list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string InvoiceDate = dr[0].ToString();
                    lstInvoiceDates.Add(InvoiceDate);
                }

                // Return complete list of distinct Invoice Dates from database
                return lstInvoiceDates;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a list of every Invoice Cost from Invoice database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctInvoiceCosts()
        {
            try
            {
                // Data access instance and DataSet to hold query results
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();

                // Query string, int to track rows, and list to hold strings
                String sQuery = clsSearchSQL.GetDistinctTotalCosts();
                int iRet = 0;
                lstInvoiceCosts = new List<string>();

                // Execute the query, assign results to dataset
                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                // Loop through dataset, create InvoiceCost string, append to list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string InvoiceCost = dr[0].ToString();
                    lstInvoiceCosts.Add(InvoiceCost);
                }

                // Return complete list of distinct Invoice Total Costs in database
                return lstInvoiceCosts;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the list of clsItem objects that belongs to a clsInvoice object
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetItems(string InvoiceNum)
        {
            try
            {
                // Data access instance and DataSet to hold query results
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();

                // Query string, int to track rows, and list to hold clsItem objects
                String sQuery = clsSearchSQL.GetItems(InvoiceNum);
                int iRet = 0;
                lstItems = new List<clsItem>();

                // Execute the query, assign results to dataset
                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                // Loop through dataset, create Item obj, append obj to list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsItem Item = new clsItem();

                    Item.ItemCode = dr[0].ToString();
                    Item.ItemDesc = dr[1].ToString();
                    Item.Cost = dr[2].ToString();

                    lstItems.Add(Item);
                }

                // Return full list of Items pertaining to the given Invoice
                return lstItems;

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get all invoices that match passed in filters
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="InvoiceDate"></param>
        /// <param name="InvoiceTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> GetInvoices(string InvoiceNum = null, string InvoiceDate = null, string InvoiceTotalCost = null)
        {
            try
            {
                // Data access instance and DataSet to hold query results
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();

                // Query string, int to track rows, and list to hold clsInvoice objects
                String sQuery = clsSearchSQL.GetInvoices(InvoiceNum, InvoiceDate, InvoiceTotalCost);
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();

                // Execute the query, assign results to dataset
                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                // Loop through dataset, create Invoice obj, append obj to list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsInvoice Invoice = new clsInvoice();
                    Invoice.InvoiceNum = dr[0].ToString();
                    Invoice.InvoiceDate = dr[1].ToString();
                    Invoice.TotalCost = dr[2].ToString();
                    Invoice.ItemsList = GetItems(dr[0].ToString());

                    lstInvoices.Add(Invoice);
                }
                
                // Return complete list of Invoices in database
                return lstInvoices;

            }

            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }


        }

    }
}
