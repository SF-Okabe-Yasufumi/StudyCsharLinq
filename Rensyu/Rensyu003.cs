using Study.Model;
using Study.Util;
using System;
using System.Collections.Generic;
using System.Text;
using static Study.Const;
using System.Linq;

namespace Study.Rensyu
{
    public class Rensyu003
    {
        #region "private field variable"
        /// <summary>
        /// 学生情報リスト
        /// </summary>
        private readonly List<Student> _students;
        #endregion "private field variable"

        #region "constructor"
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Rensyu003()
        {
            //
            // コンストラクタ（このクラスをどこかでnew()したときに動く処理）のタイミングで
            // テストに利用するデータをセットします。
            // 
            _students = GetStudents();
        }
        #endregion "constructor"

        #region "public methods"
        /// <summary>
        /// 業務では関数名はその処理に相応しい名前をつけるのが通例です。
        /// 今後、気にしてみましょう。
        /// 
        /// 
        /// 問題１
        /// 引数指定の科目の平均点数を算出して下さい。
        /// ・引数指定の科目がない場合は無視すること
        /// ・点数が0未満の場合は無視すること
        /// </summary>
        /// <param name="kamokuKind">EKamokuKind</param>
        /// <returns>平均点数</returns>
        public float GetAvarageByKamoku(EKamokuKind kamokuKind)
        {
            var students = GetStudents();
            Dictionary<string, int> maps = new Dictionary<string, int>();
            foreach(var student in students)
            {
                var seiseki = student.Seisekis.FirstOrDefault(f => f.KamokuKind == kamokuKind);
                if(seiseki != null)
                {
                    maps.Add(student.Name, seiseki.Tensu);
                }
            }

            float sum = 0.0f;
            foreach(var tokuten in maps)
            {
                if(tokuten.Value >= 0)
                  {
                    sum += tokuten.Value;
                  }
            }
            float avelage = sum / maps.Count;

            return avelage;
        }

        /// <summary>
        /// 問題２
        /// 各学生の成績平均点を算出して下さい。
        /// ・引数指定の科目がない場合は無視すること
        /// ・点数が0未満の場合は無視すること
        /// </summary>
        /// <returns>Dictionary<string, double></returns>
        public Dictionary<string, double> GetAvarageByStudent(EKamokuKind kamokuKind, Name)
        {
            var students = GetStudents();
            var sum = 0.0;
            foreach(var student in students)
            {
                var seiseki = student.Where(w => w.Name == Name).FirstOrDefault();
                sum += seiseki.Tensu;
            }

            //??には全科目が入っている
            //double sum = 0.0;
            //foreach(var tokuten in ??)
            //{
            //   if(tokuten.Value >= 0)
            //   {
            //      sum += tokuten.Value;
            //   }
            //}
            //double avelage = sum / ??.Count;

            // 生徒の名前をkeyにセット、平均点をvalueにセット
            return new Dictionary<string, double>();
        }

        /// <summary>
        /// 問題３
        /// ある科目のテストをしなかった人がいます。
        /// そこで、引数指定科目の成績がない人の名前リストを作成下さい。
        /// 
        /// ちなみに、ToList() というLinqを使うとかならずList<T> 形式になります。
        /// LinqのWhereやorderByで返ってくるものはList<T>型ではありません。
        /// IEnumrable<T>やOrderble<T>という、List<T>型の親戚みたいなものです。
        /// これは、ToList() することにより List<T>型に変換できます。
        /// </summary>
        /// <param name="kamokuKind">EKamokuKind</param>
        /// <returns>引数指定科目の成績がない人の名前リスト</returns>
        public List<string> GetNgStudentNamesBykamoku(EKamokuKind kamokuKind)
        {
            var students = GetStudents();

            Dictionary<string, int> maps = new Dictionary<string, int>();

            foreach(var student in students)
            {
                var seiseki = student.Seisekis.FirstOrDefault(f => f.KamokuKind != kamokuKind);

                if(seiseki != null)
                {
                    maps.Add(student.Name, seiseki.Tensu);
                }
            }

            var map = maps.ToList();
            List<string> targetNames = new List<string>();
            foreach(var name in map)
            {
                targetNames.Add(name.Key);
            }

            return new List<string>();
        }


