using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Practice20240309.Helpers
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }

        public static string DisplayName<T>(this T? value) where T : struct, IConvertible
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.Value.DisplayName();
        }

        public static string DisplayName<T>(this T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                return string.Empty;
            }

            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            if (descriptionAttributes[0].ResourceType != null)
            {
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);
            }
            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }
            return resourceKey;
        }

        public static string GetDescription(this Enum source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute), false);
            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}