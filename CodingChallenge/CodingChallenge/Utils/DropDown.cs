using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Utils
{
    public static class DropDown
    {
        public static List<SelectListItem> GetDropDownPappingGeneric<T>(IList<T> data, string key, string value, List<int> keySelected = null)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in data)
            {
                var view = item;
                var itemKey = (int)(view.GetType().GetProperty(key).GetValue(view, null));
                var itemValue = view.GetType().GetProperty(value).GetValue(view, null).ToString();
                var selected = keySelected != null && keySelected.Any(x => x == itemKey);
                items.Add(new SelectListItem { Text = itemValue, Value = itemKey.ToString(), Selected = selected });
            }

            return items;
        }

        public static List<SelectListItem> GetDropDownPappingGeneric<T>(IList<T> data, string key, string value, int? keySelected = null)
        {
            return GetDropDownPappingGeneric(data, key, value, new List<int> { keySelected == null ? 0 : keySelected.Value });
        }

        public static List<SelectListItem> GetDropDownPappingGeneric<T>(IList<T> data, string key, string value)
        {
            return GetDropDownPappingGeneric(data, key, value, new List<int> { 0 });
        }

        public static IEnumerable<SelectListItem> GetDropDownPappingGenericBool(bool selected = false)
        {
            var list = new List<SelectListItem> { new SelectListItem() { Text = "Yes", Value = "true", Selected = selected == true }, new SelectListItem() { Text = "No", Value = "false", Selected = selected == false } };
            return list;
        }
    }
}