        /// <summary>
        /// 問題４
        /// テストをしたけど点数が0点未満の人がいます。
        /// そこで、引数指定科目が0点未満の人の名前リストを作成下さい。
        /// </summary>
        /// <param name="kamokuKind">EKamokuKind</param>
        /// <returns>引数指定科目が0点未満の人の名前リスト</returns>
        public List<string> GetOhNoStudentNamesBykamoku(EKamokuKind kamokuKind)
        {
            var students = GetStudents();
            Dictionary<string, int> maps = new Dictionary<string, int>();

            foreach(var student in students)
            {
                var seiseki = student.Seisekis.FirstOrDefault(f => f.KamokuKind == kamokuKind);
                if(seiseki != null)
                {
                    maps.Add(student.Name, seiseki.Tensu);
                }
            }

            var map = maps.Where(w => w.Value < 0);
            List<string> targetName = new List<string>();
            foreach(var name in map)
            {
                targetName.Add(name.Key);
            }

            return new List<string>();
        }

        /// <summary>
        /// 問題５
        /// 全てのテストをせず全ての成績が無い人がいます。
        /// その人を取得する処理を作成下さい。
        /// </summary>
        /// <param name="kamokuKind">EKamokuKind</param>
        /// <returns>成績が無い人の名前リスト</returns>
        public List<string> GetAllOhNoStudentNamesBykamoku()
        {
            var students = GetStudents();
            Dictionary<string, int> maps = new Dictionary<string, int>();

            foreach(var student in students)
            {
                var seisekinai = student.Seisekis.FirstOrDefault();

            }

            return new List<string>();
        }


        /// <summary>
        /// 問題６
        /// 基本的なことの復習です。
        /// Linqは使わないかもしれません。
        /// 
        /// Lupinが自身の成績を盗み全て100点にしました。
        /// Lupinの既存の成績は全て削除し、全ての科目100点にして下さい。
        /// ※Lupin以外のは既存のままです。
        /// 書き換えたリストを返却下さい。
        /// </summary>
        /// <param name="kamokuKind">EKamokuKind</param>
        /// <returns>成績が無い人の名前リスト</returns>
        public void LupinSeiseiChange()
        {
            var students = GetStudents();
            var Lupin = students.Where(w => w.Name == "Lupin Sansei").FirstOrDefault();

            if(Lupin != null)
            {
                var seiseki = Lupin.Seisekis.OrderBy(o => o.Tensu);
            }


            

            //return new List<string>();
        }


        /// <summary>
        /// 問題７
        /// </summary>
        public void RenshuMojiretsuIndexOf()
        {
            // 以下URLページを参照し、string.IndexOf() について調査下さい。
            // https://dobon.net/vb/dotnet/string/stringindexof.html


            var list = new List<string>()
            { "aaabbbccc", "aaaaabbbcc", "erwrrffggg", "aasswee"};
            // 上記のリストから "aaa" の文字が最初にくるものを取得する処理を作成下さい。

            string item = "aaa";
            string item2 = "a";

             foreach(var s in list)
            {
                var rtn1 = s.IndexOf(item);
                var rtn2 = s.IndexOf(item2, 4);
                if(rtn1 == 0 || rtn2 == -1)
                {
                    Console.WriteLine(s);
                }
            }


        }

        /// <summary>
        /// 問題８
        /// 名字が "Sato" の学生を抽出する処理を作成下さい。
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentByMyojiGaSato()
        {


            return new List<Student>();
        }

        #endregion "public methods"


        #region "private methods"
        private List<Student> GetStudents()
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
                ,
                new Student()
                {
                    Id = 4
                    ,
                    Age = 45
                    ,
                    Name = "Jigen Daisuke"
                    ,
                    Seisekis = new List<Seiseki>()
                }
                ,
                new Student()
                {
                    Id = 5
                    ,
                    Age = 53
                    ,
                    Name = "Lupin Sansei"
                    ,
                    Seisekis = new List<Seiseki>()
                    {
                        new Seiseki(){ KamokuKind = EKamokuKind.kagaku, Tensu = 100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Butsuri, Tensu = 100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Kokugo, Tensu = -100 }
                    }
                }
                ,
                new Student()
                {
                    Id = 6
                    ,
                    Age = 34
                    ,
                    Name = "Ishikawa Goemon"
                    ,
                    Seisekis = new List<Seiseki>()
                    {
                        new Seiseki(){ KamokuKind = EKamokuKind.Suugaku, Tensu = -100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Kokugo, Tensu = -100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.kagaku, Tensu = -100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Chiri, Tensu = -100 }
                        ,
                        new Seiseki(){ KamokuKind = EKamokuKind.Butsuri, Tensu = -100 }
                    }
                }

            };
        }
        #endregion "private methods"
    }
}
