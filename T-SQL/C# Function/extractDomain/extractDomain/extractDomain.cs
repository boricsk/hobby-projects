using System.Net.Mail;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
public class MySQLClass
{
    [SqlFunction]
    public static string extractDomain(string email)
    {
        string ret = "";
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        
        if (Regex.IsMatch(email, pattern))
        {
            var emailAddress = new MailAddress(email);
            ret = emailAddress.Host;
        }
        else
        {
            ret = "-1";
        }
        return ret;
    }
}

