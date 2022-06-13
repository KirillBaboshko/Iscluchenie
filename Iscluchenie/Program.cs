using System;
using static System.Console;
namespace SimpleProject
{
    public class MyException : ApplicationException
    {
        public DateTime TimeException { get; private set; }
        public MyException() : base("Мое исключение")
        {
            TimeException = DateTime.Now;
        }
    }
    class Money
    {
        
        private int rub;
        private int kop;
        private Money Perevod(Money M)
        {
            while(M.kop<0 && M.rub!=0)
            {
                M.rub -= 1;
                M.kop = M.kop + 100;
            }
            while (M.rub < 0 && M.kop != 0)
            {
                M.kop -= 100;
                M.rub = M.rub + 1;
            }
            int buff = M.kop / 100;
            M.kop = M.kop % 100;
            M.rub += buff;
            if(M.rub<0 || M.kop<0 )
            {
                throw new Exception("Банкрот");
            }
            return M;
        }
        public void  Print()
        {
            WriteLine($"Рублей: {rub} Копеек: {kop}");
        }

        public Money(int r, int k)
        {
            rub = r;
            kop = k;
            Perevod(this);
        }
        public static Money Plus(Money m1, Money m2)
        {
            Money m = new Money(m1.rub + m2.rub, m1.kop + m2.kop);
            return m;
        }
        public static Money Minus(Money m1, Money m2)
        {
            Money m = new Money(m1.rub - m2.rub, m1.kop - m2.kop);
            return m;
        }
        public static Money Div(Money m1, int value)
        {
            Money m = new Money(m1.rub / value, m1.kop / value);
            return m;
        }
        public static Money Mult(Money m1, int value)
        {
            Money m = new Money(m1.rub * value, m1.kop * value);
            return m;
        }
        public static Money PlusPlus(Money m1)
        {
            Money m = new Money(m1.rub, m1.kop + 1);
            return m;
        }
        public static Money MinusMinus(Money m1)
        {
            Money m = new Money(m1.rub, m1.kop - 1);
            return m;
        }
        public static bool bolshe(Money m1, Money m2)
        {
            if (m1.rub > m2.rub)
            {
                return true;
            }
            else
            {
                if (m1.rub == m2.rub)
                {
                    if (m1.kop > m2.kop)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool menshe(Money m1, Money m2)
        {
            if (m1.rub < m2.rub)
            {
                return true;
            }
            else
            {
                if (m1.rub == m2.rub)
                {
                    if (m1.kop < m2.kop)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool ravno(Money m1, Money m2)
        {
            if (m1.rub == m2.rub && m1.kop == m2.kop)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Money operator +(Money m1, Money m2)
        {
            return Plus(m1, m2);
        }
        public static Money operator -(Money m1, Money m2)
        {
            return Minus(m1, m2);
        }
        public static Money operator *(Money m1, int value)
        {
            return Mult(m1, value);
        }
        public static Money operator /(Money m1, int value)
        {
            return Div(m1, value);
        }
        public static Money operator ++(Money m1)
        {
            return PlusPlus(m1);
        }
        public static Money operator --(Money m1)
        {
            return MinusMinus(m1);
        }
        public static bool operator ==(Money m1, Money m2)
        {
            return ravno(m1, m2);
        }
        public static bool operator !=(Money m1, Money m2)
        {
            return !ravno(m1, m2);
        }
        public static bool operator <(Money m1, Money m2)
        {
            return menshe(m1, m2);
        }
        public static bool operator >(Money m1, Money m2)
        {
            return bolshe(m1, m2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Money f1;
                Money f2;
                WriteLine($"Введите рубли");
                int n = Convert.ToInt32(ReadLine());
                WriteLine($"Введите копейки");
                int t = Convert.ToInt32(ReadLine());
                f1 = new Money(n, t);
                f2 = new Money(100, 82);
                Money f3 = f1 + f2;
                WriteLine($"Сложение:");
                f3.Print();
                WriteLine($"Вычитание:");
                f3 = f1 - f2;
                f3.Print();
                WriteLine($"Умножение:");
                f3 = f1 * 2;
                f3.Print();
                WriteLine($"Деление:");
                f3 = f1 / 2;
                f3.Print();

                if (f1 == f2)
                {
                    WriteLine($"Равны");
                }
                if (f1 > f2)
                {
                    WriteLine($"Больше \n");
                }
                if (f1 < f2)
                {
                    WriteLine($"Меньше ");
                }
                WriteLine($"++:");
                f1 = ++f1;
                f1.Print();

                WriteLine($"--:");
                f1 = --f1;
                f1.Print();
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }

            //           do
            //           {
            //               try
            //               {
            //                   Write($"\nВведите число: ");
            //                   //чтение ввода пользователя
            //                   string str = ReadLine();
            //                   //условие выхода из цикла
            //                   if (string.IsNullOrEmpty(str))
            //                   {
            //                       return;
            //                   }
            //                   //преобразование строки в число
            //                   int number = Convert.ToInt32(str);
            //                   //проверка, что полученное число 
            //                   //принадлежит области определения
            //                   //функции ln()
            //                   if (number <= 0)
            //                   {
            //                   throw new
            //ArgumentOutOfRangeException
            //("число <= 0");
            //                   }
            //                   double log = Math.Log(number);
            //                   WriteLine($"ln({ number}) = { log}\n100 / ln({ number}) ={ 100 / (int)log}");
            //               }
            //               catch (FormatException fe)
            //               {
            //                   //происходит, если введенное 
            //                   //пользователем значение 
            //                   //невозможно преобразовать в целое число
            //                   WriteLine(fe.Message);
            //               }
            //               catch (DivideByZeroException de)
            //               {
            //                   //происходит, если Log(n) = 0 (т.е. n = 1)
            //                   WriteLine(de.Message);
            //               }
            //               catch (Exception e)
            //               {
            //                   //прехват всех остальных исключений
            //                   WriteLine($"Exception: { e.Message }");
            //               }
            //           } while (true);

            //           WriteLine("Введите два числа");
            //           int number1, number2, result = 0;
            //           try
            //           {
            //               number1 = int.Parse(ReadLine());
            //               number2 = int.Parse(ReadLine());
            //               result = number1 / number2;
            //           if (result % 2 != 0)
            //               {
            //                   throw new MyException();
            //               }
            //               WriteLine($"Результат деления чисел:{ result }");
            //           }
            //           catch (MyException my)
            //           {
            //               WriteLine(my.Message);
            //               WriteLine(my.TimeException);
            //           }
        }
    }
}