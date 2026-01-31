using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;                        // используем пространство имен System.IO для работы с классом File
using System.Timers;

namespace AllExamples
{
    class Program
    {
        #region                                     Introduction    Вступление
        //_____________________________________________________________________________________________________________
        static void Introduction()
        {

            Console.WriteLine("    Вступление\nТипы данных, Ввод и вывод текста\n");
            // при объявлении (declare)  переменной (variable) мы пишем тип данных (data type) и имя переменной
            // тип данных говорит как именно компьютеру интерпретировать биты. Т.е. 01000001 м.б. числом 65, буквой А, пикселем опред. цвета и т.д.
            // также тип данных определяет доступные для применения операции
            // по правилам написания кода имя переменной начинается с маленькой буквы

            // C# предоставляет следующие встроенные типы значений (value types), которые также называются простыми типами:
            //                  целочисленные типы (int, double  и т.д.), числовые с плавающей точкой (float, double), bool, char
            // Все простые типы являются типами структур

            int age = 5;        // 16 бит   short from -32.768 to 32.767 
                                // 32 бит   int from -2,147,483,648 to +2,147,483,647
                                // 64 бит   long from -9,223,372,036,854,775,808 to +9,223,372,036,854,775,807 
                                                                
            float y = 5.0f; // 4 байта. Суффикс f после литерала означает, что литерал имеет тип float а не double. число с плавающей точкой от ±1,5 x 10^−45 до ±3,4 x 10^38
                            // Литералом называют число или символ, который присваивают переменной
            double z = 5.0; // 8 байт. Число с плавающей точкой двойной точности от ±5,0 × 10^−324 до ±1,7 × 10^308 
            // double z= 5.0f - можно так
            decimal dm = 10.0m;  // decimal - десятичное число с плавающей запятой
            bool isOnline = true;
            char c = 'c';       // 16 bit, Unicode
            string familyName = "Tatarnikov";   // string - встроенный ссылочный тип данных.
                                                // Несмотря на то что string представляет собой ссылочный тип, операторы равенства == и != по определению сравнивают не ссылки, а значения объектов string
                                                // String является неизменяемым типом. То есть каждая операция, которая изменяет объект, на самом деле создает новую строку.
            string s = "High " + 5;             // int 5 неявно преобразуется в string. Неявное преобразование типов, когда компилятор автоматически конвертирует один фундаментальный тип данных в другой
            var name = "Max";   // var  - неявно типизированная переменная
                                // var num; // ошибка
                                // num = 5; // неявно типизированные переменные должны быть сразу инициализированны (указано значение)
            const double PI = 3.14; // при объявлении константы обязательно указать значение (инициализировать)
                                    // значние константы не может быть изменено в ходе выполнения программы
                                    // по правилам написания кода имя константы начинается с Большой буквы
                                    
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();                  // Console.ReadLine() возвращает string
            Console.WriteLine("How old are you?");
            age = Convert.ToInt32(Console.ReadLine());  // Конвертирует string ToInt16, ToInt32, ToInt64, ToDouble, ToBoolean
            Console.WriteLine("Your name is {0}", name);
            Console.WriteLine("You are " + age + " years old");
        }
        #endregion


        #region                                     Mathematics     Арифметические операторы
        //_____________________________________________________________________________________________________________
        static void Mathematics()
        {

            Console.WriteLine("\n\n    Арифметические операторы\n");
            int x = 14;
            int y = 5;
            double z = 5.0;

            Console.WriteLine(x + y);   // output: 19
            Console.WriteLine(x - y);   // output: 9
            Console.WriteLine(x * y);   // output: 70
            Console.WriteLine(x / y);   // деление без остатка. output: 2
            Console.WriteLine(x % y);   // остаток от деления. output: 4
            Console.WriteLine(x / z);   // чтобы ответ был с цифрами после запятой нужно чтобы один или оба операнда были double (float). output: 2,8

            x += 2;                 // x = x + 2
            Console.WriteLine("\n" + x);            // output: 16
            x -= 2;                 // x = x - 2
            Console.WriteLine(x);                   // output: 14
            x *= 2;                 // x = x * 2
            Console.WriteLine(x);                   // output: 28
            x /= 2;                 // x = x / 2
            Console.WriteLine(x);                   // output: 14
            x %= 2;                 // x = x % 2
            Console.WriteLine(x);                   // output: 0
            x++;                    // x = x + 1
            Console.WriteLine(x);                   // output: 1
            x--;                    // x = x - 1
            Console.WriteLine(x);                   // output: 0

            x = 5;
            x--;     // декремент
            y = x++; // постфиксный инкремент - сначала выполняет выражение, затем инкементирует
            Console.WriteLine("\n" + y + " " + x);  // output: 4 5
            y = ++x; // префиксный инкремент - сначала инкементирует, затем выполняет выражение
            Console.WriteLine(y + " " + x);         // output: 6 6
        }
        #endregion


        #region                                     Conditions      Условные операторы и циклы
        //_____________________________________________________________________________________________________________
        static void Conditions()
        {
            Console.WriteLine("\n\n    Условные операторы и циклы\n");
            int x = 5;
            int y = 10;
            int age = 18;

            // условные операторы if else 
            if (x > y)                      // > < >= <= == !=
            {
                Console.WriteLine(x);
            }
            else if (x < y)                 // по усмотрению
            {
                Console.WriteLine(y);
            }
            else                            // по усмотрению
            {
                Console.WriteLine("Error");
            }

            if (x > y)
                Console.WriteLine(x);       // когда в скобках {} одно выражение, скобки можно не ставить
            else if (x < y)
                Console.WriteLine(y);
            else
                Console.WriteLine("Error");


            // оператор switch
            switch (age)
            {
                case 0:
                    Console.WriteLine("Newborn");
                    break;
                case 18:
                    Console.WriteLine("Adult");
                    break;
                case 60:
                    Console.WriteLine("Old");
                    break;
                default:                                        // default по усмотрению. Вызывается когда не один из случаев не подходит
                    Console.WriteLine("Match is not found");
                    break;
            }


            // цикл while. Будет выполняться пока не выполнится условие. Удобно использовать когда не знаешь сколько раз цикл будет выполняться.
            Console.WriteLine();
            x = 5;
            while (x < 8)
            {
                Console.Write(x + " ");     // output: 5 6 7
                x++;
            }
            Console.WriteLine();
            y = 10;
            while (y++ <= 12)   // или ++y
            {
                Console.Write(y + " ");     // output: 11 12 13
            }

            Console.WriteLine("\nEnter the number between 0 and 20");
            int xWhile = Convert.ToInt32(Console.ReadLine());
            while (xWhile<0 || xWhile > 20) // пока условие не выполнится, цикл будет продолжаться
            {
                Console.WriteLine("Enter the number between 0 and 20");
                xWhile = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("You entered: " + xWhile);

            // цикл for. Удобно использовать когда количество итераций известно заранее
            Console.WriteLine("\n");
            for (int i = 0; i <= 10; i += 2)
            {
                Console.Write(i + " ");     // output: 0 2 4 6 8 10
            }
            Console.WriteLine("\n");
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + " ");     // output: 5 4 3 2 1
            }
            Console.WriteLine("\n");
            x = 5;
            for (; x < 8;) // initials and increment can be thown away   // for { ; ; } {} - бесконечный цикл
            {
                Console.Write(x + " ");     // output: 5 6 7
                x++;
            }


            // цикл do while - в отличие от while сначала делает, а потом проверяет условие
            int q = 5;
            Console.WriteLine();
            do
            {
                Console.WriteLine(q);       // output: 5
                q++;
            } while (q < 4);


            // break и continue 
            x = 2;
            Console.WriteLine();
            while (x < 8)
            {
                if (x == 5)
                {
                    break;                  // прекращает выполнение цикла
                }
                Console.Write(x + " ");     // output: 2 3 4
                x++;
            }

            x = 2;
            Console.WriteLine();
            while (x < 7)
            {
                x++;
                if (x == 5)
                {
                    continue;               // программа встечая continue прекращает данную итерацию цикла и переходит на следующую
                }
                Console.Write(x + " ");     // output: 3 4 6 7
            }


