using System;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;

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

        public double HouseMargin
        {
            get
            {
                if (TakenIn == 0)
                {
                    return TargetMargin;
                }
                return (double)profit * 100 / takenIn;
            }
        }

        public double Delta
        {
            get
            {
                return HouseMargin - TargetMargin;
            }
        }

        public int Bias
        {
            get
            {
                if (Delta == 0)
                    return 0;
                int bias = (int)Math.Round(Math.Abs(Delta));
                if (bias > 10)
                    return 10;
                return bias;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
        }

        public string Text
        {
            get
            {
                return "\n" +
                    status + "\n" +
                    "========================================\n" +
                    "Taken In:              : " + takenIn + "\n" +
                    "Paid Out               : " + paidOut + "\n" +
                    "Profit                 : " + profit + "\n" +
                    "House Margin %         : " + string.Format("0:00.00", HouseMargin) + "\n" +
                    "Target Margin %        : " + string.Format("0:00.00", TargetMargin) + "\n" +
                    "Delta                  : " + string.Format("0:00.00", Delta) + "\n" +
                    "Bias                   : " + Bias + "\n";
            }
        }

        public override string ToString()
        {
            return Text;
        }

        public void SaveGame(string Hand, int score, int bet) //todo: up to here
        {

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
