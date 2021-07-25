using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumSample.Extentions
{
    public static class TypeExtention
    {
        /// <summary>
        /// enumの値リストを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetEnumList<T>(this Type type) where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        /// <summary>
        /// enumのDescripntionリストを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<string> GetEnumDescriptionEnumerable<T>(this Type type) where T : Enum
        {
            foreach (T value in Enum.GetValues(typeof(T)))
                yield return value.GetDescriptionFromValue();
        }

        /// <summary>
        /// enumのDescripntionリストを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetEnumDescriptionList<T>(this Type type) where T : Enum
        {
            List<string> descriptionList = new List<string>();
            foreach (T value in Enum.GetValues(typeof(T)))
                descriptionList.Add(value.GetDescriptionFromValue());

            return descriptionList;
        }
    }
}
