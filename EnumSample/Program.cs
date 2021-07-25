using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EnumSample.Extentions;

namespace EnumSample
{
    class Program
    {

        static void Main(string[] args)
        {

            //Test1();

            Test2();
        }

        /// <summary>
        /// 最初に作ったもの
        /// </summary>
        static void Test1()
        {
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
            foreach (var e in enums)
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
        /// Extentionを使用
        /// </summary>
        static void Test2()
        {
            Console.WriteLine("EnumExtention  GetDescriptionFromValueを使ってTokyoのDescriptionを取得");
            Console.WriteLine(SampleEnum.Tokyo.GetDescriptionFromValue());
            Console.WriteLine();

            Console.WriteLine("StringExtention  GetEnumValueFromDescriptionを使ってDescriptionからenum値を取得");
            Console.WriteLine("名古屋".GetEnumValueFromDescription<SampleEnum>());
            Console.WriteLine();

            Console.WriteLine("IntExtention  GetEnumDescriptionFromIntを使ってint値からDescriptionを取得");
            var sapporo = 5.GetEnumDescriptionFromInt<SampleEnum>();
            Console.WriteLine(sapporo);
            Console.WriteLine();

            Console.WriteLine("IntExtention  GetEnumValueFromIntを使ってint値からenum値を取得");
            var osaka = 7.GetEnumValueFromInt<SampleEnum>();
            Console.WriteLine(osaka);
            Console.WriteLine();

            Console.WriteLine("TypeExtention  GetEnumListを使ってenumの値リストを取得");
            var enumValues = typeof(SampleEnum).GetEnumList<SampleEnum>();
            foreach (SampleEnum e in enumValues)
                Console.WriteLine(e);

            Console.WriteLine();

            Console.WriteLine("TypeExtention  GetEnumDescriptionListを使ってDescriptionリストを取得");
            var enumDescriptions = typeof(SampleEnum).GetEnumDescriptionList<SampleEnum>();
            foreach (string e in enumDescriptions)
                Console.WriteLine(e);

            Console.WriteLine();

            Console.WriteLine("TypeExtention  GetEnumDescriptionEnumerableを使ってDescriptionリストを取得");
            var enumDescriptionsEnumerable = typeof(SampleEnum).GetEnumDescriptionEnumerable<SampleEnum>();
            foreach (var e in enumDescriptionsEnumerable)
                Console.WriteLine(e);

            Console.WriteLine();

            Console.ReadLine();

            //try
            //{
            //    Console.WriteLine("Descriptionにない文字を使った場合　エラーを起こす");
            //    Console.WriteLine("愛知".GetEnumValueFromDescription<SampleEnum>());
            //    Console.ReadLine();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadLine();
            //}

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
}
