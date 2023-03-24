using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class DropdownExtensions
    {
        public static void PopulateWith(this TMP_Dropdown dropdown, Type enumType)
        {
            if (!enumType.IsEnum)
            {
                Debug.LogError("Type is not an Enum.");
                return;
            }
            
            var options = new List<TMP_Dropdown.OptionData>();
 
            for(var i = 0; i < Enum.GetNames(enumType).Length; i++)
            {
                options.Add(new TMP_Dropdown.OptionData(Enum.GetName(enumType, i)));
            }
 
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }
    }
}