using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class DropdownExtensions
    {
        public static void PopulateWith(this TMP_Dropdown dropdown, Type enumType, bool clearOldOptions = true)
        {
            if (!enumType.IsEnum)
            {
                Debug.LogError("Type is not an Enum.");
                return;
            }
            
            dropdown.PopulateWith(Enum.GetNames(enumType), clearOldOptions);
        }
        
        public static void PopulateWith(this TMP_Dropdown dropdown, string[] items, bool clearOldOptions = true)
        {
            var options = new List<TMP_Dropdown.OptionData>();
 
            for (var i = 0; i < items.Length; i++)
            {
                options.Add(new TMP_Dropdown.OptionData(items[i]));
            }
 
            if (clearOldOptions) 
            {
                dropdown.ClearOptions();
            }
            
            dropdown.AddOptions(options);
        }
    }
}