using stocks_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace stocks_api.Repository
{
    public class GlobalQuotesRepository : IGlobalQuotesRepository
    {
        private string _connection;
        public GlobalQuotesRepository()
        {
            _connection = "Server=DESKTOP-L172TAI;Database=stock;User Id=STOCK;Password=STOCKAPI;";

        }

        public async Task <List<GlobalQuotes>> GetGlobalQuotes(string symbol)
        {
            GlobalQuotes global = new GlobalQuotes();
            var list = new List<GlobalQuotes>();
            try
            {
                using (var conn = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand("SELECT * FROM GLOBAL_QUOTES WHERE SYMBOL = @SYMBOL", conn))
                    {
                        command.Parameters.Add(new SqlParameter("@SYMBOL", symbol));

                        conn.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            global.symbol = dr[0].ToString();
                            global.open = Convert.ToSingle(dr[1]);
                            global.high = Convert.ToSingle(dr[2]);
                            global.low = Convert.ToSingle(dr[3]);
                            global.price = Convert.ToDecimal(dr[4]);
                            global.volume = Convert.ToDecimal(dr[5]);
                            global.latesttradingday = Convert.ToString(dr[6]);
                            global.previousclose = Convert.ToSingle(dr[7]);
                            global.change = Convert.ToSingle(dr[8]);
                            global.changepercent = Convert.ToString(dr[9]);

                            list.Add(global);
                        }
                        conn.Close();
                        return list;
                    }

                }
            }
            catch(Exception er)
            {
                Console.WriteLine("GetGlobalQuotes -", er);
                return null;
            }
        }
    }
}
