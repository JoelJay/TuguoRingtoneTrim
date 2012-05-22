using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Net;

using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;
using System.ComponentModel;

namespace Utility
{
    public class HttpUtil
    {
        //根据文件名获取文件类型
        public static string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            //string ext = Path.GetExtension(fileName).ToLower();
            //RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(ext);

            //if (registryKey != null && registryKey.GetValue("Content Type") != null)
            //{
            //    contentType = registryKey.GetValue("Content Type").ToString();
            //}

            return contentType;
        }

        //根据query String获取parameter数据
        public static List<Parameter> GetParameters(string queryString)
        {
            if (queryString.StartsWith("?"))
            {
                queryString = queryString.Remove(0, 1);
            }

            List<Parameter> result = new List<Parameter>();

            if (!string.IsNullOrEmpty(queryString))
            {
                string[] p = queryString.Split('&');
                foreach (string s in p)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(new Parameter(temp[0], temp[1]));
                        }
                    }
                }
            }

            return result;
        }

        //根据query String获取parameter数据
        public static Dictionary<string, string> GetParametersDic(string queryString)
        {
            if (queryString.StartsWith("?"))
            {
                queryString = queryString.Remove(0, 1);
            }

            Dictionary<string, string> result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(queryString))
            {
                string[] p = queryString.Split('&');
                foreach (string s in p)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result[temp[0]] = temp[1];
                        }
                    }
                }
            }

            return result;
        }

        public static string NormalizeRequestParametersAndEncodeValue(IList<Parameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            Parameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, HttpUtility.UrlEncode(p.Value));
            }

            return sb.ToString();
        }

        public static string GetPostData(IList<Parameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            Parameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, HttpUtility.UrlEncode(p.Value));

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        public static string NormalizeRequestParameters(IList<Parameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            Parameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
    }

}
