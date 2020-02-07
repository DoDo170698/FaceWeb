using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.CodeLogic
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageTotal { get; set; }
        public int PageCount { get; set; }
        public int PageStart { get; set; }
        public string Target { get; set; }
        public int Total { get; set; }
        public string Param { get; set; }
        public HtmlString Render(string target ="",string param ="")
        {
            Target = target;
            var html = "";
            if (Total>PageSize)
            {
                html = "<div class='dataTables_paginate paging_bootstrap'>"
                     + "<div class='btn-group dropup'>"
                     + "<a href='#' data-toggle='dropdown' class='btn btn-sm btn-default dropdown-toggle' aria-expanded='false'>" + PageSize + "<i class='fa fa-angle-down'></i></a>"
                     + "<ul class='dropdown-menu dropdown-blue dropdown-menu-right'>"
                     + "<li><a href='?page=" + PageIndex + "&amp;np=10'>10</a></li>"
                     + "<li><a href='?page=" + PageIndex + "&amp;np=20'>20</a></li>"
                     + "<li><a href='?page=" + PageIndex + "&amp;np=30'>30</a></li>"
                     + "</ul>"
                     + "</div>"
                     + "<ul class='pagination'>"
                     + "<li class=''><a data-index='" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "&np=" + PageSize + param + "' class='first " + ((PageIndex - 2) < 1 ? "not-allow" : string.Empty) + "'>«</a></li>"
                     + "<li class=''><a data-index='" + ((PageSize - 1) > 1 ? (PageSize - 1) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 1) > 1 ? (PageIndex - 1) : 1) + "&np=" + PageSize +param +"' class='prev " + ((PageIndex - 1) < 1 ? "not-allow" : string.Empty) + "'><i class='fa fa-angle-left'></i></a></li>";
                for (int i = 1; i <= PageTotal; i++)
                {
                    var active = i == PageIndex ? "active" : "";
                    html += "<li class='" + active + "'><a data-index='" + i + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + i + "&np=" + PageSize + param + "' class='prev quickView disabled  current'>" + i + "</a></li>";
                };
                html = html
                           + "<li class=''><a data-index='" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "&np=" + PageSize + param + "' class='next prev quickView  " + (PageIndex + 1 > PageTotal ? "not-allow" : string.Empty) + "' ><i class='fa fa-angle-right'></i></a></li>"
                           + "<li class=''><a data-index='" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "&np=" + PageSize + param + "' class='last prev quickView " + (PageIndex + 2 > PageTotal ? "not-allow" : string.Empty) + " '>»</a></li>"
                           + "</ul>"
                           + "</div>";
            }
            return MvcHtmlString.Create(html);
        }


        public HtmlString RenderAdmin(string target = "", string param = "")
        {
            Target = target;
            var html = "";
            if (Total > PageSize)
            {
                html = "<div class='dataTables_paginate paging_bootstrap'>"
                     + "<div class='btn-group dropup'>"
                     + "<a href='#' data-toggle='dropdown' class='btn btn-sm btn-default dropdown-toggle' aria-expanded='false'>" + PageSize + "<i class='fa fa-angle-down'></i></a>"
                     + "<ul class='dropdown-menu dropdown-blue dropdown-menu-right'>"
                     + "<li><a href='?page=1&amp;np=10'>10</a></li>"
                     + "<li><a href='?page=1&amp;np=20'>20</a></li>"
                     + "<li><a href='?page=1&amp;np=30'>30</a></li>"
                     + "</ul>"
                     + "</div>"
                     + "<ul class='pagination'>"
                     + "<li class=''><a data-index='" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "&np=" + PageSize + param + "' class='first " + ((PageIndex - 2) < 0 ? "not-allow" : string.Empty) + "'>«</a></li>"
                     + "<li class=''><a data-index='" + ((PageSize - 1) > 1 ? (PageSize - 1) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 1) > 1 ? (PageIndex - 1) : 1) + "&np=" + PageSize + param + "' class='prev " + ((PageIndex - 1) < 1 ? "not-allow" : string.Empty) + "'><i class='fa fa-angle-left'></i></a></li>";
                for (int i = 1; i <= PageTotal; i++)
                {
                    var active = i == PageIndex ? "active" : "";
                    html += "<li class='" + active + "'><a data-index='" + i + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + i + "&np=" + PageSize + param + "' class='prev quickView disabled  current'>" + i + "</a></li>";
                };
                html = html
                           + "<li class=''><a data-index='" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "&np=" + PageSize + param + "' class='next prev quickView  " + (PageIndex + 1 > PageTotal ? "not-allow" : string.Empty) + "' ><i class='fa fa-angle-right'></i></a></li>"
                           + "<li class=''><a data-index='" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "&np=" + PageSize + param + "' class='last prev quickView " + (PageIndex + 1 > PageTotal ? "not-allow" : string.Empty) + " '>»</a></li>"
                           + "</ul>"
                           + "</div>";
            }
            return MvcHtmlString.Create(html);
        }

        public HtmlString RenderClient(string target = "", string param = "")
        {
            Target = target;
            var html = "";
            if (Total > PageSize)
            {
                html = "<nav aria-label='Page navigation example'>"
                     //+ "<div class='btn-group dropup'>"
                     //+ "<a href='#' data-toggle='dropdown' class='btn btn-sm btn-default dropdown-toggle' aria-expanded='false'>" + PageSize + "<i class='fa fa-angle-down'></i></a>"
                     //+ "<ul class='dropdown-menu dropdown-blue dropdown-menu-right'>"
                     //+ "<li><a href='?page=1&amp;np=10'>10</a></li>"
                     //+ "<li><a href='?page=1&amp;np=20'>20</a></li>"
                     //+ "<li><a href='?page=1&amp;np=30'>30</a></li>"
                     //+ "</ul>"
                     //+ "</div>"
                     + "<ul class='pagination'>"
                     + "<li class='page-item'><a data-index='" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 2) > 1 ? (PageIndex - 2) : 1) + "&np=" + PageSize + param + "' class='page-link first quickView " + ((PageIndex - 2) < 0 ? "not-allow" : string.Empty) + "'>«</a></li>"
                     + "<li class='page-item'><a data-index='" + ((PageSize - 1) > 1 ? (PageSize - 1) : 1) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex - 1) > 1 ? (PageIndex - 1) : 1) + "&np=" + PageSize + param + "' class='page-link prev quickView " + ((PageIndex - 1) < 1 ? "not-allow" : string.Empty) + "'><i class='fa fa-angle-left'></i></a></li>";
                for (int i = 1; i <= PageTotal; i++)
                {
                    var active = i == PageIndex ? "active" : "";
                    html += "<li class='" + active + " page-item'><a data-index='" + i + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + i + "&np=" + PageSize + param + "' class='page-link prev quickView disabled  current'>" + i + "</a></li>";
                };
                html = html
                           + "<li class='page-item'><a data-index='" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 1) >= PageTotal ? PageTotal : (PageIndex + 1)) + "&np=" + PageSize + param + "' class='page-link next prev quickView  " + (PageIndex + 1 > PageTotal ? "not-allow" : string.Empty) + "' ><i class='fa fa-angle-right'></i></a></li>"
                           + "<li class='page-item'><a data-index='" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "' data-target='" + Target + "' data-size='" + PageSize + "' href='?page=" + ((PageIndex + 2) >= PageTotal ? PageTotal : (PageIndex + 2)) + "&np=" + PageSize + param + "' class='page-link last prev quickView " + (PageIndex + 1 > PageTotal ? "not-allow" : string.Empty) + " '>»</a></li>"
                           + "</ul>"
                           + "</div>";
            }
            return MvcHtmlString.Create(html);
        }
    }
}