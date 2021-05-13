using System;
using System.Collections.Generic;
using System.Text;
using Study.Model;
using static Study.Const;

namespace Study.Util
{
    public static class StudyLinqClass
    {
        public static List<Student> GetStudentsObjectForStudy001()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id = 1
                    ,
                    Age = 28
                    ,
                    Name = "Sato Takeru"
                    ,
                    Seisekis = new List<Seiseki>()
                    {
                        new Seiseki(){ KamokuKind = EKamokuKind.Suugaku, Tensu = 80 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Kokugo, Tensu = 89 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.kagaku, Tensu = 79 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Chiri, Tensu = 69 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Butsuri, Tensu = 59 }
                    }
                }
                ,
                new Student()
                {
                    Id = 2
                    ,
                    Age = 35
                    ,
                    Name = "Sato Tomoya"
                    ,
                    Seisekis = new List<Seiseki>()
                    {
                        new Seiseki(){ KamokuKind = EKamokuKind.Suugaku, Tensu = 25 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Kokugo, Tensu = 15 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.kagaku, Tensu = 45 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Chiri, Tensu = 32 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Butsuri, Tensu = 20 }
                    }
                }
                ,
                new Student()
                {
                    Id = 3
                    ,
                    Age = 89
                    ,
                    Name = "Sato chiyo"
                    ,
                    Seisekis = new List<Seiseki>()
                    {
                        new Seiseki(){ KamokuKind = EKamokuKind.Suugaku, Tensu = 90 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Kokugo, Tensu = 80 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.kagaku, Tensu = 70 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Chiri, Tensu = 60 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Butsuri, Tensu = 50 }
                    }
                }

            };
        }
    }
}
