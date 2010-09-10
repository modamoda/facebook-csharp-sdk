﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Facebook.Web
{
    public class FacebookAppRedirectHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            string queryString = string.Empty;
            string pathInfo =context.Request.PathInfo;
            if (pathInfo.StartsWith("/cancel", StringComparison.Ordinal))
            {
                queryString = "cancel=1";
                pathInfo = pathInfo.Replace("/cancel", string.Empty);
            }
            var uri = new Uri("http://apps.facebook.com" + pathInfo);
            UriBuilder uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = queryString;
            context.Response.Redirect(uriBuilder.ToString());
        }
    }
}
