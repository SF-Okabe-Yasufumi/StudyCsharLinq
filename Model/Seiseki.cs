using System;
using System.Collections.Generic;
using System.Text;
using static Study.Const;

namespace Study.Model
{
    public class Seiseki
    {
        /// <summary>
        /// 科目種類
        /// </summary>
        public EKamokuKind KamokuKind { get; set; }

        /// <summary>
        /// 点数
        /// </summary>
        public int Tensu { get; set; }
    }
}