            // логические операторы 
            // && - И, || - ИЛИ, ! - НЕ
            int a = 10;
            int b = 20;
            int c = 30;
            Console.WriteLine("\n");
            if ((a == 10 && b == 0) || c == 30) // скобками () можно указать очередность выполнения логических операций
            {
                Console.WriteLine("Coincidence");
            }
            if (!(a < 5))
            {
                Console.WriteLine("Cool");
            }


            // оператор ?
            Console.WriteLine();
            age = 42;
            string msg;
            msg = (age >= 18) ? "Welcome" : "Sorry";    // Оператор ? заменяет  
                                                        //    if (age >= 18)
                                                        //        msg = "Welcome";
                                                        //    else
                                                        //        msg = "Sorry";
            Console.WriteLine(msg);


            // Цикл foreach. Удобно использовать для работы с массивами и коллекциями
            Console.WriteLine();
            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (int k in arr)
            {
                Console.Write(k + " ");
            }

            Console.WriteLine();

            // мы не можем изменять List (и другие коллекции) внутри цикла foreach. Для этого нужно использовать другие циклы
            List<int> listForEach = new List<int>();
            listForEach.Add(1);
            listForEach.Add(2);
            listForEach.Add(3);
            foreach (int i in listForEach)
            {
                Console.WriteLine(i);
                //listForEach.Remove(i); // Нельзя. Цикл поломается
            }

        }
        #endregion


        #region                                     Arrays          Массивы
        //_____________________________________________________________________________________________________________
        static void Arrays()    // Масиивы это встроенный класс для управления и хранения данными. Коллекция переменных одного типа
        {
            Console.WriteLine("\n\n\n    Массивы\n");
            int[] myArray = new int[5];                                     // создаем новый экземпляр объекта "Массив"
            myArray[0] = 23;                                                // присваиваем первому элементу значение 23
            double[] a = new double[4] { 3.2, 2.42, 7.62, 8.9 };            // можно предоставить начальные значения элементов массива при его объявлении

            string[] names1 = new string[3] { "John", "Mary", "Jessica" };  // 
            string[] names2 = new string[] { "John", "Mary", "Jessica" };   // при этом объявление длинны [] массива 
            string[] names3 = { "John", "Mary", "Jessica" };                //    и оператор new можно опустить. Все 3 записи эквивалентны

            int[] b = { 5, 12, 56, 48, 33 };
            Console.WriteLine(b[2]);        // Output 56 

            int[] intArr1 = { 1, 2, 3 };
            int[] intArr2 = intArr1;
            intArr1[1] = 10;
            Console.WriteLine("intArr1[1]: " + intArr1[1]);     // Output 10    т.к. массивы ссылочный тип данных и при копировании массива мы копируем не сам массив
            Console.WriteLine("intArr2[1]: " + intArr2[1]);     // Output 10    а ссылку в стеке (адрес объекта) на местоположение объекта в куче.
                                                                //              Мы сейчас вызываем и выводим одно и то же число 

            // задание и чтение данных массива с помощью циклов
            Console.WriteLine();
            int[] fib = new int[10];
            fib[0] = 1;
            fib[1] = 1;
            for (int i = 2; i < 10; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];   // послед. Фибоначчи
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(fib[i] + " ");// output: 1 1 2 3 5 8 13 21 34 55
            }

            // Цикл foreach - короткий и быстрый доступ к элементам массива
            Console.WriteLine();
            foreach (var i in fib)          // для каждого элемента в массиве fib. i=fib[0], i=fib[1] и т.д. Лучше писать var чтобы программа сама подбирала тип данных массива
            {
                Console.Write(i + " ");     // output: 1 1 2 3 5 8 13 21 34 55
            }

