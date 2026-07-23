using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Search
{
    internal class clsSearchLogic
    {
        // Get Distinct InvoiceNum from Invoices
        // Get distinct dates from Invoices
        // Get distinct costs from invoices

        // Use these to populate the combo boxes
        // Use the selected item in each combo box to pass
        // to SQL filter and apply the proper query

        // InvoiceManager class, will follow the same format as the FlightManager from assignment 6




        // TODO: Adapt this code to Invoices. Should return a list of all invoices, each of which will
        // have a list of clsItem objects included. Will probably need another method like this to get
        // items for a given invoice.

        /*
        
        public List<clsFlight> GetFlights()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                String sQuery = clsSQL.GetFlights();
                int iRet = 0;
                lstFlights = new List<clsFlight>();

                ds = db.ExecuteSQLStatement(sQuery, ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsFlight Flight = new clsFlight();
                    Flight.sFlightID = dr[0].ToString();
                    Flight.iFlightNumber = dr[1].ToString();
                    Flight.sAircraftType = dr[2].ToString();

                    lstFlights.Add(Flight);
                }

                return lstFlights;
            }

            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

         */

    }
}
