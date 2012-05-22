using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.ComponentModel;
using JuJingSdk.Common;
using Utility;
using JuJingSdk;

namespace RingtoneTrim.Views
{
    public partial class AuthorizeView : PhoneApplicationPage
    {
        public AuthorizeView()
        {
            InitializeComponent();
            this.LayoutUpdated += new EventHandler(AuthorizeView_LayoutUpdated);
        }

        void AuthorizeView_LayoutUpdated(object sender, EventArgs e)
        {
            this.LayoutUpdated -= AuthorizeView_LayoutUpdated;
            GetOauthorize();
        }

        private void GetOauthorize()
        {
            List<Parameter> paras = new List<Parameter>();
            paras.Add(new Parameter("client_id", Constants.AppKey));
            paras.Add(new Parameter("response_type", "token"));
            paras.Add(new Parameter("redirect_uri", Constants.RedirectUri));
            paras.Add(new Parameter("display", "mobile"));

            string paraString = HttpUtil.NormalizeRequestParameters(paras);
            this.AuthorizeWB.IsScriptEnabled = true;
            this.AuthorizeWB.Navigate(new Uri(string.Format("{0}?{1}", Constants.Autorizeurl, paraString), UriKind.Absolute));

            this.AuthorizeWB.Navigating += new EventHandler<NavigatingEventArgs>(AuthorizeWB_Navigating);

        }

        void AuthorizeWB_Navigating(object sender, NavigatingEventArgs e)
        {
            if (e.Uri.OriginalString.Contains("access_token")) 
            {
                List<Parameter> tokenvalues = HttpUtil.GetParameters(e.Uri.OriginalString);
                OauthKey oauthKey = new OauthKey();
                oauthKey.tokenKey = tokenvalues[0].Value;
                oauthKey.expiredTime = (TimeStamp.GetCurTimeStamp() + long.Parse(tokenvalues[1].Value)).ToString();
            }
        }

    }
}