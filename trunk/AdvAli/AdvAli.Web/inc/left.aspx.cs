﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AdvAli.Web.Html.UI;

namespace AdvAli.Web.inc
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.InnerHtml = AdvAli.Web.Html.HtmlMenu.GetMenus();
        }
    }
}
