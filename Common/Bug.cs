
using System;

namespace Common
{
  public class Bug
  {
    private static string query;
    public static void Delete(string bugSummary)
    {
      if (!string.IsNullOrEmpty(bugSummary))
      {
        query = "DELETE FROM bugs where short_desc = '" + bugSummary + "';" +
          "DELETE FROM bugs_fulltext where short_desc = '" + bugSummary + "';" ;

        MySQL mySql = new MySQL();
        if (!mySql.Delete(query))
          throw new Exception("DELETION FAILED: No such bug found.");
      }
     // return false;
    }
  }
}
