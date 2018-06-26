using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Users
    {
        private static string query;
        public static bool IsUserInAdminGroup(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                //string groupName = "admin";
                //query = "SELECT g.name FROM groups g JOIN user_group_map usm  ON g.id = usm.group_id JOIN profiles p ON usm.user_id = p.userid WHERE p.login_name ='"+userName +"' AND g.name = '"+groupName+"';

                StringBuilder select = new StringBuilder();
                select.Append("SELECT g.name FROM groups g JOIN user_group_map usm  ON g.id = usm.group_id JOIN profiles p ON usm.user_id = p.userid WHERE p.login_name = ").
                    Append("'").
                    Append(userName).
                    Append("'").
                    Append(" AND g.name = ").
                    Append("'").
                    Append("admin").
                    Append("'").
                    Append(";");

                query = select.ToString();

                MySQL mySql = new MySQL();

                return mySql.IsUserAdmin(query);
            }
            else
                return false;
        }
    }
}
