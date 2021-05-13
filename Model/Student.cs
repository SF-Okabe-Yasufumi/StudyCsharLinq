using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Model
{
    public class Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年齢
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 成績リスト
        /// </summary>
        public List<Seiseki> Seisekis { get; set; } = new List<Seiseki>();
    }
}
