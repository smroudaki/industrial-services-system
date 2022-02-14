using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Common
{
    public static class StringExtensionMethods
    {
        public static string LimitLength(string str, int maxLength)
        {
            try
            {
                if (str.Length > maxLength)
                {
                    return str.Remove(maxLength, str.Length - maxLength) + "...";
                }

                return str;
            }
            catch
            {
                return str;
            }
        }
    }
}
