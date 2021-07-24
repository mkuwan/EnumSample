using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EnumSample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine();

            Console.WriteLine("enum値のままで表示させた場合");
            Console.WriteLine(SampleEnum.Tokyo);
            Console.WriteLine(SampleEnum.Nagoya);
            Console.WriteLine(SampleEnum.Sapporo);
            Console.WriteLine(SampleEnum.Osaka);
            Console.WriteLine();

            Console.WriteLine("enum値をCase変換してみた");
            Console.WriteLine(GetName(SampleEnum.Tokyo));
            Console.WriteLine(GetName(SampleEnum.Nagoya));
            Console.WriteLine(GetName(SampleEnum.Sapporo));
            Console.WriteLine(GetName(SampleEnum.Osaka));
            Console.WriteLine();

            Console.WriteLine("GetEnumDescriptionFromValueを使ってTokyoのDescriptionを取得");
            var tokyo = EnumHelper.GetEnumDescriptionFromValue<SampleEnum>(SampleEnum.Tokyo);
            Console.WriteLine(tokyo);
            Console.WriteLine();

            Console.WriteLine("GetEnumValueFromDescriptionを使ってDescriptionからenum値を取得");
            var nagoya = EnumHelper.GetEnumValueFromDescription<SampleEnum>("名古屋");
            Console.WriteLine(nagoya);
            Console.WriteLine();

            Console.WriteLine("GetEnumDescriptionFromIntを使ってint値からDescriptionを取得");
            var sapporo = EnumHelper.GetEnumDescriptionFromInt<SampleEnum>(5);
            Console.WriteLine(sapporo);
            Console.WriteLine();

            Console.WriteLine("GetEnumValueFromIntを使ってint値からenum値を取得");
            var osaka = EnumHelper.GetEnumValueFromInt<SampleEnum>(7);
            Console.WriteLine(osaka);
            Console.WriteLine();

            Console.WriteLine("GetEnumListを使ってenumの値リストを取得");
            var enums = EnumHelper.GetEnumList<SampleEnum>();
            foreach(var e in enums)
                Console.WriteLine(e);
            Console.WriteLine();

            Console.WriteLine("GetEnumDescriptionListを使ってDescriptionリストを取得");
            var descriptions = EnumHelper.GetEnumDescriptionList<SampleEnum>();
            foreach (var d in descriptions)
                Console.WriteLine(d);
            Console.WriteLine();

            Console.ReadLine();

        }

        /// <summary>
        /// enum値を日本語に変換します
        /// </summary>
        /// <param name="sampleEnum"></param>
        /// <returns></returns>
        static string GetName(SampleEnum sampleEnum)
        {
            switch (sampleEnum)
            {
                case SampleEnum.Tokyo:
                    return "東京";

                case SampleEnum.Nagoya:
                    return "名古屋";

                case SampleEnum.Sapporo:
                    return "札幌";

                case SampleEnum.Osaka:
                    return "大阪";

                default:
                    return null;
            }
        }
    }

    public enum SampleEnum
    {
        [Description("東京")]
        Tokyo = 1,

        [Description("名古屋")]
        Nagoya = 3,

        [Description("札幌")]
        Sapporo = 5,

        [Description("大阪")]
        Osaka = 7
    }
}
