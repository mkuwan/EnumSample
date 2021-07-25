using System;

namespace EnumSample.Extentions
{
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


}
