using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSample
{
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
