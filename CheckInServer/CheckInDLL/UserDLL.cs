using CheckInModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CheckInCommon;
using System.Data;

namespace CheckInDLL
{
    public class UserDLL
    {
        public int insert(User user,out string ID) {
            string sql = @"INSERT INTO[dbo].[T_User]([UserRealName],[UserPhoneIMEI]) VALUES
           (@UserRealName ,@UserPhoneIMEI)";
            SqlParameter[]paras= new SqlParameter[] {
                new SqlParameter("UserRealName",user.RealName),
                new SqlParameter("UserPhoneIMEI",user.PhoneIMEI)
            };

            int i =SQLHelper.ExecuteSql(sql, paras);
         
            string sql1 = @"select max(ID) from T_User where UserPhoneIMEI=@UserPhoneIMEI";
            SqlParameter[] paras1 = new SqlParameter[] {
                new SqlParameter("UserPhoneIMEI",user.PhoneIMEI)
            };
            int maxID = (int)SQLHelper.GetSingle(sql1, paras1);
            ID = maxID.ToString();

            return i;
        }

        public bool isExitUser(User user,out String userRealName,out string ID) {

            string sql = @"SELECT count([ID]) as count,[UserRealName],[ID] FROM [dbo].[T_User] where [UserPhoneIMEI]=@UserPhoneIMEI group by [UserRealName],[ID]";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("UserRealName",user.RealName),
                new SqlParameter("UserPhoneIMEI",user.PhoneIMEI)
            };
            userRealName = "";
            ID = "0";
            DataSet ds = SQLHelper.Query(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                userRealName = ds.Tables[0].Rows[0]["UserRealName"].ToString();
                string count = ds.Tables[0].Rows[0]["count"].ToString();
                ID = ds.Tables[0].Rows[0]["ID"].ToString();

                if (int.Parse(count) > 0) return true;
                return false;
            }
            else {
                return false;
            }
           
           
        }


        public int getUserID(string UserPhoneIMEI) {
            string sql1 = @"select max(ID) from T_User where UserPhoneIMEI=@UserPhoneIMEI";
            SqlParameter[] paras1 = new SqlParameter[] {
                new SqlParameter("UserPhoneIMEI",UserPhoneIMEI)
            };
            object o = SQLHelper.GetSingle(sql1, paras1);
            if (o == null) return 0;
            return (int)o;
        }
    }
}
