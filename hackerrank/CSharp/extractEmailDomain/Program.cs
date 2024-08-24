using System;
using System.Net.Mail;

static bool isCorrectEmail(string email)
{
    bool ret = false;
    try
    {
        var emailAddress = new MailAddress(email);
        ret = true;
    }
    catch (FormatException) { ret = false; }
    
    return ret;
}

static string extractDomain(string email)
{
    string ret = "";
    var emailAddress = new MailAddress(email);
    if (isCorrectEmail(email)) 
    {
        ret = emailAddress.Host;
    } else 
    {
        ret = "-1"; 
    }
    return ret;
}

Console.WriteLine(extractDomain("borics.krisztian@baba.eu"));