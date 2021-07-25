using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumSample.Extentions
{
    public static class EnumExtention
    {
        /// <summary>
        /// EnumのValueからDescriptionを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionFromValue<T>(this T value) where T : Enum //where T : Enum とすることで Tがenumでない場合はコンパイル時にエラーにしてくれる
        {
            //valueはenum型確定なので空文字が返ることはない
            string strValue = value.ToString();

            var description =
                typeof(T).GetField(strValue)    //FiledInfoを取得
                .GetCustomAttributes(typeof(DescriptionAttribute), false)   //DescriptionAttributeのリストを取得
                .Cast<DescriptionAttribute>()   //DescriptionAttributeにキャスト
                .FirstOrDefault()               //最初の一つを取得、なければnull
                ?.Description;                  //DescriptionAttributeがあればDescriptionを、なければnullを返す

            return description ?? strValue;     //descriptionがnullならstrValueを返す
        }
    }



    public static class StringExtention
    {
        /// <summary>
        /// EnumのDescriptionからValueを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumValueFromDescription<T>(this string description) where T : Enum
        {
            var value =
                typeof(T).GetFields()
                .SelectMany(x => x.GetCustomAttributes(typeof(DescriptionAttribute), false),
                    (f, a) => new { field = f, attribute = a })
                .Where(x => ((DescriptionAttribute)x.attribute).Description == description)
                .FirstOrDefault()
                ?.field.GetRawConstantValue();


            //// 値が見つからない場合にエラーとする場合はこちら
            //return (T)(value ?? throw new ArgumentNullException());

            return (T)(value ?? default(T));

        }
    }

    public static class IntExtention
    {
        /// <summary>
        /// int値からEnumのDescription取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionFromInt<T>(this int value) where T : Enum
        {
            //var enumValue = (T)value;         //コンパイラ エラー CS0030が起きる・・・

            var enumValue = (T)Enum.ToObject(typeof(T), value);

            return enumValue.GetDescriptionFromValue();
        }

        /// <summary>
        /// int値からEnumのValueを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumValueFromInt<T>(this int value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }

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
