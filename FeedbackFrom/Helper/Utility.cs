using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;

namespace FeedbackFrom.Helper
{
    public class Utility
    {
       
        public static string DBConnection
        {
            get
            {
                return string.Format(ConfigurationManager.ConnectionStrings["FeedbackFormConnection"].ConnectionString);
            }
        }

    }
    public static class Format
    {
        public static string ToGlobalDateTime(object data)
        {
            string dateString = string.Empty;
            try
            {
                dateString = Convert.ToDateTime(data).ToString("yyyy-MM-dd HH:mm:ssK");
            }
            catch (Exception Ex)
            {
                dateString = Ex.Message;
            }
            return dateString;
        }
        public static string ToExact(string date, string oldFormat, string newFormat)
        {
            string datetime = string.Empty;
            if (!string.IsNullOrEmpty(date))
            {
                datetime = DateTime.ParseExact(date, oldFormat, CultureInfo.InvariantCulture).ToString(newFormat);
            }
            return datetime;
        }
    }
}
