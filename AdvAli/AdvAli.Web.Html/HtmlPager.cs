using AdvAli.Common;
using AdvAli.Entity;
using System;
using System.Collections;
using System.Web;

namespace AdvAli.Web.Html
{
    public class HtmlPager
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public static int PageSize = 10;
        private static string strUrl = HttpContext.Current.Request.Url.ToString();

        public static Pager GetPager(int RecordCount)
        {
            int num2;
            int num8;
            object obj2;
            Pager pager = new Pager();
            pager.RecordCount = RecordCount;
            pager.PageSize = PageSize;
            int num = (Util.GetPageParamsAndToInt("Page") > 0) ? Util.GetPageParamsAndToInt("Page") : 1;
            pager.PageIndex = num;
            string str = "";
            int num3 = RecordCount % PageSize;
            if (num3 == 0)
            {
                num2 = RecordCount / PageSize;
            }
            else
            {
                int num4 = RecordCount / PageSize;
                num2 = num4 + 1;
            }
            pager.PageCount = num2;
            int num5 = num2 / 5;
            strUrl = HttpContext.Current.Request.Url.ToString();
            if (num5 >= 2)
            {
                int num6 = num - 5;
                int num7 = num + 4;
                if (num7 >= num2)
                {
                    num7 = num2 - 1;
                    num6 = num2 - 9;
                }
                if (num6 < 0)
                {
                    num6 = 0;
                    num7 = 9;
                }
                for (num8 = num6; num8 <= num7; num8++)
                {
                    if ((num8 + 1) == num)
                    {
                        if ((num2 == num) && (num == 1))
                        {
                            if (Util.GetPageParamsAndToInt("Page") > 0)
                            {
                                pager.FristPage = strUrl;
                                pager.LastPage = strUrl;
                                pager.ListPage = strUrl;
                                pager.NextPage = strUrl;
                            }
                            else if (GetUrlParamCount() > 0)
                            {
                                pager.FristPage = strUrl + "&Page=1";
                                pager.PrevPage = strUrl + "&Page=1";
                                pager.NextPage = strUrl + "&Page=1";
                                pager.LastPage = strUrl + "&Page=1";
                            }
                            else
                            {
                                pager.FristPage = strUrl + "?Page=1";
                                pager.PrevPage = strUrl + "?Page=1";
                                pager.NextPage = strUrl + "?Page=1";
                                pager.LastPage = strUrl + "?Page=1";
                            }
                            //str = "1";
                            str = "<a class=\"current\" href=\"javascript:void(0);\">1</a>";
                        }
                        else
                        {
                            int num9 = num8 + 1;
                            //str = string.Concat(new object[] { str, "<a class=\"current\" href=", strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)), ">", num8 + 1, "</a>" });
                            str += "<option value=\"" + strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)) + "\">第" + (num8 + 1) + "页</option>";
                            //str = str + "<span style='color:red;font-weight:bold'>" + num9.ToString() + " </span>";
                        }
                    }
                    else if (GetUrlParamCount() > 0)
                    {
                        if (Util.GetPageParamsAndToInt("Page") > 0)
                        {
                            obj2 = str;
                            //str = string.Concat(new object[] { obj2, "<a href=", strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)), ">", num8 + 1, "</a>" });
                            str = obj2 + "<option value=\"" + strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)) + "\">第" + (num8 + 1) + "页</option>";
                            if (num8 < (RecordCount + 1))
                            {
                                pager.FristPage = strUrl.Replace("Page=" + num, "Page=1");
                                if (num != 1)
                                {
                                    pager.PrevPage = strUrl.Replace("Page=" + num, "Page=" + (num - 1));
                                }
                                else
                                {
                                    pager.PrevPage = strUrl;
                                }
                                if (num != num2)
                                {
                                    pager.NextPage = strUrl.Replace("Page=" + num, "Page=" + (num + 1));
                                }
                                else
                                {
                                    pager.NextPage = strUrl;
                                }
                                pager.LastPage = strUrl.Replace("Page=" + num, "Page=" + num2);
                            }
                        }
                        else
                        {
                            obj2 = str;
                            //str = string.Concat(new object[] { obj2, "<a href=", strUrl, "&Page=", num8 + 1, ">", num8 + 1, "</a>" });
                            str = obj2 + "<option value=\"" + strUrl + "&Page=" + (num8 + 1) + "\">第" + (num8 + 1) + "页</option>";
                            if (num8 < (RecordCount + 1))
                            {
                                pager.FristPage = strUrl + "&Page=1";
                                if (num != 1)
                                {
                                    pager.PrevPage = strUrl + "&Page=" + (num - 1);
                                }
                                else
                                {
                                    pager.PrevPage = strUrl + "&Page=1";
                                }
                                if (num != num2)
                                {
                                    pager.NextPage = strUrl + "&Page=" + (num + 1);
                                }
                                else
                                {
                                    pager.NextPage = strUrl;
                                }
                                pager.LastPage = strUrl + "&Page=" + num2;
                            }
                        }
                    }
                    else
                    {
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<a href=", strUrl, "?Page=", num8 + 1, ">", num8 + 1, "</a>" });
                        str = obj2 + "<option value=\"" + strUrl + "?Page=" + (num8 + 1) + "\">第" + (num8 + 1) + "页</option>";
                        if (num8 < (RecordCount + 1))
                        {
                            pager.FristPage = strUrl + "?Page=1";
                            if (num != 1)
                            {
                                pager.PrevPage = strUrl + "?Page=" + (num - 1);
                            }
                            else
                            {
                                pager.PrevPage = strUrl + "?Page=1";
                            }
                            if (num != num2)
                            {
                                pager.NextPage = strUrl + "?Page=" + (num + 1);
                            }
                            else
                            {
                                pager.NextPage = strUrl;
                            }
                            pager.LastPage = strUrl + "?Page=" + num2;
                        }
                    }
                }
            }
            else
            {
                for (num8 = 0; num8 < num2; num8++)
                {
                    if ((num8 + 1) == num)
                    {
                        if ((num2 == num) && (num == 1))
                        {
                            if (Util.GetPageParamsAndToInt("Page") > 0)
                            {
                                pager.FristPage = strUrl;
                                pager.PrevPage = strUrl;
                                pager.NextPage = strUrl;
                                pager.LastPage = strUrl;
                            }
                            else if (GetUrlParamCount() > 0)
                            {
                                pager.FristPage = strUrl + "&Page=1";
                                pager.PrevPage = strUrl + "&Page=1";
                                pager.NextPage = strUrl + "&Page=1";
                                pager.LastPage = strUrl + "&Page=1";
                            }
                            else
                            {
                                pager.FristPage = strUrl + "?Page=1";
                                pager.PrevPage = strUrl + "?Page=1";
                                pager.NextPage = strUrl + "?Page=1";
                                pager.LastPage = strUrl + "?Page=1";
                            }
                            str = "<a class=\"current\" href=\"javascript:void(0);\">1</a>";
                        }
                        else
                        {
                            //str = string.Concat(new object[] { str, "<a class=\"current\" href=", strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)), ">", num8 + 1, "</a>" });
                            str += "<option value=\"" + strUrl.Replace("Page=" + num,"Page=" + (num8 + 1)) + "\">第" + (num8 + 1) + "页</option>";
                        }
                    }
                    else if (GetUrlParamCount() > 0)
                    {
                        if (Util.GetPageParamsAndToInt("Page") > 0)
                        {
                            obj2 = str;
                            //str = string.Concat(new object[] { obj2, "<a href=", strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)), ">", num8 + 1, "</a>" });
                            str = obj2 + "<option value=\"" + strUrl.Replace("Page=" + num, "Page=" + (num8 + 1)) + "\">第" + (num8 + 1) + "页</option>";
                            if (num8 < (RecordCount + 1))
                            {
                                pager.FristPage = strUrl.Replace("Page=" + num, "Page=1");
                                if (num != 1)
                                {
                                    pager.PrevPage = strUrl.Replace("Page=" + num, "Page=" + (num - 1));
                                }
                                else
                                {
                                    pager.PrevPage = strUrl;
                                }
                                if (num != num2)
                                {
                                    pager.NextPage = strUrl.Replace("Page=" + num, "Page=" + (num + 1));
                                }
                                else
                                {
                                    pager.NextPage = strUrl;
                                }
                                pager.LastPage = strUrl.Replace("Page=" + num, "Page=" + num2);
                            }
                        }
                        else
                        {
                            obj2 = str;
                            //str = string.Concat(new object[] { obj2, "<a href=", strUrl, "&Page=", num8 + 1, ">", num8 + 1, "</a>" });
                            str = obj2 + "<option value=\"" + strUrl + "&Page=" + (num8 + 1) + "\">第" + (num8 + 1) + "页</option>";
                            if (num8 < (RecordCount + 1))
                            {
                                pager.FristPage = strUrl + "&Page=1";
                                if (num != 1)
                                {
                                    pager.PrevPage = strUrl + "&Page=" + (num - 1);
                                }
                                else
                                {
                                    pager.PrevPage = strUrl + "&Page=1";
                                }
                                if (num != num2)
                                {
                                    pager.NextPage = strUrl + "&Page=" + (num + 1);
                                }
                                else
                                {
                                    pager.NextPage = strUrl;
                                }
                                pager.LastPage = strUrl + "&Page=" + num2;
                            }
                        }
                    }
                    else
                    {
                        obj2 = str;
                        //str = string.Concat(new object[] { obj2, "<a href=", strUrl, "?Page=", num8 + 1, ">", num8 + 1, "</a>" });
                        str = obj2 + "<option value=\"" + strUrl + "?Page=" + (num8 + 1) + "\">第" + (num8 + 1) + "页</option>";
                        if (num8 < (RecordCount + 1))
                        {
                            pager.FristPage = strUrl + "?Page=1";
                            if (num != 1)
                            {
                                pager.PrevPage = strUrl + "?Page=" + (num - 1);
                            }
                            else
                            {
                                pager.PrevPage = strUrl + "?Page=1";
                            }
                            if (num != num2)
                            {
                                pager.NextPage = strUrl + "?Page=" + (num + 1);
                            }
                            else
                            {
                                pager.NextPage = strUrl;
                            }
                            pager.LastPage = strUrl + "?Page=" + num2;
                        }
                    }
                }
            }
            pager.ListPage = str;
            if (RecordCount == 0)
            {
                //if (string.IsNullOrEmpty(str))
                //    str = "<option value=1>1</option>";
                    //str = "<a class=\"current\" href=\"javascript:void(0);\">1</a>";
                pager.FristPage = strUrl;
                pager.PrevPage = strUrl;
                pager.NextPage = strUrl;
                pager.LastPage = strUrl;
                //pager.ListPage = "<a class=\"current\" href=\"javascript:void(0);\">1</a>";
                pager.ListPage = "";
                pager.PageCount = 1;
                pager.PageIndex = 1;
                pager.PageSize = 0x10;
            }
            if (RecordCount > 0)
            {
                pager.ListPage = "";
                for (int i = 1; i <= num2; i++)
                {
                    if (num == i)
                        pager.ListPage += string.Format("<option value=\"{0}\" selected=\"selected\">第{0}页</option>", i.ToString());
                    else
                        pager.ListPage += string.Format("<option value=\"{0}\">第{0}页</option>", i.ToString());
                }
            }
            else
            {
                pager.ListPage = "";
            }
            return pager;
        }

        private static int GetUrlParamCount()
        {
            ArrayList list = new ArrayList();
            string strUrl = HtmlPager.strUrl;
            int index = strUrl.IndexOf("?");
            string[] strArray = strUrl.Substring(index + 1).Split(new char[] { '&' });
            for (int i = 0; i < strArray.Length; i++)
            {
                index = strArray[i].IndexOf("=");
                if (index > 0)
                {
                    list.Add(strArray[i].Substring(0, index));
                }
            }
            return list.Count;
        }
    }
}

