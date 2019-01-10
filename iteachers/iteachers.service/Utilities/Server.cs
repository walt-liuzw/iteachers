﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace iteachers.service.Utilities
{
    public static class Server
    {
        private static string _appDomainAppPath;
        public static string AppDomainAppPath
        {
            get
            {
                if (_appDomainAppPath == null)
                {
                    _appDomainAppPath = HttpRuntime.AppDomainAppPath;
                }
                return _appDomainAppPath;
            }
            set
            {
                _appDomainAppPath = value;
#if NETSTANDARD1_6 || NETSTANDARD2_0
                if (!_appDomainAppPath.EndsWith("\\"))
                {
                    _appDomainAppPath += "\\";
                }
#endif
            }
        }

        private static string _webRootPath;
        /// <summary>
        /// wwwroot文件夹目录（专供ASP.NET Core MVC使用）
        /// </summary>
        public static string WebRootPath
        {
            get
            {
                if (_webRootPath == null)
                {
                    _webRootPath = AppDomainAppPath;
                }
                return _webRootPath;
            }
            set { _webRootPath = value; }
        }

        public static string GetMapPath(string virtualPath)
        {
            if (virtualPath == null)
            {
                return "";
            }
            else if (virtualPath.StartsWith("~/"))
            {
                return virtualPath.Replace("~/", AppDomainAppPath).Replace("/", "\\");
            }
            else
            {
                return Path.Combine(AppDomainAppPath, virtualPath.Replace("/", "\\"));
            }
        }

        public static HttpContext HttpContext
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    HttpRequest request = new HttpRequest("Default.aspx", "http://sdk.weixin.senparc.com/default.aspx", null);
                    StringWriter sw = new StringWriter();
                    HttpResponse response = new HttpResponse(sw);
                    context = new HttpContext(request, response);
                }

                return context;
            }
        }
    }
}
