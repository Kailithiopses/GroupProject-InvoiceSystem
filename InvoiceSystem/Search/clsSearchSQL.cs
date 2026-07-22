using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Search
{
    internal class clsSearchSQL
    {

        // This GetInvoices method has 3 optional parameters. By default, each is set to an empty string.
        // If only one of the filters needs to be applied, such as dateFilter, then you simply pass in
        // an empty string for the other two parameters, i.e. GetInvoices("", "2026-05-03", "");

        /// <summary>
        /// Conditionally returns required SQL Query string based on applied filters
        /// </summary>
        /// <param name="invoiceNumFilter"></param>
        /// <param name="dateFilter"></param>
        /// <param name="costFilter"></param>
        /// <returns></returns>
        public string GetInvoices(string invoiceNumFilter = "", string dateFilter = "", string costFilter = "")
        {
            string query = "SELECT * FROM Invoices";

            if (invoiceNumFilter != "" && dateFilter == "" && costFilter == "") // Only invoiceNumFilter
            {
                query += $" WHERE InvoiceNum = {invoiceNumFilter}";
            }
            else if (invoiceNumFilter == "" && dateFilter != "" && costFilter == "") // Only dateFilter
            {
                query += $" WHERE InvoiceDate = {dateFilter}";
            }
            else if (invoiceNumFilter == "" && dateFilter == "" && costFilter != "") // Only costFilter
            {
                query += $" WHERE TotalCost = {costFilter}";
            }
            else if (invoiceNumFilter != "" && dateFilter != "" && costFilter == "") // Only invoiceNumFilter and dateFilter 
            {
                query += $" WHERE InvoiceNum = {invoiceNumFilter} AND InvoiceDate = {dateFilter}";
            }
            else if (invoiceNumFilter != "" && dateFilter == "" && costFilter != "") // Only invoiceNumFilter and costFilter
            {
                query += $" WHERE InvoiceNum = {invoiceNumFilter} AND TotalCost = {costFilter}";
            }
            else if (invoiceNumFilter == "" && dateFilter != "" && costFilter != "") // Only dateFilter and costFilter
            {
                query += $" WHERE InvoiceDate = {dateFilter} AND TotalCost = {costFilter}";
            }
            else if (invoiceNumFilter != "" && dateFilter != "" && costFilter != "") // All three filters
            {
                query += $" WHERE InvoiceNum = {invoiceNumFilter} AND InvoiceDate = {dateFilter} AND TotalCost = {costFilter}";
            }


            return query;


        }


    }
}
