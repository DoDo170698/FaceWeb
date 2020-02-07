using demo1.CodeLogic.Customs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using static demo1.CodeLogic.Enums.Enums;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace demo1.CodeLogic.Helper
{
    public class CustomSelectItem : SelectListItem
    {
        public string Class { get; set; }
        public string SelectedValue { get; set; }
    }
    public static class HelperHtml
    {
        #region---------------Control---------------------------
        /// <summary>
        /// Tự sinh text box Datetime
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBoxDate(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("class", "form-control date");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Tự sinh text box DatetimeDefault
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBoxDateDefault(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("autocomplete", "off");
            tag.MergeAttribute("class", "form-control form-control-inline input-medium default-date-picker");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString CusTextBoxMonth(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("class", "form-control monthYear");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextBoxTime(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = null)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("class", "form-control time " + addClass);
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }
        /// <summary>
        /// Tự sinh text box Datetime
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBoxDateTime(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = null)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("autocomplete", "off");
                tag.MergeAttribute("minlength", "0");
            }
            //tag.MergeAttribute("class", "form-control datetime");
            tag.MergeAttribute("class", "form-control appointment_date " + addClass);
            tag.MergeAttribute("autocomplete", "off");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Tự sinh text box Time
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
         public static MvcHtmlString CusTextBoxTime2(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = null)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("autocomplete", "off");
            tag.MergeAttribute("class", "form-control timepicker-24 " + addClass);
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }


        /// <summary>
        /// Tự sinh text box
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBox(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "",bool autocomplete = false, bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0,string addClass="", bool isReadOnly = false)
        {
            TagBuilder tag = new TagBuilder("input");
            if(autocomplete == true)
            {
                tag.MergeAttribute("autocomplete", "on");
            }
            else
            {
                tag.MergeAttribute("autocomplete", "off");
            }
            if (isReadOnly)
            {
                tag.MergeAttribute("readonly", string.Empty);
            }
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextBoxEmail(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool autocomplete = false, bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = "")
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "email");
            if (autocomplete == true)
            {
                tag.MergeAttribute("autocomplete", "on");
            }
            else
            {
                tag.MergeAttribute("autocomplete", "off");
            }
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }


        public static MvcHtmlString CusTextBoxPassWord(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool autocomplete = false, bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = "")
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "password");
            if (autocomplete == true)
            {
                tag.MergeAttribute("autocomplete", "on");
            }
            else
            {
                tag.MergeAttribute("autocomplete", "off");
            }
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextBoxMoney(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = "")
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("class", "form-control moneyFormat isNumberBiggerZero");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextBoxFloat(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0)
        {
            TagBuilder tag = new TagBuilder("input");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-stringlength-message", string.Format("{0} không được vượt quá {1} ký tự", displayname, maxlen));
                tag.MergeAttribute("data-bv-stringlength-max", maxlen.ToString());
                tag.MergeAttribute("minlength", "0");
            }
            tag.MergeAttribute("class", "form-control isNumberBiggerZero");
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextArea(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int row = 20, int col = 5, int maxlen = 0, string addClass = "")
        {
            TagBuilder tag = new TagBuilder("textarea");
            tag.MergeAttribute("id", id);
            tag.MergeAttribute("name", name);
            tag.MergeAttribute("placeholder", placeholder);
            tag.MergeAttribute("title", placeholder);
            tag.MergeAttribute("rows", row.ToString());
            tag.MergeAttribute("cols", col.ToString());
            tag.MergeAttribute("data-bv-field", name);
            if (isNotEmpty)
            {
                tag.MergeAttribute("data-bv-notempty-message", string.Format("{0} không được để trống", displayname));
                tag.MergeAttribute("data-bv-notempty", "true");
            }
            if (!Equals(value, null))
                tag.SetInnerText(value.ToString());
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tag.MergeAttributes(attributes);
            }
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString CusTextBoxPhone(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, string country = "VI", string addClass = "")
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("data-bv-phone-country", country);
            tag.MergeAttribute("data-bv-phone-message", string.Format("Số điện thoại sai định dạng"));
            tag.MergeAttribute("data-bv-phone", "true");
            tag.MergeAttribute("data-title-show", string.Format("Số điện thoại không đúng định dạng"));
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Tự sinh text box kiểu số
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="isNotEmpty">Trạng thái bắt buộc</param>
        /// <param name="msgNotEmpty">Thông báo lỗi bắt buộc</param>
        /// <param name="isdigits">Trạng thái text box là số</param>
        /// <param name="msgdigits">Thông báo lỗi định dạng số</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBoxDigit(this HtmlHelper html, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, int maxlen = 0, string addClass = "")
        {
            TagBuilder tag = new TagBuilder("input");
            //tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes);
            tag.MergeAttribute("data-bv-digits-message", string.Format("{0} phải là kiểu số", displayname));
            tag.MergeAttribute("data-bv-digits", "true");
            if (maxlen > 0)
            {
                tag.MergeAttribute("data-bv-between-message", string.Format("{0} không được vượt quá {1}", displayname, maxlen));
                tag.MergeAttribute("data-bv-between-max", maxlen.ToString());
                tag.MergeAttribute("data-bv-between-min", "0");
                tag.MergeAttribute("data-bv-between", "true");
            }
            tag.setCommonTextBox(id, name, value, displayname, placeholder, isNotEmpty, htmlAttributes, addClass);
            return new MvcHtmlString(tag.ToString());
        }
        /// <summary>
        /// Tự sinh text box kiểu bắt buộc, hoặc số
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Tên</param>
        /// <param name="displayname">Tên hiển thị</param>
        /// <param name="value">Giá trị</param>
        /// <param name="placeholder">placeholder</param>
        /// <param name="htmlAttributes">Các thuộc tính khác</param>
        /// <returns></returns>
        public static MvcHtmlString CusTextBoxNomal(this HtmlHelper html, string id, string name, object value = null, string placeholder = "", object htmlAttributes = null)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.setCommonTextBox(id, name, value, placeholder, placeholder, false, htmlAttributes);
            return new MvcHtmlString(tag.ToString());
        }
        /// <summary>
        /// Tự sinh Dropdowlist
        /// </summary>
        /// <param name="name">Tên</param>
        /// <param name="id">ID</param>
        /// <param name="optionLabel">Hiển thị tìm kiếm tất cả</param>
        /// <param name="list">Dach sách phần tử của select</param>
        /// <param name="htmlAttributes">các thuộc tính thêm</param>
        /// <returns></returns>
        public static MvcHtmlString CusDropdownList(this HtmlHelper htmlHelper, string id, string name, string optionLabel, IEnumerable<SelectListItem> list, object htmlAttributes = null, bool isReadOnly = false)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            TagBuilder dropdown = new TagBuilder("select");
            if (isReadOnly)
            {
                dropdown.Attributes.Add("disabled", "disabled");
            }
            dropdown.Attributes.Add("class", " form-control mdb-select md-form selectpicker");
            dropdown.setCommonDropdowList(name, id, optionLabel, list, htmlAttributes);
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
        /// <summary>
        /// Tự sinh Dropdowlist dạng select2
        /// </summary>
        /// <param name="name">Tên</param>
        /// <param name="id">ID</param>
        /// <param name="optionLabel">Hiển thị tìm kiếm tất cả</param>
        /// <param name="list">Dach sách phần tử của select</param>
        /// <param name="htmlAttributes">các thuộc tính thêm</param>
        /// <returns></returns>
        public static MvcHtmlString CusDropdownListSelect2(this HtmlHelper htmlHelper, string id, string name, string optionLabel, IEnumerable<SelectListItem> list, object htmlAttributes = null)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            TagBuilder dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("class", "form-control autoSelect2");
            dropdown.setCommonDropdowList(name, id, optionLabel, list, htmlAttributes);
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
        /// <summary>
        /// Tự sinh Dropdowlist dạng chọn nhiều
        /// </summary>
        /// <param name="name">Tên</param>
        /// <param name="id">ID</param>
        /// <param name="optionLabel">Hiển thị tìm kiếm tất cả</param>
        /// <param name="list">Dach sách phần tử của select</param>
        /// <param name="htmlAttributes">các thuộc tính thêm</param>
        /// <returns></returns>
        //public static MvcHtmlString CusDropdownListPicker(this HtmlHelper htmlHelper, string id, string name, string optionLabel, IEnumerable<SelectListItem> list, string placeholder, object htmlAttributes = null, bool isSelectChange = false, bool isMultiple=true, string target = "", string url = "")
        //{

        //    string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        //    if (String.IsNullOrEmpty(fullName))
        //    {
        //        throw new ArgumentException("name");
        //    }
        //    TagBuilder dropdown = new TagBuilder("select");
        //    if (isSelectChange)
        //    {
        //        //dropdown.Attributes.Add("class", "selectpicker form-control select_change");
        //        //dropdown.Attributes.Add("data-target", target);
        //        //dropdown.Attributes.Add("data-url", url);
        //    }
        //    else
        //    {
        //        //dropdown.Attributes.Add("class", "selectpicker form-control");
        //    }
        //    if (isMultiple)
        //    {
        //        dropdown.Attributes.Add("multiple", "true");
        //    }
        //    dropdown.Attributes.Add("class", "form-control mdb-select md-form");
        //    //dropdown.Attributes.Add("data-live-search-placeholder", placeholder);
        //    //dropdown.Attributes.Add("data-actions-box", "false");
        //    //dropdown.Attributes.Add("data-none-selected-text", placeholder);
        //    dropdown.setCommonDropdowList(name, id, null, list, htmlAttributes);
        //    return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        //}
        public static MvcHtmlString CusDropdownListPicker(this HtmlHelper htmlHelper, string id, string name, string optionLabel, IEnumerable<SelectListItem> list, string placeholder, object htmlAttributes = null, string displayname = "", bool isNotEmpty = false, bool isMultiple = true, int size = 5, bool isReadonly = false, string addClass = null)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            TagBuilder dropdown = new TagBuilder("select");

            IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                dropdown.Attributes.Add("class", "selectpicker " + addClass);
            }
            if (isMultiple)
            {
                dropdown.Attributes.Add("multiple", "true");
                dropdown.Attributes.Add("data-deselect-all-text", string.Format("Bỏ chọn"));
                dropdown.Attributes.Add("data-select-all-text", string.Format("Chọn tất cả"));
            }
            if (isReadonly)
            {
                dropdown.MergeAttribute("readonly", "true");
                dropdown.MergeAttribute("disabled", "disabled");
            }
            dropdown.Attributes.Add("data-live-search", "true");
            dropdown.Attributes.Add("data-live-search-placeholder", placeholder);
            dropdown.Attributes.Add("data-actions-box", "true");
            dropdown.Attributes.Add("data-none-selected-text", placeholder);
            dropdown.Attributes.Add("data-container", "body");
            //dropdown.Attributes.Add("data-width", "auto");
            dropdown.Attributes.Add("data-size", size.ToString());
            dropdown.setCommonDropdowList(name, id, optionLabel, list, htmlAttributes, displayname, isNotEmpty);
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
        private static void setCommonDropdowList(this TagBuilder dropdown, string name, string id, string optionLabel, IEnumerable<SelectListItem> list, object htmlAttributes, string displayname = "", bool isNotEmpty = false)
        {
            dropdown.Attributes.Add("name", name);
            dropdown.Attributes.Add("id", id);
            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    if ((item.Key.ToLower() == "disabled" || item.Key.ToLower() == "readonly") && item.Value.ToString().ToLower() == "false")
                        continue;
                    dropdown.MergeAttribute(item.Key, item.Value.ToString());
                }
            }
            if (isNotEmpty)
            {
                dropdown.MergeAttribute("data-bv-field", name);//data-container="body"
                dropdown.MergeAttribute("data-bv-notempty-message", string.Format("{0} không được để trống", displayname));
                dropdown.MergeAttribute("data-bv-notempty", "true");
            }
            StringBuilder options = new StringBuilder();
            if (!string.IsNullOrEmpty(optionLabel))
                options.Append("<option value=''>" + optionLabel + "</option>");
            foreach (var item in list)
            {
                var isDisabled = item.Disabled ? "disabled" : string.Empty;
                var isSelected = item.Selected ? "selected" : string.Empty;
                options.Append("<option =true value='" + item.Value + "'" + isDisabled + " " + isSelected + ">" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
        }

        private static void setCommonDropdowList(this TagBuilder dropdown, string name, string id, string optionLabel, IEnumerable<SelectListItem> list, object htmlAttributes)
        {
            dropdown.Attributes.Add("name", name);
            dropdown.Attributes.Add("id", id);
            dropdown.Attributes.Add("data-container", "body");
            dropdown.Attributes.Add("data-size", "5");
            dropdown.Attributes.Add("data-live-search", "true");
            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    dropdown.MergeAttribute(item.Key, item.Value.ToString());
                }
            }
            StringBuilder options = new StringBuilder();
            if (optionLabel != null)
                options.Append("<option value='" + 0 + "'>" + optionLabel + "</option>");
            foreach (var item in list)
            {
                if (item.Selected)
                    options.Append("<option selected=true value='" + item.Value + "'>" + item.Text + "</option>");
                else
                    options.Append("<option value='" + item.Value + "'>" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
        }
        private static void setCommonTextBox(this TagBuilder tag, string id, string name, object value, string displayname, string placeholder = "", bool isNotEmpty = false, object htmlAttributes = null, string addClass="")
        {
            var classStr = $"form-control {addClass}";
            tag.MergeAttribute("type", "text");
            tag.MergeAttribute("id", id);
            tag.MergeAttribute("name", name);
            tag.MergeAttribute("class", classStr);
            tag.MergeAttribute("placeholder", placeholder);
            tag.MergeAttribute("title", placeholder);

            if (isNotEmpty)
            {
                tag.MergeAttribute("data-bv-field", name);
                tag.MergeAttribute("data-bv-notempty-message", displayname + string.Format(" không được để trống"));
                tag.MergeAttribute("data-bv-notempty", "true");
            }
            if (!Equals(value, null))
                tag.MergeAttribute("value", value.ToString());
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tag.MergeAttributes(attributes);
            }
        }
        #endregion----------------------------------------------

        #region--------Status-------
        /// <summary>
        /// Sịnh động Trạng thái
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderStatus(this HtmlHelper html, int status)
        {
            //DacPV TODO
            TagBuilder tag = new TagBuilder("lable");
            tag.MergeAttribute("value", status.ToString());
            return new MvcHtmlString("Trạng thái " + tag.ToString());
        }
        #endregion------------------

        #region Custom

        private static void setCommonDropDownListByStatus(this TagBuilder dropdown, string id, string name, string optionLabel, string displayname, int status, IEnumerable<SelectListItem> list, object htmlAttributes = null, bool isNotEmpty = false)
        {
            dropdown.Attributes.Add("name", name);
            dropdown.Attributes.Add("id", id);
            dropdown.Attributes.Add("data-container", "body");
            dropdown.Attributes.Add("data-size","10");
            dropdown.MergeAttribute("class", "form-control selectpicker");
            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    dropdown.MergeAttribute(item.Key, item.Value.ToString());
                }
            }
            if (isNotEmpty)
            {
                dropdown.MergeAttribute("data-bv-field", name);
                dropdown.MergeAttribute("data-bv-notempty-message", string.Format("{0} không được để trống", displayname));
                dropdown.MergeAttribute("data-bv-notempty", "true");
            }
            StringBuilder options = new StringBuilder();
            var spanDefault = new TagBuilder("span");
            spanDefault.SetInnerText(displayname);
            spanDefault.MergeAttribute("class", "label label-danger label-default white d-block");
            if (!string.IsNullOrEmpty(optionLabel))
                options.Append("<option value='0' data-content='" + spanDefault + "'>" + optionLabel + "</option>");
            //options.Append("<option value='0' data-content='" + spanDefault + "'>" + optionLabel + "</option>");
            foreach (var item in list)
            {
                var spanStatus = new MvcHtmlString("");
                switch (status)
                {
                    case (int)MvcStringRender.OrderStatus:
                        spanStatus = CUtils.RenderOderStatus(int.Parse(item.Value));
                        break;
                    case (int)MvcStringRender.BillStatus:
                        spanStatus = CUtils.RenderBillStatus(int.Parse(item.Value));
                        break;
                    case (int)MvcStringRender.OrderType:
                        spanStatus = CUtils.RenderOrderType(int.Parse(item.Value));
                        break;
                    case (int)MvcStringRender.Quater:
                        spanStatus = CUtils.RenderQuater(int.Parse(item.Value));
                        break;
                    default:
                        break;
                }
                if (item.Selected)
                    options.Append("<option selected=true value='" + item.Value + "' data-content='" + spanStatus + "' > " + item.Text + "</option>");
                else
                    options.Append("<option value='" + item.Value + "' data-content='" + spanStatus + "'>" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
        }
        public static MvcHtmlString CusDropDownListByStatus(this HtmlHelper htmlHelper, string id, string name, string optionLabel, string displayname, int status, IEnumerable<SelectListItem> list, object htmlAttributes = null, bool isNotEmpty = false,string addClass ="")
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            TagBuilder dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("class", "form-control selectpicker select-inherit "+addClass);
            dropdown.setCommonDropDownListByStatus(id, name, optionLabel, displayname, status, list, htmlAttributes);
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }

        #endregion
    }
}