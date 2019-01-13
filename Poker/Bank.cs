using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Bank
    {
        private string connectString;
        string status;

        public int TakenIn { get { return takenIn; } }
        public int PaidOut { get { return paidOut; } }
        public int Profit { get { return Profit; } }
        public readonly int TargetMargin;

        public Bank()
        {
            SetConnectString();
            TargetMargin = GetParm("TargetMargin", 25);
            Refresh();
        }

        private void Refresh()
        {
            if (connectString == "")
                return;
            string sql = "select" +
                            "sum(bet) as taken_in " +
                            "sum(score * bet) as paid_out " +
                            "sum(bet) - sum(score * bet) as profit " +
                            "from games";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectString);
            try
            {
                sda = new SqlDataAdapter(sql, connectString);
                DataSet ds = new DataSet("PokerProfit");
                sda.Fill(ds, "stats");
                DataRow dr = ds.Tables[0].Rows[0];
                takenIn = (int)dr[0];
                paidOut = (int)dr[1];
                profit = (int)dr[2];
                status = "Machine Stats all (All Players)";
            }
            catch (Exception e)
            {
                new MsgLog($"Bank.Refresh() : {e.Message}");
            }
        }

        private int GetParm(string parmName, int defaultValue)
        {
            int parmValue = defaultValue;

            string sql = "select value from integers where name = '" + parmName + "' ";
            DataSet ds = new DataSet("PokerParm");
            SqlDataAdapter sda = new SqlDataAdapter(sql, connectString);
            try
            {
                sda.Fill(ds, "result");
                parmValue = (int)ds.Tables["result"].Rows[0][0];
            }
            catch (Exception e)
            {
                connectString = "";
                new MsgLog($"Bank.GetParm(): {e.Message}");
            }

            return parmValue;
        }

        private void SetConnectString()
        {
            connectString = ConfigurationManager.AppSettings["dsn"];
            if (connectString == null)
                connectString = "";
            if (connectString == "")
            {
                connectString = @"server=(localdb)\MSSQLLocalDB;database=poker";
            }
        }

        int takenIn = 0;
        int paidOut = 0;
        int profit = 0;
    }
}
