using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BusinessLayer
{
    public  class BLViewReceipt
    {
        public SqlDataReader ViewRecByClNmRecNoApp1(string ClNm, int RecNo, int App,DateTime from ,DateTime to)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec .ViewRecByClNmRecNoApp1(ClNm,RecNo, App,from ,to);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetRecByClNmApp1(string ClNm, int App)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetRecByClNmApp1(ClNm, App);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetNoOfTrnsTotAmtRec1(string ClNm, int App,DateTime from,DateTime to)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetNoOfTrnsTotAmtRec1(ClNm, App,from ,to );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetRecClFrmToApp1(string ClNm, int App, DateTime from, DateTime to)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetRecClFrmToApp1(ClNm, App, from, to);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public SqlDataReader getNoOfTrnsToAmtbyRecNo1(string ClNm, int RecNo, int App, DateTime from, DateTime to)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.getNoOfTrnsToAmtbyRecNo1(ClNm, RecNo, App, from, to);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader ViewRecFromToApp1(DateTime from, DateTime to, int App)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.ViewRecFromToApp1(from, to,App);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetNoOfTrnsFromToApp(DateTime from, DateTime to, int App)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetNoOfTrnsFromToApp(from,to, App );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetRecByRecNoApp(int RecNo, int App)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetRecByRecNoApp(RecNo,App);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader GetNoOfTransRecNoApp(int Recno, int App)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.GetNoOfTransRecNoApp(Recno, App);
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader getAgainstBills(string clientname, int recno,DateTime from ,DateTime to,int app)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.getAgainstBills(clientname, recno, from, to,app );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader getNoOfTransRecAgainstBills(string clientname, int recno, DateTime from, DateTime to,int app)
        {
            DLViewReceipt dlvwRec = new DLViewReceipt();
            try
            {
                SqlDataReader dr = dlvwRec.getNoOfTransRecAgainstBills(clientname, recno, from, to,app );
                return dr;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
