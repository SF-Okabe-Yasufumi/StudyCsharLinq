using System;
using System.Collections.Generic;
using System.Linq;
using Study.Util;
using static Study.Const;

namespace Study
{
    public class Rensyu002
    {
        public List<string> RenshuMondai3_15(EKamokuKind kamokuKind, int Tensu)
        {
            var students = StudyLinqClass.GetStudentsObjectForStudy001();

            Dictionary<string, int> charts = new Dictionary<string, int>();

            foreach (var student in students)
            {
                var seiseki = student.Seisekis.FirstOrDefault(f => f.KamokuKind == kamokuKind);
                if (seiseki != null)
                {
                    charts.Add(student.Name, seiseki.Tensu);
                }
            }

            var chart = charts.Where(w => w.Value > Tensu).ToList();

            List<string> targetNames = new List<string>();
            foreach (var name in chart)
            {
                targetNames.Add(name.Key);
            }

            return targetNames;
        }
    }
}
