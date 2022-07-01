using System;
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
        /// EnumのValueからDescriptionを取得 です
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
}
