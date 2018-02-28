using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Sanatorium.Helper
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if(string.IsNullOrEmpty(input))
            {
                return "";
            }
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

        /// <summary>
        /// 过滤字符串中的html代码
        /// </summary>
        public static string LostHTML(this HtmlHelper helper, string Str)
        {
            string Re_Str = "";
            if (!string.IsNullOrEmpty(Str))
            {
                if (Str != string.Empty)
                {
                    string Pattern = "<\\/*[^<>]*>";
                    Re_Str = Regex.Replace(Str, Pattern, "");
                }
            }
            //return Re_Str.Replace("&nbsp;", "");
            return (Re_Str.Replace("\\r\\n", "")).Replace("\\r", "").Replace("&nbsp;", "").Replace("&emsp;","");
        }

    }
}