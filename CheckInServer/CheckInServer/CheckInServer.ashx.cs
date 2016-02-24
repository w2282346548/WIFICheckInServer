using CheckInBLL;
using CheckInCommon;
using CheckInModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInServer
{
    /// <summary>
    /// CheckInServer 的摘要说明
    /// </summary>
    public class CheckInServer : IHttpHandler
    {
        private string type = string.Empty;
        private string catMac = "c4:12:f5:37:97:70";
        private PostParam param = new PostParam() { Status="",Result="",Params=""};

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            type = context.Request.Params["type"];
            switch (type)
            {
                case "1":
                    FirstUse(context);
                    break;
                case "2":
                    CheckIn(context);
                    break;
                case "3":
                    CheckOut(context);
                    break;

                default:
                    break;
            }
        
        }

        private void FirstUse(HttpContext context)
        {
            string realName = context.Request.Params["realname"];
            string phoneIMEI = context.Request.Params["phoneimei"];
            //检查数据库是否存在记录了
            User user = new User() { RealName = realName, PhoneIMEI = phoneIMEI };
            UserBLL bll = new UserBLL();
            String userRealName = string.Empty;
            string ID = "0";
            if (!bll.isExitUser(user,out userRealName,out ID))
            {
                if (bll.InsertUser(user,out ID))
                {
                    param.Status = "ok";
                    param.Result = "已经添加到本系统中";
                    user.ID = int.Parse(ID);
                    param.Params = user.RealName;
                }
            }
            else
            {
                param.Status = "err";
                param.Result = "该手机号码已经注册过";
                user.RealName = userRealName;
                user.ID = int.Parse(ID);
                param.Params = user.RealName;
                  
            }

            string result = JsonHelper.ToJson(param);
            context.Response.Write(result);

        }

        private void CheckIn(HttpContext context)
        {
            string realName = context.Request.Params["realname"];
            string phoneIMEI = context.Request.Params["phoneimei"];
            string catmacaddress= context.Request.Params["catmac"];
            string result = string.Empty;
            if (catmacaddress!=catMac)
            {
                result = "errmac";
            }
            else { 
            UserBLL bll = new UserBLL();
            int userid = bll.getUserID(phoneIMEI);
            
            Record record = new Record() { UserID = userid, time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") };

            RecordBLL rbll = new RecordBLL();
         
            try
            {
                if (rbll.insertCheckInRecord(record) > 0)
                {
                    result = "ok";
                }
            }
            catch (Exception)
            {

                result = "err";
            }
            }
            context.Response.Write(result);

        }

        private void CheckOut(HttpContext context)
        {
            string realName = context.Request.Params["realname"];
            string phoneIMEI = context.Request.Params["phoneimei"];
            string catmacaddress = context.Request.Params["catmac"];
            string result = string.Empty;
            if (catmacaddress != catMac)
            {
                result = "errmac";
            }
            else
            {
                UserBLL bll = new UserBLL();
                int userid = bll.getUserID(phoneIMEI);

                Record record = new Record() { UserID = userid, time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") };

                RecordBLL rbll = new RecordBLL();
            
                try
                {
                    if (rbll.insertCheckOutRecord(record) > 0)
                    {
                        result = "ok";
                    }
                }
                catch (Exception)
                {

                    result = "err";
                }
            }
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}