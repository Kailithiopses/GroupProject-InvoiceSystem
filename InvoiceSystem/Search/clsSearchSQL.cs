using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Search
{
    internal class clsSearchSQL
    {

        // This GetInvoices method has 3 optional parameters. By default, each is set to an empty string.
        // If only one of the filters needs to be applied, such as InvoiceDate, then you simply pass in
        // an empty string for the other two parameters, i.e. GetInvoices("", "2026-05-03", "");

        /// <summary>
        /// Conditionally returns required SQL Query string based on applied filters
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="InvoiceDate"></param>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        public string GetInvoices(string InvoiceNum = "", string InvoiceDate = "", string TotalCost = "")
        {
            string query = "SELECT * FROM Invoices";

            if (InvoiceNum != "" && InvoiceDate == "" && TotalCost == "") // Only InvoiceNum
            {
                query += $" WHERE InvoiceNum = {InvoiceNum}";
            }
            else if (InvoiceNum == "" && InvoiceDate != "" && TotalCost == "") // Only InvoiceDate
            {
                query += $" WHERE InvoiceDate = {InvoiceDate}";
            }
            else if (InvoiceNum == "" && InvoiceDate == "" && TotalCost != "") // Only TotalCost
            {
                query += $" WHERE TotalCost = {TotalCost}";
            }
            else if (InvoiceNum != "" && InvoiceDate != "" && TotalCost == "") // Only InvoiceNum and InvoiceDate 
            {
                query += $" WHERE InvoiceNum = {InvoiceNum} AND InvoiceDate = {InvoiceDate}";
            }
            else if (InvoiceNum != "" && InvoiceDate == "" && TotalCost != "") // Only InvoiceNum and TotalCost
            {
                query += $" WHERE InvoiceNum = {InvoiceNum} AND TotalCost = {TotalCost}";
            }
            else if (InvoiceNum == "" && InvoiceDate != "" && TotalCost != "") // Only InvoiceDate and TotalCost
            {
                query += $" WHERE InvoiceDate = {InvoiceDate} AND TotalCost = {TotalCost}";
            }
            else if (InvoiceNum != "" && InvoiceDate != "" && TotalCost != "") // All three filters
            {
                query += $" WHERE InvoiceNum = {InvoiceNum} AND InvoiceDate = {InvoiceDate} AND TotalCost = {TotalCost}";
            }


            return query;


        }


    }
}
