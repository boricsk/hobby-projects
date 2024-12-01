using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SnippetStore.RegistryClass
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

        public static string ReadConStringLocal()
        {
            string conString = "";
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SnippetStore"))
            {
                if (key != null)
                {
                    var value = key.GetValue("MongoConStringLocal");
                    if (value != null)
                    {
                        conString = value.ToString() ?? "";
                    }
                }
            }
            return conString;
        }

        public static void WriteConStringLocal(string conString)
        {
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                key?.SetValue("MongoConStringLocal", conString);
            }
        }

        public static void WriteDatabaseOption(bool isLocal)
        {
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                key?.SetValue("isUseLocalDb", isLocal);
            }
        }

        public static bool ReadDatabaseOption()
        {
            bool ret = false;
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                object? isLocalDb = key.GetValue("isUseLocalDb");
                if (key != null)
                {
                    if (isLocalDb != null) { ret = Convert.ToBoolean(isLocalDb); }
                }
            }
            return ret;
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

        public static void WriteSearchOptions(bool[] options)
        {
            using (RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetStore"))
            {
                //_searchOptions[0] = cbCodeSnip.Checked;
                //_searchOptions[1] = cbDesc.Checked;
                //_searchOptions[2] = cbKeyw.Checked;
                //_searchOptions[3] = cbSnipName.Checked;

                key?.SetValue("In Code Snippets", options[0]);
                key?.SetValue("In Descriptions", options[1]);
                key?.SetValue("In Keywords", options[2]);
                key?.SetValue("In Snippet name", options[3]);
            }
        }

        public static bool[] ReadSearchOptions()
        {
            bool[] options = new bool[4];
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SnippetStore"))
            {
                if (key != null)
                {
                    object? inCodeSnip = key.GetValue("In Code Snippets");
                    object? inDesc = key.GetValue("In Descriptions");
                    object? inKeyword = key.GetValue("In Keywords");
                    object? inSnipName = key.GetValue("In Snippet name");

                    if (inCodeSnip != null) { options[0] = Convert.ToBoolean(inCodeSnip); } else { options[0] = true; }
                    if (inDesc != null) { options[1] = Convert.ToBoolean(inDesc); } else { options[1] = true; }
                    if (inKeyword != null) { options[2] = Convert.ToBoolean(inKeyword); } else { options[2] = true; }
                    if (inSnipName != null) { options[3] = Convert.ToBoolean(inSnipName); } else { options[3] = true; }
                }
            }
            return options;
        }
    }
}
