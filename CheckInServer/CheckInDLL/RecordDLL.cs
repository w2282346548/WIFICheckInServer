using CheckInCommon;
using CheckInModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInDLL
{
   public class RecordDLL
    {
        public int insertCheckInRecord(Record record)
        {
            string sql = @"INSERT INTO [dbo].[T_CheckInRecord]([UserID],[CheckInTime])VALUES(@UserID,@CheckInTime)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("UserID",record.UserID),
                new SqlParameter("CheckInTime",record.time)
            };

            int i = SQLHelper.ExecuteSql(sql, paras);

          

            return i;
        }

        public int insertCheckOutRecord(Record record)
        {
            string sql = @"INSERT INTO [dbo].[T_CheckOutRecord]([UserID],[CheckOutTime])VALUES(@UserID,@CheckOutTime)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("UserID",record.UserID),
                new SqlParameter("CheckOutTime",record.time)
            };

            int i = SQLHelper.ExecuteSql(sql, paras);



            return i;
        }
    }
}
