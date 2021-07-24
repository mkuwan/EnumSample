using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EnumSample
{
    public static class EnumHelper
    {
        /// <summary>
        /// 列挙体フィールドのDescriptionを取得する。
        /// </summary>
        /// <param name="value">列挙体値</param>
        /// <returns>Description文字列</returns>
        public static string GetEnumDescriptionFromValue<T>(object value)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            string description = null;

            if (value != null)
            {
                string strValue = value.ToString();

                description = strValue;

                if (strValue.Length > 0)
                {
                    FieldInfo fieldInfo = type.GetField(strValue);

                    // Descriptionが複数ある場合はこちらのコードにします
                    //var attrebutes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    //var dcs = attrebutes.Select(x => x.Description).FirstOrDefault();
                    //if(dcs != null)
                    //{
                    //    description = dcs;
                    //}

                    Attribute attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
                    if (attribute != null)
                    {
                        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)attribute;
                        description = descriptionAttribute.Description;
                    }
                }
            }

            return description;
        }


        /// <summary>
        /// Descriptionから列挙体の値を取得する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                                        (f, a) => new { Field = f, Att = a })
                            .Where(a => ((DescriptionAttribute)a.Att)
                                .Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// int値からDescriptionを取得する
        /// 逆は(int)enum value で取得できます
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionFromInt<T>(int value)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            var enumValue = (T)Enum.ToObject(type, value);

            return GetEnumDescriptionFromValue<T>(enumValue);

        }

        /// <summary>
        /// int値からenum value値を取得する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumValueFromInt<T>(int value)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            return (T)Enum.ToObject(type, value);
        }

        /// <summary>
        /// enumの値リストを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetEnumList<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            List<T> values = new List<T>();
            foreach (T value in Enum.GetValues(type))
            {
                values.Add(value);
            }
            return values;
        }

        /// <summary>
        /// enumのDescripntionリストを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetEnumDescriptionList<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            List<string> descriptions = new List<string>();
            foreach (T value in Enum.GetValues(type))
            {
                var description = GetEnumDescriptionFromValue<T>(value);
                descriptions.Add(description);
            }
            return descriptions;
        }
    }
}
