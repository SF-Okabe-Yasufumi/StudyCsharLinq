using System;
using System.Collections.Generic;
using System.Linq;
using Study.Util;
using static Study.Const;

namespace Study
{
    public class Rensyu001
    {
        public string RenshuMondai3_14(EKamokuKind kamokuKind)
        {
            var students = StudyLinqClass.GetStudentsObjectForStudy001();

            // 名前をキーにし、点数を格納した、名前と点数のDictionaryを用意
            Dictionary<string, int> maps = new Dictionary<string, int>();

            // 全student分ループ
            foreach (var student in students)
            {
                // [依頼]
                // 引数で指定された科目をFirstOrDefault() で取得するプログラムを
                // 記載下さい。
                var seiseki = student.Seisekis.FirstOrDefault(f => f.KamokuKind == kamokuKind);


                if (seiseki != null)
                {
                    //
                    // 引数で指定された科目のSeiseki が存在する場合
                    // ※要ポイント：FirstOfDefault() で取得した場合、Nullの可能性があるので
                    //   かならずNullチェックをしなければなりません。
                    //

                    // [依頼]
                    // maps に、名前と点数を追加してください
                    maps.Add(student.Name, seiseki.Tensu);
                }
            }

            // [依頼]
            // map に、mapsから最も得点の高いものを取得して下さい。
            // ※Dictionaryに対してもLinqが使えます。
            var map = maps.OrderByDescending(o => o.Value).First();


            // 上記で取得した名前をセット
            string targetName = map.Key;

            return targetName;
        }
    }
}
