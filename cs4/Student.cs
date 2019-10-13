using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs4
{
    enum Subject { Programming, Administration, Design };
    class Student
    {
        string name, surname, patronymic;
        int recordBook;
        static int startCounter;
        DateTime birthday = default(DateTime);
        uint[][] marks = new uint[3][];
        readonly string[] subject = { "Programming", "Administration", "Design" };
        const uint MAX_MARK = 12, MIN_MARK = 1;
        static string institutionName = "noname_inst";
        static int studentNumber;

        public Student() : this("None", "None", "None") { }
        public Student(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            recordBook = startCounter++;
            studentNumber++;
        }
        static Student()
        {
            Random rnd = new Random();
            startCounter = rnd.Next();
            studentNumber = 0;
        }
        string CleanString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]))
                    str = str.Remove(i--, 1);
            }
            return str;
        }
        string Name
        {
            get => name;
            set => name = (!String.IsNullOrWhiteSpace(value) ? CleanString(value) : "-");
        }
        public string Surname
        {
            get => surname;
            set => surname = (!String.IsNullOrWhiteSpace(value) ? CleanString(value) : "-");
        }
        string Patronymic
        {
            get => patronymic;
            set => patronymic = (!String.IsNullOrWhiteSpace(value) ? CleanString(value) : "-");
        }
        static int StudentNumber
        {
            get => studentNumber;
        }
        public int RecordBook
        {
            get => recordBook;
        }
        public void SetProg(params uint[] prog)
        {
            if (prog != null && prog.Length > 0)
                marks[0] = prog;
        }
        public void SetAdm(params uint[] adm)
        {
            if (adm != null && adm.Length > 0)
                marks[1] = adm;
        }
        public void SetDes(params uint[] des)
        {
            if (des != null && des.Length > 0)
                marks[2] = des;
        }
        double? averageProg
        {
            get
            {
                if (marks[0] != null)
                {
                    double sum = 0;
                    foreach (uint el in marks[0])
                        sum += el;
                    return sum / marks[0].Length;
                }
                else
                    return 0;
            }
        }
        double? averageAdm
        {
            get
            {
                if (marks[1] != null)
                {
                    double sum = 0;
                    foreach (uint el in marks[1])
                        sum += el;
                    return sum / marks[1].Length;
                }
                else
                    return 0;
            }
        }
        double? averageDes
        {
            get
            {
                if (marks[2] != null)
                {
                    double sum = 0;
                    foreach (uint el in marks[2])
                        sum += el;
                    return sum / marks[2].Length;
                }
                else
                    return 0;
            }
        }
        double? average
        {
            get => marks.Length > 0 ? (averageProg + averageAdm + averageDes) / marks.Length : 0;
        }
        public double Average()
        {
            return Math.Round(average.GetValueOrDefault(), 2);
        }
        string FullName
        {
            get => $"{surname} {name} {patronymic}";
        }
        int GetAgeOnDate(DateTime dt)
        {
            return (dt < birthday ? 0 : (dt - birthday).Days / 365);
        }
        int GetAge
        {
            get => (DateTime.Today - birthday).Days / 365;
        }
        DateTime Birthday
        {
            get => birthday;
            set => birthday = (value < DateTime.Today ? value : default(DateTime));
        }
        public string Group { get; set; }
        public void SetMark(Subject subject, int numLesson, int mark)
        {
            if (mark > MAX_MARK || mark < MIN_MARK)
                return;
            else if (numLesson >= marks[(uint)subject].Length || numLesson < 0)
                return;
            marks[(uint)subject][numLesson] = (uint)mark;
        }
        public void ClearMarks()
        {
            for (int i = 0; i < marks.Length; i++)
                marks[i] = null;
        }
        void ShowMarks(uint[] arr)
        {
            if (arr != null)
                foreach (uint el in arr)
                    Console.Write($"{el}  ");
            Console.WriteLine();
        }
        public void Info()
        {
            Console.WriteLine($"{FullName} \tAge: {GetAge}");
            Console.WriteLine($"{institutionName} Group: {Group}");
            Console.WriteLine($"Record book number: {recordBook}");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"{subject[i]}:  ");
                ShowMarks(marks[i]);
            }
            Console.WriteLine();
        }
        public void SetStudent()
        {
            Console.Write($"Enter name: ");
            Name = Console.ReadLine();
            Console.Write($"Enter surname: ");
            Surname = Console.ReadLine();
            Console.Write($"Enter patronymic: ");
            Patronymic = Console.ReadLine();
            Console.Write($"Enter birthday (YYYY/MM/DD): ");
            string[] bday = Console.ReadLine().Split("/\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (bday.Length == 3)
                Birthday = new DateTime(Convert.ToInt32(bday[0]), Convert.ToInt32(bday[1]), Convert.ToInt32(bday[2]));
            Console.Write($"Enter institution name: ");
            institutionName = Console.ReadLine();
            Console.Write($"Enter group name: ");
            Group = Console.ReadLine();
        }
        static public void MaxAv(List<Student> students)
        {
            (students.Find(st => st.Average() == students.Max(st1 => st1.Average()))).Info();
        }
        static public void MinAv(List<Student> students)
        {
            (students.Find(st => st.Average() == students.Min(st1 => st1.Average()))).Info();
        }
        static public void PassedSubject(List<Student> students)
        {
            Console.WriteLine($"Number of students who passed");
            Console.WriteLine($"Programming:\t {students.Count(st => st.averageProg >= 7)}");
            Console.WriteLine($"Administration:\t {students.Count(st => st.averageAdm >= 7)}");
            Console.WriteLine($"Design:\t\t {students.Count(st => st.averageDes >= 7)}");
        }
        public uint this[Subject subject, int index]
        {
            get
            {
                if ((int)subject >= 0 && (int)subject < marks.Length)
                    return marks[(int)subject][index];
                else
                    throw new Exception("Invalid mark parameters");
            }
            set
            {
                if ((int)subject >= 0 && (int)subject < marks.Length && index >= 0 && index < marks[(int)subject].Length)
                    if (value >= MIN_MARK && value <= MAX_MARK)
                        marks[(int)subject][index] = value;
            }
        }
        private bool ValidMark(uint mark)
        {
            return (mark >= MIN_MARK && mark <= MAX_MARK);
        }
        private bool ValidIndex(int index, Subject subject)
        {
            return (index < marks[(int)subject].Length && index >=0);
        }
        private Subject StrToSub(string subject)
        {
            if (Enum.TryParse(subject, true, out Subject sub))
                return sub;
            else
                throw new Exception("Error. No such subject");
        }
        public uint this[string subject, int index]
        {
            get
            {
                Subject tmp = StrToSub(subject);
              
                if (ValidIndex(index, tmp))
                    return marks[(int)tmp][index];
                else
                    throw new Exception("Invalid index parameters");
            }
            set
            {
                Subject tmp = StrToSub(subject);
                if (ValidIndex(index, tmp))
                {
                    if (ValidMark(value))
                        marks[(int)StrToSub(subject)][index] = value;
                    else
                        throw new Exception("Invalid mark parameters");
                }
                else
                    throw new Exception("Invalid index parameters");
            }
        }
    }
}