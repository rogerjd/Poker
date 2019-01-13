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

        public int TakenIn { get; }
        public int TakenOut { get; }
        public int Profit{ get; }
        public int TargetMargin { get; }

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
    }
}
