using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

public class MyClass
{
    [SqlFunction]
    public static int sp_Multiply(int a, int b)
    {
        return a * b;
    }
}

