using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SnippetStore
{
    public static class RegistryOps
    {
        public static string ReadConString()
        {
            string conString = "";
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SnippetStore"))
            {
                if (key != null)
                {
                    var value = key.GetValue("MongoConString");
                    if (value != null)
                    {
                        conString = value.ToString() ?? "";
                    }
                }
            }
            return conString;
        }

        public static void WriteConString(string conString)
        {
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                key?.SetValue("MongoConString", conString);
            }
        }

        public static void WriteResWordColor(Color resWordColor)
        {
            var color = resWordColor.ToArgb();
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                key?.SetValue("ResWordColor", color);
            }
        }

        public static void WriteBlockSepColor(Color blockSepColor)
        {
            var color = blockSepColor.ToArgb();
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                key?.SetValue("BlockSepColor", color);
            }
        }

        public static Color ReadBlockSepColor()
        {
            Color color = Color.Black;
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SnippetStore"))
            {
                if (key != null)
                {
                    object? value = key.GetValue("BlockSepColor");
                    if (value != null)
                    {
                        color = Color.FromArgb((int)value);
                    }
                }
            }
            return color;
        }

        public static Color ReadResWordColor()
        {
            Color color = Color.Black;
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SnippetStore"))
            {
                if (key != null)
                {
                    object? value = key.GetValue("ResWordColor");
                    if (value != null)
                    {
                        color = Color.FromArgb((int)value);
                    }
                }
            }
            return color;
        }
    }
}
