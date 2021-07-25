using System;
using System.ComponentModel;
using System.Linq;

namespace EnumSample.Extentions
{
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
}
