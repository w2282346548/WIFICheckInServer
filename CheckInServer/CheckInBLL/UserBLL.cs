using CheckInDLL;
using CheckInModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInBLL
{
  
   public class UserBLL
    {
        private UserDLL dll = new UserDLL();

        public bool InsertUser( User user,out string id) {
           int i= dll.insert( user,out id);
            if (i > 0)
                return true;
            return false;
        }
        public bool isExitUser(User user,out String UserRealName,out String ID) {
            return dll.isExitUser(user,out UserRealName,out ID);
        }

        public int getUserID(String phoneIMEI) {
            return dll.getUserID(phoneIMEI);
        }

    }
}
