using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Practice20240309.Models
{
    public enum AppAreaEnum
    {
        /// <summary>
        /// 肥料。
        /// </summary>
        [Description("肥料")]
        Fertilizer = 1,
        /// <summary>
        /// 飼料。
        /// </summary>
        [Description("飼料")]
        Feed = 2,
        /// <summary>
        /// 能源。
        /// </summary>
        [Description("能源")]
        Energy = 3,
        /// <summary>
        /// 材料。
        /// </summary>
        [Description("材料")]
        Material = 4,
        /// <summary>
        /// 其他。
        /// </summary>
        [Description("其他")]
        Other = 5
    }
}