            // Многомерные массивы
            Console.WriteLine("\n");
            int[,] x = new int[3, 4];                       // двумерный массив 3 строки (rows) 4 столбца (columns)
            int[,] y = { { 1, 2 }, { 3, 4 }, { 5, 6 } };    // 3 строки 2 столбца (3 строки по 2 элемента в каждой). действуют такие же методы инициализации как и при одномерном массиве
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(y[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Ступенчатые (зубчатые) массивы
            // элементами такого массива являются массивы. Массив массивов
            Console.WriteLine();
            int[][] jaggedArr = new int[][]
                {
                    new int[] { 1, 2},              //  задаем элементы первого массива
                    new int[] { 3, 4, 5},           //  через запятую задаем элементы второго массива
                    new int[] { 6, 7, 8 ,9, 10}     // и третьего
                };
            int[][] jaggedArr2 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 6, 7 } };   // чтобы понятнее было. также как для одномерных массивов, только каждый элемент массива тоже массив
            int[][] jaggedArr3 = { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 6, 7 } };            // new int[][] также можно убрать
            int[][,] jaggedArr4 = new int[8][,];    // ступенчатый массив, содержащий 8 двумерных массивов

            Console.WriteLine(jaggedArr[2][1]);     // доступ ко второму элементу третьего массива jaggedArr. Output 7


            // Свойства Length и Rank. Методы Max, Min, Sum
            // доступ к свойствам и методам как и у других классов через точку

            Console.WriteLine();
            int[] newArr1 = { 8, 13, 23, 42 };
            Console.WriteLine("Length of newArr1 is " + newArr1.Length);// Output: 4
            Console.WriteLine("Rank of newArr1 is " + newArr1.Rank);    // Output: 1
            Console.WriteLine("Max value is " + newArr1.Max());         // Output: 42. Не забывать про скобки. *.Max(), .Min(), *.Sum() - это методы, а не свойства
            Console.WriteLine("Min value is " + newArr1.Min());         // Output: 8. методы  *.Max(), .Min(), *.Sum() - используются только для одномерных массивов
            Console.WriteLine("Sum is " + newArr1.Sum());               // Output: 86

            Console.WriteLine();
            int[,] newArr2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            Console.WriteLine("Length of newArr2 is " + newArr2.Length);// Output: 8. Восемь элементов
            Console.WriteLine("Rank of newArr2 is " + newArr2.Rank);    // Output: 2. Две строки
            for (int i = 0; i < newArr2.Rank; i++)
            {
                for (int j = 0; j < newArr2.Length / newArr2.Rank; j++)
                {
                    Console.Write(newArr2[i, j] + " ");                 // Output:  1 2 3 4 
                }                                                       //          5 6 7 8 
                Console.WriteLine();
            }

            // Strings. Строки это объекты. Cтроковая переменная является объектом класса String. Класс String является массивом объектов Char
            // при объявлении переменной типа string, мы создаем объект типа String.
            // класс String реализует индексатор, так что мы можем получить доступ к любому символу (объекту Char) по его индексу
            // Свойства и Методы строковых объектов
            Console.WriteLine();

            string str = "some text";

            Console.WriteLine(str[3]);                  // Output: e

            Console.WriteLine(str.Length);              // количество символов в строке
                                                        // Output: 9            
            Console.WriteLine(str.IndexOf('t'));        // индекс первого указанного символа
                                                        // Output: 5
            str = str.Insert(0, "This is ");            // Insert(index, value) вставка
            Console.WriteLine(str);                     // Output: This is some text

            str = str.Replace("This is", "I am");       // Replase(oldValue, newValue) замена
            Console.WriteLine(str);                     // Output: I am some text

            if (str.Contains("some"))                   // true/false. поиск заданного текста
                Console.WriteLine("found");             // Output: found

            str = str.Remove(4);                        // Удаляет все символы после указанного
            Console.WriteLine(str);                     // Output: I am

            str = str.Substring(2);                     // Substring(index, value). Возвращает строку заданной длины начиная с указанного символа (до конца, если не указано value)            Console.WriteLine(str);
                                                        // Output: am
        }
        #endregion


        #region                                     Methods         Методы
        //_____________________________________________________________________________________________________________ 
        public static int Sqr(int x)
        // public - аксессор доступа
        // static - значит метод относится к классу, а не к его экземплярам
        // int - возвращаемый тип данных (если в конце метода есть return, если нет то void)
        // Sqr - имя метода. По правилам начинается с Большой буквы
        // (int x) - параметр метода                                
        // Sqr(int x) - назвается сигнатурой метода Сигнатура складывается из следующих аспектов: Имя метода, Количество параметров, Типы параметров, Порядок параметров, Модификаторы параметров
        {
            int result = x * x;
            return (result);                            // для возвращаемых типов методов
        }

        static void SayHi()                             // Ничего не возвращает. Просто выполняется
        {
            Console.WriteLine("Hi!");
        }

        static void PrintLn(int x)
        {
            Console.WriteLine(x);
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Power(int x, int y = 2)              // для необязательных параметров можно установить значения по умолчанию
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }

        static int Area(int w, int h)
        {
            return w * h;
        }

        // Передача аргументов:
        static void Sqr1(int x)                         // по значению
        {
            x = x * x;
        }
        static void Sqr2(ref int x)                     // по ссылке
        {
            x = x * x;
        }
        static void GetValues(out int x, out int y)     // в качестве вывода. Удобно, когда нужно вернуть не один параметр а несколько
        {
            x = 10;
            y = 5;
        }

        // Перегрузка методов: - это когда несколько методов имеют одинаковые имена, но разные параметры
        // При перегрузке методов, их определения должны отличаться друг от друга типом и/или количеством переметров
        static void Print(int a)
        {
            Console.WriteLine("Value 1: " + a);
        }
        static void Print(double a)
        {
            Console.WriteLine("Value 2: " + a);
        }
        static void Print(string label, double a)
        {
            Console.WriteLine(label + a);
        }

        // Рекурсия: рекурсивный метод - метод вызывающий сам себя
        static int Fact(int x)  // Факториал
        {
            if (x == 1)
            {
                return 1;
            }
            return x * Fact(x - 1);
        }

        static void Methods()
        {
            Console.WriteLine("\n\n    Методы\n");

            Console.WriteLine(Sqr(5));                          // Output: 25
            SayHi();                                            // Output: Hi!
            PrintLn(6);                                         // Output: 6
            Console.WriteLine("Sum is " + Sum(3, 2));           // Output: Sum is 5
            Console.WriteLine(Power(3));                        // Output: 9.  3 возводится во 2 степень. Второй аргумент не обязательный, так как он уже задан по умолчанию
            Console.WriteLine(Power(3, 4));                     // Output: 81. 3 возводится в 4 степень 
            Console.WriteLine("Area is " + Area(5, 4));         // Output: Area is 20
            Console.WriteLine("Area is " + Area(w: 3, h: 4));   // Output: Area is 12. использование именованных аргументов
            Console.WriteLine("Area is " + Area(h: 5, w: 5));   // Output: Area is 25. в любом порядке

            // Передача аргументов:
            Console.WriteLine();
            int x = 5;
            // передача по значению
            Sqr1(x);
            Console.WriteLine(x);// Output: 5 - потому что Sqr1 просто выполняется, не присваивая новое значение х
            //Console.WriteLine(Sqr1(x)); // error. Потому что Sqrt() - void - выполняется, ничего не возвращая
            // передача по ссылке
            Sqr2(ref x);                // ref - ссылка на ячейку памяти в которой хранится переменная, поэтому переменной присваивается новое значение
            Console.WriteLine(x);       // Output: 25
            // передача с модификатором out
            int a, b;
            GetValues(out a, out b);    // присваивает a и b значения из GetValues 
            Console.WriteLine("a is " + a + ". b is " + b);     // Output: a is 10. b is 20

            // Перегрузка методов:
            Console.WriteLine();
            Print(5);
            Print(6.2);
            Print("Averege: ", 5.6);

            // Рекурсия
            Console.WriteLine();
            Console.WriteLine(Fact(5));
        }
        #endregion


        #region                                     Classes         Классы
        //_______________________________________________________________________________________________________________
        // Объекты реального мира имеют характеристики (размер, форма, возраст, цена, цвет и т.д.) и поведение (что этот объект может делать).
        // Класс является шаблоном для создания объектов. Класс определяет характеристики и поведение объеков класса.
        // Состояние (state) объекта хранится в полях (fields). Полями называют переменные внутри объекта.
        // Свойства (properties) предоставляют доступ к состоянию объекта
        // Методы (methods) предоставляют доступ к поведению объекта
        // Другими словами - Класс является пользовательским типом данных, определяющим набор переменных и методов для объявленного объекта
        // Стек (stack - стопка) и куча (heap - куча) – хранилища памяти. Оба хранилища расположены в оперативной памяти. При объявлении переменной (создании объекта) она занимает кусочек оперативной памяти. 
        // При создании объекта типа значения (value type), выделяется память строго определенного размера в стеке (например для хранения переменной типа int32 выделяется 32 бита) Стек используется для статического выделения памяти.
        // При создании объекта ссылочного типа (reference type) в стеке выделяется память для хранения ссылки на место в куче, где будет храниться объект. Куча используется для динамического выделения памяти.
        // Так как место в куче заранее не ограничивается, можно создавать объекты, размер которых будет увеличиваться в процессе выполнения программы (например List, string, экземпляры классов и т.п.)

        // Инкапсуляция (incapsulating) - сокрытие информации, объединение состояния объекта и методов вместе. Используется для защиты содержимого объекта и предоставления доступа через свойства и методы
        // Инкапсуляция реализуются с помощью модификаторов доступа
        // Модификаторы доступа: public - делает элемент класса доступным снаружи
        //                       private - делает элемент класса доступным только изнутри класса
        //                       protected - делает тип или элемент класса доступным только для кода этого же класса или структуры, а также для класса, наследованного от него
        //                       internal, protected internal.              По умолчанию (если не задать) устанавливается модификатор private

        class Person
        {
            public int age;
            private string name;                // приватная переменная не может быть изменена или прочтена на прямую. Только с помощью других методов

        // Конструктор - специальный метод класса, который имеет такое же имя как и сам класс. Используется для инстанцирования (создания объектов класса).
        // Конструктор выполняется автоматически при создании объекта класса. Данный метод ничего не возвращает (void, int и т.д. не пишем)
            public Person(string nm)            // Конструктор (это метод). Вызывается автоматически при создании экземпляра данного класса
            {
                name = nm;
            }
        // Методы - предоставляют доступ к поведению объекта
            public string GetName()             // создадим метод GetName, который дает доступ к полю (переменной) name
            {
                return name;
            }
            public void SayHi()
            {
                Console.WriteLine("Hi!");
            }
        }

        class BankAccount
        {
            public BankAccount()                // Конструктор (это метод). Вызывается автоматически при создании экземпляра данного класса
            {
                Console.WriteLine("Hi new user");
            }

            ~BankAccount()                      // Деструктор (это метод). Вызывается автоматически при удалении экземпляра данного класса (в том числе при закрытии программы)
            {
                Console.WriteLine("Good bye!");
            }

            private int balance = 0;            // Изменение баланса возможно только посредством методов Deposite и Withdrawal
            public void Deposite(int a)
            {
                balance += a;
            }
            public void Withdrawal(int a)
            {
                balance -= a;
            }

            public void PrintBalance()
            {
                Console.WriteLine("Your balance is " + balance);
            }

        }


        // Свойство - элемент предоставляющий гибкий механизм чтения, записи и вычисления значения приватного поля
        // свойства включают специальные методы, называемые элементами доступа. 
        // со свойствами есть возможность контролировать логику доступа к переменной
        // элементы доступа get, set
        class Man
        {
            private string name;        // name  - приватное поле (элемент) (приватная переменная)
            private string fname;       // fname - приватный поле (элемент) (приватная переменная)
            private int age;            // age   - приватное поле (элемент) (приватная переменная)
            public string Name          // свойство Name. Имя свойства как и у методов начинается с Большой буквы. При вызове свойства скобки () не ставятся
            {
                get { return name; }    // элемент доступа get используется для возвращения значения переменной name.  Структура - get { return **; }
                set { name = value; }   // элемент доступа set используется для присвоения значения к переменной name. Структура - set { ** = value; }
            }
            public string FamilyName
            {
                get { return fname; }   // любой из элементов доступа может быть опущен
            }
            public int Age
            {
                get { return age; }
                set                     // публичное свойство Age позволяет осуществлять контроль доступа к приватной переменной age
                {
                    if (value > 0)      // к примеру можно провести проверку значения до присвоения
                        age = value;
                    else
                        Console.WriteLine("Wrong age");
                }
            }
        }

        // Автоматически реализуемые свойства
        class Man2
        {
            //private string name;              // не нужно объявлять, приватный элемент создается автоматически свойством Name
            public string Name { get; set; }    // Name - автоматически реализуемое свойство, позволяет легко и кратко объявлять приватные элементы
                                                // заменяет get { return **; }
                                                //          set { ** = value; } 
                                                // Удобно использовать, когда не нужна никакая другая пользовательская логика
        }

        // static - Статические элементы (переменные, свойства, методы) принадлежат классу а не его экземплярам 
        class Cat
        {
            static public int count = 0;    // статические переменные принадлежат самому классу а не его экземплярам. Имена переменных обычно пишут маленькими буквами
            public const int PAWS = 4;      // константы являются статическими по определению и не требуют указания static. Имена констант обычно пишут БОЛЬШИМИ буквами
            public string name;
            static public void Say()        // статические методы принадлежат самому классу а не его экземплярам. Имена методов обычно пишут с Большой буквы
            {
                Console.WriteLine("Meou");
            }
            public Cat()
            {
                count++;
            }
        }

        // Целый класс может быть объявлен статическим. В статическом классе все члены тоже статические. Нельзя создавать экземпляры статического класса
        // статические классы полезны для комбинации логических свойств и методов (например класс Math)
        static class MyMath
        {
            static public int Pow(int x, int y)
            {
                int res = 1;
                if (y == 0)
                    return res;
                else
                {
                    for (int i = 0; i < y; i++)
                    {
                        res *= x;

                    }
                    return res;
                }
            }

        }

        // ключевое слово this
        // используется внутри класса и ссылается на текущий экземпляр класса
        // исп. для разделения элементов класса от других данных, типа локальных или формальных параметров метода и т.д.
        class Person2
        {
            private string name;
            public Person2(string name)
            {
                this.name = name;           // слово this ссылается на private string name; this.name представляет собой элемент класса, name - параметр корструктора 
            }
            //public Person2(string nm)     // тоже самое
            //{
            //    name = nm;
            //}
        }

        // модификатор readonly
        class Person3
        {
            private readonly string name = "John";          // Модификатор readonly защищает элементы класса от модификации после построения
            private readonly string name2;                  // элемент класса с модификатором readonly может быть модифицирован только при его объявлении или внутри конструктора
            private readonly double c = Math.Sin(60);       // 3 отличия readonly от const. 1) const должна быть инициализирована при объявлении. а поле только для чтения может быть объявленио без инициализации 
            const double PI = 3.14;                         // 2) поле readonly может быть изменено в конструкторе. 3) readonly может быть присвоен результат вычислений
            //const double a;                               // error
            //const double b = Math.Sin(60);                // error
            public Person3(string name)
            {
                this.name = name;           // слово this ссылается на private string name; this.name представляет собой элемент класса, name - параметр корструктора 
            }
        }

        // индексаторы 
        class Clients                               // использование индексатора характерно, если класс представляет собой массив (список, коллекцию) объектов
        {
            private string[] names = new string[10];
            public string this[int index]           // ключевое слово this ссылается на имя объекта класса Clients.
            {                                       // обычно мы пишем: string[] names3 = { "John", "Mary", "Jessica" }; 
                get { return names[index]; }        //                  Console.WriteLine(names[1]); // output: Mary
                set { names[index] = value; }       // но здесь мы создаем Класс у которого names приватное поле. С помощью индексатора мы получаем доступ к этому полю.
            }                                       //                  Clients c = new Clients();
                                                    //                  c[1] = "Mary";
        }                                           //                  Console.WriteLine(c[1]);     // output: Mary

        // перегрузка операторов. Переопределение функции операторов для выполнения других действий
        // все арифметические операторы и операторы сравнения могут быть перегружены. При перегрузке оператора >, оператор < также должен быть определен
        class Box
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public Box(int h, int w)
            {
                Height = h;
                Width = w;
            }
            public static Box operator +(Box a, Box b)
            {
                int h = a.Height + b.Height;
                int w = a.Width + b.Width;
                Box res = new Box(h, w);
                return res;
            }
        }

        // пример красиво написанного Класса
        class Students
        {
            #region Fields

            private int numOfStudents;
            List<Person> studentsList = new List<Person>();

            #endregion

            #region Constructors
            public Students(int numOfStudents)      // { } - поле видимости private переменной, в котором она была создана. В данном случае 
            {                                       // переменная int numOfStudents заменяет переменнуюкласса с таким же названием. 
                this.numOfStudents = numOfStudents; // Для доступа к перем. класса мы используем ключевое слово this
                for (int i = 0; i < numOfStudents; i++)
                {
                    studentsList.Add(new Person("Student" + (char)(48 + i)));
                    //personsArr[i+1] = new Person("Student" + (char)(48 + i));
                }
            }
            public Students() : this(20)            // к примеру создание стандартного класса на 20 человек
            {

            }
            #endregion

            #region Properties

            public int NumOfStudents
            {
                get { return numOfStudents; }
            }

            #endregion

            #region Public methods

            public Person Student(int i)
            {
                return studentsList[i];
            }

            #endregion
        }

        static void Classes()
        {
            Console.WriteLine("\n\n    Классы\n");

            Person p1 = new Person("Egor"); // создание объекта p1 (инстанциация) через конструктор - создание экземпляра класса Person
            // Person - тип данных (класс)
            // p1 - имя объекта
            // new Person("Egor") - вызов конструктора и передача аргумента

            int example = new int();        // это не ошибка, мы действительно можем объявить переменную таким образом
            
            Students students = new Students(5);    // создание класса с 5 студентами
            Person pNew = students.Student(1);      // также экземпляры класса можно создавать таким образом. Создаем экземпляр класса Person
            Console.WriteLine("The name of the first student: " + pNew.GetName());

            p1.SayHi();                     // Output: Hi!
            p1.age = 25;                    // name и age свойства объекта p1
            Console.WriteLine("Your name is " + p1.GetName());      // Your name is Egor. public GetName() -  - дает доступ к private name
            Console.WriteLine("You are " + p1.age + " years old");  // You are 25 years old. public age


            Console.WriteLine();
            BankAccount Account1 = new BankAccount();
            Account1.PrintBalance();        // Output: Your balance is 0
            Account1.Deposite(250);         // Особенности терминологии: у метода Deposite(int a) есть параметр 'a', но в метод Deposite(int а) мы передаем аргумент 250
            Account1.PrintBalance();        // Output: Your balance is 250
            Account1.Withdrawal(100);
            Account1.PrintBalance();        // Output: Your balance is 150

            Console.WriteLine();
            Man p2 = new Man();
            p2.Name = "Egor";
            Console.WriteLine(p2.Name);     // Output: Egor
            p2.Age = -5;                    // Output: Wrong age
            p2.Age = 16;
            Console.WriteLine(p2.Age);      // Output: 16

            Console.WriteLine();
            Man2 p3 = new Man2();
            p3.Name = "Egor";
            Console.WriteLine(p3.Name);     // Output: Egor

            Cat Barsic = new Cat();
            Cat Masha = new Cat();
            Console.WriteLine("\nNumber of paws is " + Cat.PAWS);       // Output: 4. Не Barsik.paws. const paws is static
            Console.WriteLine("Ammount of cats is " + Cat.count);       // Output: 2. Не Masha.count. count is static и принадлежит самому классу, а не его объектам
            Barsic.name = "Barsic";                                     // Output: Barsic. name isn't static
            Console.WriteLine(Barsic.name);
            Cat.Say();                                                  // Output: Meou. Say() is static. Доступ к статическим членам получают с помощью имени класса (не объекта)

            Console.WriteLine("\n" + MyMath.Pow(2, 4));                 // Output: 16. Cтатический метод MyMath

            // Встроенные статические классы (и их методы и свойства), доступные в С#

            Console.WriteLine("\nMath");
            Console.WriteLine(Math.PI);                         // Output: 3,14159.....
            Console.WriteLine(Math.E);                          // Output: 2,71828.....
            Console.WriteLine(Math.Max(2, 5));                  // Output: 5
            Console.WriteLine(Math.Min(2, 5));                  // Output: 2
            Console.WriteLine(Math.Abs(5.64));                  // Output: 5,64
            Console.WriteLine(Math.Round(5.64));                // Output: 6
            Console.WriteLine(Math.Sin(30 * Math.PI / 180));    // Output: 0,5          Sin (double d) можно вводить не double
            Console.WriteLine(Math.Cos(30 * Math.PI / 180));    // Output: 0,866......  Cos (double d) 
            Console.WriteLine(Math.Pow(2, 3));                  // Output: 8
            Console.WriteLine(Math.Sqrt(9));                    // Output: 3

            Console.Write("Enter angle in degrees: ");
            float angle = float.Parse(Console.ReadLine());
            angle *= (float)Math.PI / 180;                      // приводим тип double к типу float
            Console.WriteLine("Cosine: " + Math.Cos(angle));
            Console.WriteLine("Sine:   " + Math.Sin(angle));

            Console.WriteLine("\nArray");
            int[] arr = { 1, 2, 3, 4 };
            Array.Reverse(arr);
            foreach (int k in arr)
                Console.Write(k + " ");                     // Output: 4 3 2 1
            Array.Sort(arr);
            Console.WriteLine();
            foreach (int k in arr)
                Console.Write(k + " ");                     // Output: 1 2 3 4

            Console.WriteLine("\n\nString");
            string s1 = "some text";
            string s2 = "another text";
            if (String.Equals(s1, s2) == false)             // сравнивает две строки
            {
                Console.WriteLine(String.Concat(s1, s2));   // объединяет две строки
            }

            Console.WriteLine("\nDateTime");
            Console.WriteLine(DateTime.Now);                    // Output: 09.11.2020 12:05:12
            Console.WriteLine(DateTime.Today);                  // Output: 09.11.2020 00:00:00
            Console.WriteLine(DateTime.DaysInMonth(2020, 2));   // Output: 29

            // индексаторы позволяют объектам индексироваться как массив
            string str = "Hello World";     // строковая переменная на самом деле является объектом класса String. класс String является массивом объектов Char
            char ch = str[6];               // класс String реализует индексатор, так что мы можем получить доступ к любому символу (объекту Char) по его индексу
            Console.WriteLine("\n" + ch);   // Output: W

            Clients c = new Clients();
            c[0] = "Bob";
            c[1] = "Marley";
            Console.WriteLine("\n" + c[0] + " " + c[1]);// Output: Bob Marley

            // перегрузка операторов
            Box b1 = new Box(14, 3);
            Box b2 = new Box(5, 7);
            Box b3 = b1 + b2;
            Console.WriteLine("\n" + b3.Height);        // Output: 19
            Console.WriteLine(b3.Width);                // Output: 10
        }
        #endregion


        #region                                     Inheritance     Наследование и полиморфизм     
        //____________________________________________________________________________________________________________________________
        // Наследование позволяет нам определить класс, основанный на другом классе.
        // C# не поддерживает множественное наследование (наследование от нескольких классов). 
        // множественное наследование можно реализовать с помощью интерфейсов

        class Animal0                           // Базовый (Base) класс 
        {
            public int Legs { get; set; }       // свойство базового класса
            public int Age { get; set; }        // свойство базового класса
        }
        class Dog0 : Animal0                    // Производный (Derived) класс. (имя производного класса : имя базового класса)
        {
            public Dog0()
            {
                Legs = 4;                       // производный класс наследует все члены базового класса
            }
            public void Bark()                  //      и может иметь свои переменные, свойства и методы
            {
                Console.WriteLine("Woof");
            }
        }

        // модификатор protected
        class Animal1
        {
            protected string Name { get; set; } // protected - делает тип или элемент класса доступным только для кода этого же класса или структуры, а также для класса, наследованного от него
            public int Age { get; set; }
        }
        class Dog1 : Animal1
        {
            public Dog1(string nm)
            {
                Name = nm;
            }
            public void SayName()
            {
                Console.WriteLine("Name: " + Name);
            }
            public Dog1 Clone()                         // Создаем метод для копирования объекта
            {
                return (Dog1)this.MemberwiseClone();    // MemberwiseClone() - Creates a shallow copy of the current Object.
            }
        }


        // Модификатор sealed защищает класс от наследования
        sealed class Animal2            // запечатанный класс - защищен от наследования
        {
        }
        //class Dogs2 : Animal2 { }     // Error. Нельзя создавать производные классы от запечатанных классов


        // конструкторы и деструкторы базовых и производных классов
        class Animal3
        {
            public Animal3()
            {
                Console.WriteLine("Animal created");
            }
            ~Animal3()
            {
                Console.WriteLine("Animal deleted");
            }
        }
        class Dog3 : Animal3
        {
            public Dog3()
            {
                Console.WriteLine("Dog created");
            }
            ~Dog3()
            {
                Console.WriteLine("Dog deleted");
            }
        }
        class Dog4 : Animal3
        {
            public Dog4() : base()  // Наследование конструктора базового класса. base() - отсылает к конструктору базового класса. 
            {

            }
        }

        // Полиморфизм - означает, что метод базового класса может иметь различные реализации в производных классах
        // это как перегрузка метода, только не внутри одного класса, а производных классах

        // ключевое слово virtual
        // ключевое слово override
        // виртуальные методы озволяют работать с группами связанных объектов универсальным способом
        class Shape0                    // базовый класс Shape
        {
            public virtual void Draw()  // виртуальный метод Draw(). virtual позволяет переписывать методы в производных классах
                                        // возвращаемый тип менять нельзя
            {
                Console.WriteLine("Base Draw");
            }
        }
        class Circle0 : Shape0
        {
            public override void Draw() // перепишем метот Draw() для производного класса
            {
                Console.WriteLine("Circle Draw");
            }
            public void RubTheCircle()
            {
                Console.WriteLine("Circle is rubbed");
            }
        }
        class Rectangle0 : Shape0
        {
            public override void Draw()
            {
                Console.WriteLine("Rectangle Draw");
            }
        }
        class NewShape0 : Shape0        // нет обязанности переписывать метод Draw(). Можно оставить базовую реализацию
        {
        }
        class SomeShape0 : Shape0
        {
            public override void Draw()
            {
                base.Draw();            // оставил базовую реализацию метода
                // some code            // но можно дописать еще дополнительные функции
            }
        }

        // ключевое слово abstract
        // Когда нет необходимости прописывать виртуальный метод (свойство) в базовом классе можно создать абстрактрый метод (свойство)
        // В этом случае производные классы обязаны определить все абстрактные элементы самостоятельно.
        // так как элементы такого класса абстрактные и не имеют ни каких функций, мы не можем создавать экземпляры этого класса и сам класс является абстрактным
        // объявление абстрактных методов разрешено только в абстрактных классах 
        // sealed abstract class - impossible. Данные модификаторы имеют противоположные значения. sealed предотвращает наследование. abstract принуждает наследование
        abstract class Shape1
        {
            int x = 5;                      // абстрактный класс может содержать:   переменные
            public int Value { get; set; }  //                                      не абстактные свойства
            public void Sum()               //                                      не абстрактные методы
            {
                // some code;
            }
            public abstract void Draw();    // абстрактный метод Draw() не имеет тела {} так как ничего не выполняет
        }
        class Circle1 : Shape1
        {
            public override void Draw()
            {
                Console.WriteLine("Circle Draw");
            }
        }
        class Rectangle1 : Shape1
        {
            public override void Draw()
            {
                Console.WriteLine("Rectangle Draw");
            }
        }

        // Интерфейсы
        // ключевое слово interface
        // Интерфейс - полностью абстрактный класс имеющий только абстрактные члены
        // все члены интерфейса абстрактные, поэтом нет необходимости использовать ключевое слово abstract
        // также все члены интерфейса public, никакие другие модификаторы доступа не могут быть применены 
        // интерфейсы могут содержать свойства и методы. Но, в отличие от абстрактных классов, не могут содержать поля (переменные)
        public interface IShape2    // имя интерфейса принято начинать с заглавной буквы I
        {
            void Draw();
        }
        public interface IPrint2
        {
            void Print();
        }
        class Circle2 : IShape2     // класс Circle2 "реализует интерфейс" IShape2 (в отличие от "наследуется от класса")
        {
            public void Draw()      // ключевое слово override не требуется
            {
                Console.WriteLine("Circle Draw");
            }
        }
        class Rectangle2 : IShape2, IPrint2 // класс может реализовывать несколько интерфейсов одновременно (в отличие от наследования)
        {
            public void Draw()
            {
                Console.WriteLine("Rectangle Draw");
            }
            public void Print()
            {
                Console.WriteLine("Print Rectangle");
            }

        }

        // Вложенные классы: класс который является членом другого класса
        class Car               // класс Car сам является вложенным классом класса Program. По умолчанию protected. 
                                // но так как вся программа выполняется внутри класса Program, вложенный класс Car доступен без модификатора private
        {
            public string Model { get; set; }
            public int Year { get; set; }
            Motor m0 = new Motor();             // можно не писать, если не надо для выполнения программы
            public class Motor                  // вложенный класс выступает как член класса, поэтому может иметь модификаторы доступа
            {
                public string MotorName { get; set; }
            }
        }

        // пространство имен namespace
        // namespace AllExamples - вся программа находится внутри пространста имен AllExamples
        // namespace  - область содержащая набор связных объектов
        // ключевое слово using означает, что программа использует пространство имен
        // к примеру: using System - мы используем пространство имен System, в котором определен класс Console
        // System.Console.WriteLine(); - без выражения using System нам бы пришлось каждый раз писать пространство имен, где класс Console будет использоваться
        // можно определять собственные пространства имен и использовать их будущих программах

        static void Inheritance()
        {
            Console.WriteLine("\n\n    Наследование и полиморфизм\n");

            Dog0 d0 = new Dog0();
            Console.WriteLine(d0.Legs);     // Output: 4
            d0.Bark();                      // Output: Woof

            Dog1 d1 = new Dog1("Bobik");
            //Console.WriteLine(d1.Name);   // Error. Потому что свойство Name - protected. Нет доступа из внешнего кода. Name доступно только внутри класса Animal и Dog
            d1.SayName();                   // Output: Bobik. public SayName() предоставляет доступ к protected Name

            Dog3 d3 = new Dog3();           // Output:  Animal created  -   Конструктор базового класса вызывается первым
                                            //          Dog Created     -   После него вызывается конструктор производного класса
                                            //          Dog deleted     -   При уничтожении объекта вызвается деструктор производного класса
                                            //          Animal deleted  -   А затем деструктор базового класса
            Console.WriteLine();

            Shape0 sh0 = new Shape0();      // экземпляр базового класса Shape0
            sh0.Draw();                     // Output: Base Draw
            Shape0 c0 = new Circle0();      // 
            //Circle0 c0 = new Circle0();   // Мы пишем Shape0 просто чтобы понимать, что объекты относятся к одному базовому классу
                                            // a child class is an instance of a parent class
            c0.Draw();                      // Output: Circle Draw. Благодаря полиморфизму мы можем вызывать один и тот же метод, но для объектов разных классов данный метод будет выполняться по разному
            (c0 as Circle0).RubTheCircle(); // Приведение типа Shape0 к Circle0. Как при int, float и т.д. Так как мы объявили c0 объявили Shape0, а не Circle0.
            Shape0 r0 = new Rectangle0();
            r0.Draw();                      // Output: Rectangle Draw. К примеру в игре можно прописать метод Attack который для разных персонажей (классов) будет выполняться по своему
            Shape0 n0 = new NewShape0();
            n0.Draw();                      // Output: Base Draw
            Shape0 s0 = new SomeShape0();
            s0.Draw();                      // Output: Base Draw

            Console.WriteLine("\nList of Shapes\n");

            List<Shape0> shapesList = new List<Shape0>();   // коллекция суперкласса может хранить экземпляры суперкласса и подклассов 

            shapesList.Add(new Shape0());
            shapesList.Add(new Circle0());
            shapesList.Add(new Rectangle0());

            foreach (Shape0 shape in shapesList)
            {
                shape.Draw();               // экземпляры наследуемых классов выполняют собственные методы Draw() так как они переписывают метод Draw() базового класса
            }

            Console.WriteLine();

            //Shape1 sh1 = new Shape1();    // Невозможно создать экземпляры абстрактного класса. Потому что он не умеет ничего делать
            Shape1 c1 = new Circle1();
            c1.Draw();                      // Output: Circle Draw
            Shape1 r1 = new Rectangle1();
            r1.Draw();                      // Output: Rectangle Draw

            Console.WriteLine();

            //IShape2 sh2 =new IShape();    // Невозможно создать экземпляр интерфейса. Интерфейс просто описывает, что должен делать класс реализующий данный интерфейс
            IShape2 c2 = new Circle2();
            c2.Draw();                      // Output: Circle Draw

            //IShape2 r2 = new Rectangle2();//записать не получится так как в IShape2 не определен метод Print
            Rectangle2 r2 = new Rectangle2();
            r2.Draw();                      // Output: Rectangle Draw
            r2.Print();                     // Output: Print Rectangle

            Car car0 = new Car();
            car0.Model = "Audi A4";
            car0.Year = 2016;
            Car.Motor m1 = new Car.Motor();
            m1.MotorName = "V8";
            Console.WriteLine("Car: " + car0.Model + ". Engine: " + m1.MotorName);  // Output: Car: Audi A4. Engine: V8

            Console.WriteLine();
            Dog1 dog1 = new Dog1("Bobik");
            dog1.Age = 8;
            Dog1 dog2 = dog1;
            Dog1 dog3 = (Dog1)dog1.Clone();
            dog2.Age = 16;
            Console.WriteLine("dog1.Age: " + dog1.Age);   // Output: 16    потому что экземпляры класса это объекты ссылочного типа, и при копировании копируется не объект, 
            Console.WriteLine("dog2.Age: " + dog2.Age);   // Output: 16    а ссылка в стеке (адрес объекта) на местоположение объекта в куче. Мы сейчас выводим одно и то же свойство Age
            Console.WriteLine("dog3.Age: " + dog3.Age);   // Output: 8  потому что мы сделали копию объекта

        }
        #endregion


        #region                                     Structures      Структуры
        //____________________________________________________________________________________________________________________________
        // struct - тип значений который используется для объединения (инкапсуляции) небольших групп связанных переменных
        // Структуры похожи на классы, но более ограничены. Структуры не поддерживают наследование и не могут содержать виртуальных методов
        // стандартные типы int, double, bool, char и т.д. являются структурами
        struct Book
        {
            public string title;
            public double price;
            public string author;
        }
        struct Point
        {
            public int x;
            public int y;
            public int X()              // структуры могут содержать методы, свойства, индексаторы и т.д. 
            {
                return x;
            }
            public Point(int x, int y)  // cтруктуры могут содержать конструкторы только для приема параметров
            {
                this.x = x;
                this.y = y;
            }
        }
        static void Structures()
        {
            Console.WriteLine("\n\n    Структуры\n");
            Book bk;                                // структура может быть создана без ключевого слова new
            bk.title = "Harry Potter";
            bk.author = "J.K.Rowling";
            bk.price = 9.99;

            Point pt = new Point(10, 15);           // в случае наличия конструктора, необходимо ключевое слово new (подобно созданию экземпляра класса) и указание значений параметров
            Console.WriteLine(pt.X());              // Output: 10 
            Console.WriteLine(pt.x + " " + pt.y);   // Output: 10 15

        }
        #endregion


        #region                                 Enumerations    Перечисления
        //____________________________________________________________________________________________________________________________
        // ключевое слово enum
        // перечисление - тип состояний из набора именованных констант, называемого списком перечисления
        // обычно перечисления используются для фиксированных наборов (названий месяцев, дней недели, карт в колоде и т.д.)
        enum Days1 { Mon, Tue, Wed, Thu, Fri, Sat, Sun };   // перечисление начинается с 0, затем Tue=1, Wed=2 ... Sun=6
        enum Days2 { Mon, Tue, Wed = 4, Thu, Fri, Sat, Sun }; // здесь Mon=0, Tue=1, Wed=4, Thu=5 ... Sun=8
        enum TrafficLights { Green, Red, Yellow };
        static void Enumerations()
        {
            Console.WriteLine("\n\n    Перечисления\n");
            int numx = (int)Days1.Tue;
            Console.WriteLine(numx);                    // Output: 1

            //enum TrafficLights { Green, Red, Yellow };
            TrafficLights xLight = TrafficLights.Red;   // присвоение переменной имени Элемента
            int yLight = (int)TrafficLights.Red;        // присвоение переменной значения (номера) Элемента 
            Console.WriteLine(xLight);                  // Output: Red
            Console.WriteLine(yLight);                  // Output: 1
        }
        #endregion


        #region                                     InputOutput     Работа с классом File
        //____________________________________________________________________________________________________________________________
        // Пространство имен System.IO имеет различные классы, которые используются для выполнения операций с файлами. К примеру класс File
        static void InputOutput()
        {
            Console.WriteLine("\n\nРабота с классом File\n");

            try                                             // обработал исключение на случай, если файлы не будут найдены
            {
                File.Delete("text1.txt");                   // удаляет файл, если он существует
                File.Delete("text2.txt");
                File.Delete("text3.txt");

                string str = "Some text";
                File.WriteAllText("text.txt", str);         // создает файл и записывает в него содержимое строки (string)
                string txt = File.ReadAllText("text.txt");  // считывает содержимое файла
                Console.WriteLine(txt);                     // Output: Some text
                File.AppendAllText("text.txt", txt);        // добавляет строку в конец файла
                txt = File.ReadAllText("text.txt");
                Console.WriteLine(txt);                     // Output: Some textSome text
                File.Create("text2.txt");                   // создает файл
                Console.WriteLine(File.Exists("text2.txt"));// Output: True. Проверяет наличие файла 
                File.Copy("text.txt", @"C:\Users\EGOR\source\repos\AllExamples\AllExamples\bin\Debug\NewFolder\text3.txt");         // копирует файл
                Console.WriteLine(File.Exists(@"C:\Users\EGOR\source\repos\AllExamples\AllExamples\bin\Debug\NewFolder\text3.txt"));// Output: True
                File.Move(@"C:\Users\EGOR\source\repos\AllExamples\AllExamples\bin\Debug\NewFolder\text3.txt", "text3.txt");        // перемещает файл
                Console.WriteLine(File.Exists(@"C:\Users\EGOR\source\repos\AllExamples\AllExamples\bin\Debug\NewFolder\text3.txt"));// Output: False
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
            finally
            {
                Console.WriteLine();
            }
            // write to a text file
            StreamWriter output = null;         // удобный класс для работы с файлами
            try
            {
                // create stream writer object
                output = File.CreateText("OneStepCloser.txt");

                // write a few lines
                output.WriteLine("Everything you say to me");
                output.WriteLine("Takes me one step closer to the edge");
                output.WriteLine("And I'm about to break");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // always close output file
                if (output != null)
                {
                    output.Close();
                }
            }

            // read from the text file
            StreamReader input = null;         // удобный класс для работы с файлами
            try
            {
                // create stream reader object
                input = File.OpenText("OneStepCloser.txt");

                // read and echo lines until end of file
                string line = input.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = input.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // always close input file
                if (input != null)
                {
                    input.Close();
                }
            }

            Console.WriteLine();

        }
        #endregion


        #region                                     Exeptions       Обработка исключений
        //____________________________________________________________________________________________________________________________
        // Исключение - это проблема, которая возникает во время выполнения программы. Исключения вызывают ненормальное завершение программы.
        // Хорошо написанная программа должна обрабатывать все возможные исключения.
        // Для обработки исключений используются блоки try, catch, finally
        // 
        static void Exeptions()
        {
            Console.WriteLine("\n\n    Обработка исключений\n");
            int x_ex = 8;
            int y_ex = 0;
            int result_ex = 0;

            try                         // в блоке try размещается код, который может сгенерировать исключение
            {
                result_ex = x_ex / y_ex;
            }
            catch (Exception e)         // если возникает исключение, то без остановки программы начинает выполняться блок catch
                                        // Базовым для всех типов исключений является тип Exception. // создаем объект е типа Exeption, который будет хранит информацию об исключении
                                        // тип Exception определяет  Свойства , с помощью которых можно получить информацию об исключении
            {
                Console.WriteLine(e.InnerException);// InnerException: хранит информацию об исключении, которое послужило причиной текущего исключения
                                                    // Output: (ничего нет)
                Console.WriteLine(e.Message);       // Message: хранит сообщение об исключении, текст ошибки
                                                    // Output: Попытка деления на нуль.
                Console.WriteLine(e.Source);        // Source: хранит имя объекта или сборки, которое вызвало исключение
                                                    // Output: AllExamples
                Console.WriteLine(e.StackTrace);    // StackTrace: возвращает строковое представление стека вызывов, которые привели к возникновению исключения
                                                    // Output: AllExamples.Program.Exeptions() в C:\Users\EGOR\source\repos\AllExamples\AllExamples\Program.cs:строка 1154
                Console.WriteLine(e.TargetSite);    // TargetSite: возвращает метод, в котором было вызвано исключение
                                                    // Output: Void Exeptions()
            }
            finally                     // опциональный блок finally может отсутствовать. Выполняется независимо от того, было ли вызвано исключение или нет
            {
                Console.WriteLine(result_ex);       //Output: 0 - потому что блок try не был выполнен до конца
            }

            // Так как тип Exception является базовым типом для всех исключений, то выражение catch (Exception e) будет обрабатывать все исключения, которые могут возникнуть.
            // Также есть более специализированные типы исключений, которые предназначены для обработки определенных видов исключений (вот некоторые из них)
            //              // DivideByZeroException: представляет исключение, которое генерируется при делении на ноль
            //              // ArgumentOutOfRangeException: генерируется, если значение аргумента находится вне диапазона допустимых значений
            //              // ArgumentException: генерируется, если в метод для параметра передается некорректное значение
            //              // IndexOutOfRangeException: генерируется, если индекс элемента массива или коллекции находится вне диапазона допустимых значений
            //              // InvalidCastException: генерируется при попытке произвести недопустимые преобразования типов
            //              // NullReferenceException: генерируется при попытке обращения к объекту, который равен null(то есть попытка использовать ссылку, которая не указывает ни на один из объектов)
            //              // ArrayTypeMismatchException Тип сохраняемого значения несовместим с типом массива
            //              // OutOfMemoryException Недостаточно свободной памяти для дальнейшего выполнения программы. Это исключение может быть, например, сгенерировано, если для создания объекта с помощью оператора new не хватает памяти
            //              // OverflowException Произошло арифметическое переполнение. Например 33000 для short
            //              // InvalidOperationException
            //              // FormatException
            //              // FileNotFoundException

            try
            {
                result_ex = x_ex / y_ex;
            }
            catch (DivideByZeroException e)         // Специализированные типы исключений имеют те же самые Свойства как и тип Exception
            {
                Console.WriteLine("Error. Dividion by zero");
                Console.WriteLine(e.InnerException);// InnerException: хранит информацию об исключении, которое послужило причиной текущего исключения
                                                    // Output: (ничего нет)
                Console.WriteLine(e.Message);       // Message: хранит сообщение об исключении, текст ошибки
                                                    // Output: Попытка деления на нуль.
                Console.WriteLine(e.Source);        // Source: хранит имя объекта или сборки, которое вызвало исключение
                                                    // Output: AllExamples
                Console.WriteLine(e.StackTrace);    // StackTrace: возвращает строковое представление стека вызывов, которые привели к возникновению исключения
                                                    // Output: AllExamples.Program.Exeptions() в C:\Users\EGOR\source\repos\AllExamples\AllExamples\Program.cs:строка 1154
                Console.WriteLine(e.TargetSite);    // TargetSite: возвращает метод, в котором было вызвано исключение
                                                    // Output: Void Exeptions()
            }
            catch (Exception e)                     // можно использовать множество блоков catch, каждый из которых будет обрабатывать свою ошибку
            {
                Console.WriteLine("Other Error");
            }

        }
        #endregion


        #region                                     Generics        Обобщения
        //____________________________________________________________________________________________________________________________
        // Обобщения позволяют повторно использовать код между различными типами данных
        //
        static void Swap0(ref int a, ref int b) // данный метод работает только с целочисленными параметрами
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Swap1<T>(ref T a, ref T b)  // обобщенный метод. Т является именем обобщенного типа (можно использовать любое имя, Т общепринятое)
        {                                       // <T> - используется для определения обобщенного типа
            T temp = a;
            a = b;
            b = temp;
        }
        
        // Обобщенные типы (данных) также могут использоваться с классами
        // Обычно обобщенные классы используются с коллекциями элементов, где операции добавления и удаления элементов из коллекции выполняются одинаковым образом не зависимо от типа данных
        // Один тип коллекций называется стеком (стопка)
        // Стек работает по принципу: последний зашел, первый вышел
        class Account<T>                        // 
        {
            public T Id { get; set; }           // Id пользователя
            public int Balance { get; set; }    // сумма на счете
        }
        // Обобщения могут использовать несколько универсальных параметров одновременно, которые могут представлять различные типы
        class Transaction<U, V>
        {
            public U From { get; set; }
            public U To { get; set; }
            public V Code { get; set; }
            public int Sum { get; set; }

        }
        static void Generics()
        {
            Console.WriteLine("\n\n    Обобщения\n");
            int a = 4;
            int b = 8;
            Console.WriteLine(a + " " + b);     // Output: 4 8
            Swap0(ref a, ref b);
            Console.WriteLine(a + " " + b);     // Output: 8 4
            Swap1<int>(ref a, ref b);           // при вызове обобщенного метода необходимо в скобках <> указать с каким типом данных он будет работать
            Console.WriteLine(a + " " + b);     // Output: 4 8
            string x = "Hello";
            string y = "World";
            Console.WriteLine(x + " " + y);     // Output: Hello World
            Swap1<string>(ref x, ref y);
            Console.WriteLine(x + " " + y);     // Output: World Hello
            Swap1(ref a, ref b);                // если не указать обобщенный тип данных, компилятор определит тип автоматически по аргументам переданным в метод
            Console.WriteLine(a + " " + b);     // Output: 8 4
            Swap1(ref x, ref y);
            Console.WriteLine(x + " " + y);     // Output: Hello World

            Account<int> account1 = new Account<int>();             // при определении обобщенного класса в скобках <> необходимо указать тип данных, который будет использоваться вместо Т
            account1.Id = 501;
            Account<string> account2 = new Account<string>();       // у объекта account1 свойство Id будет иметь тип int, а у объекта account2 - тип string.
            account2.Id = "David";
            Account<string> account3 = new Account<string>{ Id = "Max", Balance = 5000 }; // оказывается при объявлении объекта класса, можно задать свойства таким образом

            Console.WriteLine(account1.Id);                         // Output: 501
            Console.WriteLine(account2.Id);                         // Output: David
            Console.WriteLine(account3.Id + " " + account3.Balance);// Output: Max 5000

            Transaction<string, int> tr0 = new Transaction<string, int>();
            tr0.From = account2.Id;
            tr0.To = account3.Id;
            tr0.Code = 4689;
            tr0.Sum = 500;
            Console.WriteLine("From " + tr0.From + " to " + tr0.To + ". Code: " + tr0.Code + ". Sum " + tr0.Sum);
            // то же самое но в другой записи. Так можно делать с любыми классами. Можно задать все параметры сразу 
            Transaction<string, int> tr1 = new Transaction<string, int>
            {
                From = account2.Id,
                To = account3.Id,
                Code = 4689,
                Sum = 500
            };
            Console.WriteLine("From " + tr1.From + " to " + tr1.To + ". Code: " + tr1.Code + ". Sum " + tr1.Sum);
        }
        #endregion


        #region                                     Collections     Коллекции
        //____________________________________________________________________________________________________________________________
        // Коллекция предназначена для группировки связанных объектов. В отличие от массива, который также может группировать объекты, коллекция является динамической. 
        // Она может расширяться и уменьшаться, вмещая в себя любое колличество объектов. Классы коллекций имеют множество встроенных методов для обработки коллекций.
        // Коллекция организует связанные данные таким образом, чтобы с ними было удобно работать.
        // Пространство имен System.Collections.Generic включает следующие обобщенные коллекции:    
        //      List<T>
        //      Dictionary<TKey, TValue>
        //      SortedList<TKey, TValue>
        //      Stack<T>
        //      Queue<T>
        //      Hashset<T>
        // Пространство имен System.Collections включает следующие необобщенные коллекции , которые хранят элементы типа Object:
        //      ArrayList
        //      SortedList
        //      Stack
        //      Queue
        //      Hashtable
        //      BitArray

        
        static void Collections()
        {
            Console.WriteLine("\n\n    Коллекции\n");
            # region List
            List<string> dinosaurs = new List<string>();            // работает как стопка, то есть если удалить 2й элемент, то 3й элемент становится 2м

            Console.WriteLine("Capacity: {0}", dinosaurs.Capacity);

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);
            Console.WriteLine("Count: {0}", dinosaurs.Count);

            Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
                dinosaurs.Contains("Deinonychus"));

            Console.WriteLine("\nInsert(2, \"Compsognathus\")");
            dinosaurs.Insert(2, "Compsognathus");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            // Shows accessing the list using the Item property.
            Console.WriteLine("\ndinosaurs[3]: {0} \n", dinosaurs[3]);

            Console.WriteLine("index of \"Deinonychus\": " + dinosaurs.IndexOf("Deinonychus"));

            Console.WriteLine("\nRemove(\"Mamenchisaurus\")");
            dinosaurs.Remove("Mamenchisaurus");
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }
            Console.WriteLine();

            Dictionary<string, int> converter = new Dictionary<string, int>();  // Данные хранятся в парах ключ-значение. Ключ должен быть уникален
            converter.Add("zero", 0);
            converter.Add("one", 1);
            converter.Add("two", 2);
            void ConvertWordToDigit(string word)
            {
                word = word.ToLower();
                if (converter.ContainsKey(word))
                {
                    Console.WriteLine("Key: " + word);
                    Console.WriteLine("Value: " + converter[word]);
                }
                else
                {
                    Console.WriteLine("Value is not found"); ;
                }
            }
            ConvertWordToDigit("two");      // Output 2
            converter.Remove("one");
            ConvertWordToDigit("two");      // Output 2
            #endregion
        }
        #endregion


        #region Delegates and Events


        public delegate double MathDelegate(double value1, double value2);


        public static double Add(double value1, double value2)
        {
            return value1 + value2;
        }
        public static double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }
        static void DelegatesAndEvents()
        {
            MathDelegate mathDelegate0 = new MathDelegate(Add); // создаем экземпляр делегата, указывающего на другой метод
            MathDelegate mathDelegate = Add;                    // можно так писать
            var result = mathDelegate(5, 2);
            Console.WriteLine(result);  // вывод: 7

            mathDelegate = Subtract;
            result = mathDelegate(5, 2);
            Console.WriteLine(result);  // вывод: 3
        }

        #endregion


        #region         Timer

        private static Timer aTimer;
        private static void SetTimer()
        {
            
            aTimer = new Timer(2000);       // Create a timer with a two second interval.                      
            aTimer.Elapsed += OnTimedEvent; // Hook up the Elapsed event for the timer. 
            aTimer.AutoReset = true;        // Have the timer fire repeated events (true is the default)
            aTimer.Enabled = true;          // Start the timer

            //aTimer.Interval = 3000;       // можно так задавать или менять интервал таймера
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        static void MyTimer()
        {
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();                  // Прекращает вызывать событие Elapsed, задавая для свойства Enabled значение false.
            aTimer.Dispose();               // Освобождает все ресурсы, используемые текущим объектом Timer

            Console.WriteLine("Terminating the application...");
        }

        #endregion

        static void Main(string[] args)
        {
            Introduction();         // Ввод и вывод текста
            Mathematics();          // Арифметические операторы
            Conditions();           // Условные операторы и циклы
            Arrays();               // Задание массивов
            Methods();              // Методы
            Classes();              // Классы
            Inheritance();          // Наследование и полиморфизм 
            Structures();           // Структуры 
            Enumerations();         // Перечисления
            InputOutput();          // Работа с классом File
            Exeptions();            // Обработка исключений
            Generics();             // Обобщения
            Collections();          // Коллекции
            MyTimer();              // Класс Timer
            DelegatesAndEvents();   // Делегаты и события

            Console.WriteLine("\nThe end of the AllExamples file\nPress any key to exit");
            Console.ReadKey();              // это чтобы программа не закрывалась сразу после выполнения. Сonsole - статический класс. ReadKey() - статический метод класса Console
        }

    }
}