using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proLVL;

namespace OOP_LAB_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String Test(string str)
            {
                if (String.IsNullOrEmpty(str))
                    return "пустая или имеет null-значение";
                else
                    return String.Format("имеет значение {0}",str);
                
            }

            String Sum(int intVar1,int intVar2)
            {
                var values = (first:intVar1, second:intVar2);
                return $"Сумма {values.first} и {values.second} равна : {Addition(values.first,values.second)}";
                int Addition(int first, int second)
                {
                    return first + second;
                }

            }

            
            /*
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Введите int значение:");
                        int firstVariable = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите double значение:");
                        double secondVariable = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите int64 значение:");
                        Int64 thirdVariable = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Введите string значение:");
                        string fourthVariable = Console.ReadLine();
                        Console.WriteLine($"{firstVariable.GetType()}: значение : {firstVariable}");
                        Console.WriteLine($"{secondVariable.GetType()}: значение : {secondVariable}");
                        Console.WriteLine($"{thirdVariable.GetType()}: значение : {thirdVariable}");
                        Console.WriteLine($"{fourthVariable.GetType()}: значение : {fourthVariable}");
            */



            #region Задание 1
            Int32 intVariable = 777;
            Object FirstObject = intVariable;
            Double doubleVariable = (Double)intVariable;
            #endregion


            #region Задание 2
            int MyValue = 5;
            double doubleMyValue = MyValue; //неявное
            float floatMyValue = MyValue; //неявное
            Byte b = (Byte)MyValue; //явное
            #endregion


            #region Задание 3
            Console.ForegroundColor = ConsoleColor.Red;
            string MyName = "Ilya";
            Console.WriteLine("My Name Is {0}", MyName);
            Console.WriteLine($"My Name Is {MyName}");
            #endregion


            #region Задание 4
            Console.ForegroundColor = ConsoleColor.Green;
            Int32 int32Variable = 33;
            Int32 int32Variable2 = 55;
            Console.WriteLine($"Значение Equals : {Equals(int32Variable, int32Variable2)}");
            Console.WriteLine($"Значение .ToString : {int32Variable.ToString()}");
            Console.WriteLine($"Значение .GetHashCode : {int32Variable.GetHashCode()}");
            Console.WriteLine($"Значение .GetType : {int32Variable.GetType()}");
            Console.WriteLine($"Значение .GetTypeCode : {int32Variable.GetTypeCode()}");
            Console.WriteLine($"Значение ReferenceEquals : {ReferenceEquals(int32Variable, int32Variable2)}");
            #endregion



            #region Задание 5
            Console.ForegroundColor = ConsoleColor.Yellow;
            string firstStringVar= "C";
            string secondStringVar = "#Sharp#";
            Console.WriteLine($"Compare : {String.Compare(firstStringVar, secondStringVar)}"); // 1 - не совпадает, -1 - предшествующие символы совпадают, 0 - полностью совпадает
            Console.WriteLine($"Contains : {secondStringVar.Contains("Sh")}");//наличие подстроки
            Console.WriteLine($"Substring : {secondStringVar.Substring(5)}"); //извлечение подстроки(остаются след элементы)
            Console.WriteLine($"Insert : {secondStringVar.Insert(0, firstStringVar)}");//вставка
            Console.WriteLine($"Replace : {secondStringVar.Replace("#", "Sharp")}");//замена
            #endregion


            #region Задание 6
            Console.ForegroundColor = ConsoleColor.Blue;
            string testStringVar1 = "Hello!";
            string testStringVar2 = null;
            string testStringVar3 = "";
            Console.WriteLine($"Строка 1 {Test(testStringVar1)}");
            Console.WriteLine($"Строка 2 {Test(testStringVar2)}");
            Console.WriteLine($"Строка 3 {Test(testStringVar3)}");
            #endregion


            #region Задание 7
            //var nullstr = "";
            //nullstr = 5;
            #endregion


            #region Задание 8
                Console.ForegroundColor = ConsoleColor.DarkRed;
                int? m = 2;
                m = null;
                Console.WriteLine(m.HasValue);
            #endregion


            #region Задание 1
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Sum(3, 2001));
            #endregion


            #region Задание 2
            Console.ForegroundColor = ConsoleColor.White;
            (string name, int month, int year) MyData = ("Ilya", 03, 2001);
            (string name1, int month1, int year1) MyData1 = MyData;
            Console.WriteLine($"Значение MyData.name : {MyData.name}");
            Console.WriteLine($"Значение кортежа MyData : {MyData}");

            var (_, _, three, four, five) = (1, 2, 3, 4, 5);

            


            #endregion


            #region Задание 3
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int CheckedFunction(int firstapplicant,int secondapplicant)
            {
                return checked(firstapplicant + secondapplicant);
            }

            int UncheckedFunction(int ufirstapplicant, int usecondapplicant)
            {
                return unchecked(ufirstapplicant + usecondapplicant);
            }
           

            Console.WriteLine($"Unchecked : {UncheckedFunction(int.MaxValue, int.MaxValue)}");
            // Console.WriteLine($"Checked : {CheckedFunction(int.MaxValue, int.MaxValue)}");

            #endregion


            Console.ForegroundColor = ConsoleColor.DarkGray;
            using (Example example = new Example(3))
            {
                Console.WriteLine(example.GetState());
            }



          


            Console.ReadKey();
        }
    }
}



//static void Main(string[] args)
//{
//    int i = 5;
//    object o = i;
//    int i2 = (int)o;
//    long l = i;
//    long l2 = (long)i;
//    long l3 = Convert.ToInt64(i);
//    int i3 = l;
//    int i4 = (int)l;
//    string str = string.Empty;
//    string str2 = null;
//    int i5 = null;
//    int? i6 = null;
//    Nullable<int> i7 = 6;
//    int[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
//    Console.WriteLine(array.Length);
//    Console.WriteLine(string.Format("My name is {0}", "Program"));
//    Console.WriteLine($"My name is {"Program"}");
//    Console.WriteLine(5 + 10);
//    string i5String = i5.ToString();
//}