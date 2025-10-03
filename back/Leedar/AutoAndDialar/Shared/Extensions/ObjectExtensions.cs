namespace Shared.Extensions
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ConvertAnonymousObjectToDictionary(object attributes)
        {
            var dictionary = new Dictionary<string, object>();
            if (attributes == null)
            {
                return dictionary;
            }

            dictionary = attributes.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(pi => pi.Name, pi => pi.GetValue(attributes));
            return dictionary;
        }

        public static bool IsNullOrDefault<T>(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (Equals(obj, default(T)))
            {
                return true;
            }

            return false;
        }

        public static void SetPropertyValueFromString(this object target, string propertyName, object propertyValue)
        {
            var oProp = target.GetType().GetProperty(propertyName);
            var tProp = oProp.PropertyType;

            // Nullable properties have to be treated differently, since we
            // use their underlying property to set the value in the object
            if (tProp.IsGenericType && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // if it's null, just set the value from the reserved word null, and return
                if (propertyValue == null)
                {
                    oProp.SetValue(target, null, null);
                    return;
                }

                // Get the underlying type property instead of the nullable generic
                tProp = new NullableConverter(oProp.PropertyType).UnderlyingType;
            }

            // use the converter to get the correct value
            oProp.SetValue(target, Convert.ChangeType(propertyValue, tProp), null);
        }

        public static T To<T>(object obj, T defaultValue, Type type)
        {
            // Place convert to structures types here
            if (type == typeof(short))
            {
                if (short.TryParse(obj.ToString(), out System.Int16 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(ushort))
            {
                if (ushort.TryParse(obj.ToString(), out System.UInt16 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(int))
            {
                if (int.TryParse(obj.ToString(), out System.Int32 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(uint))
            {
                if (uint.TryParse(obj.ToString(), out System.UInt32 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(long))
            {
                if (long.TryParse(obj.ToString(), out System.Int64 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(ulong))
            {
                if (ulong.TryParse(obj.ToString(), out System.UInt64 value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(float))
            {
                if (float.TryParse(obj.ToString(), out System.Single value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(double))
            {
                if (double.TryParse(obj.ToString(), out System.Double value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(decimal))
            {
                if (decimal.TryParse(obj.ToString(), out System.Decimal value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(bool))
            {
                if (bool.TryParse(obj.ToString(), out System.Boolean value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(DateTime))
            {
                if (DateTime.TryParse(obj.ToString(), out DateTime value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(DateTimeOffset))
            {
                if (DateTimeOffset.TryParse(obj.ToString(), out DateTimeOffset value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(byte))
            {
                if (byte.TryParse(obj.ToString(), out System.Byte value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(Guid))
            {
                const string GuidRegEx =
                    @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
                var regEx = new Regex(GuidRegEx);
                if (regEx.IsMatch(obj.ToString()))
                {
                    return (T)(object)new Guid(obj.ToString());
                }

                return defaultValue;
            }

            if (type.GetTypeInfo().IsEnum)
            {
                if (Enum.IsDefined(type, obj))
                {
                    return (T)Enum.Parse(type, obj.ToString());
                }

                return defaultValue;
            }

            throw new NotSupportedException($"Couldn't parse \"{obj}\" as {type} to Type \"{typeof(T)}\"");
        }

        public static T To<T>(this object obj, T defaultValue = default(T))
        {
            if (obj == null)
            {
                return defaultValue;
            }

            if (obj is T)
            {
                return (T)obj;
            }

            var type = typeof(T);

            // Place convert to reference types here
            if (type == typeof(string))
            {
                return (T)(object)obj.ToString();
            }

            var underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null)
            {
                return To(obj, defaultValue, underlyingType);
            }

            return To(obj, defaultValue, type);
        }

        public static string ToJson(this object o, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(o, settings);
        }

        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }
    }
}