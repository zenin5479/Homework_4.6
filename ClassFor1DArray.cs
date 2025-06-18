using System;
using System.IO;
using System.Text;

namespace Homework_4._6
{
   internal class ClassFor1DArray
   {
      public static int NumberArrayElements(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива {0}", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static double[] VvodArray(string path, string nameArray)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
            }

            // Определение количества столбцов в строке разделением строки на подстроки по пробелу
            // Символ пробела
            char symbolSpace = ' ';
            // Счетчик символов
            int symbolСount = 0;
            // Количество столбцов в строке
            int сolumn = 0;
            if (stroka != null)
            {
               Console.WriteLine("Исходный строковый массив {0}", nameArray);
               Console.WriteLine(stroka);
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               //Console.WriteLine("Количество столбцов {0}", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               Console.WriteLine("Массив вещественных чисел {0}", nameArray);
               // Одномерный массив вещественных чисел
               arrayDouble = new double[сolumn];
               // Построитель строк
               StringBuilder stringModified = new StringBuilder();
               // Счетчик символов обнуляем
               symbolСount = 0;
               // Количество столбцов в строке обнуляем
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            Console.WriteLine();
         }

         return arrayDouble;
      }

      public static double[] InputArray(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Массив вещественных чисел {0} для проведения поиска", nameArray);
         double[] outputArray = new double[n];


         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static double FindMaxArray(double[] inputArray, string nameArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         // Cчитаем, что максимум - это первый элемент строки
         double max = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            column++;
         }

         Console.WriteLine("Максимум в массиве {0} равен: {1}", nameArray, max);
         //Console.WriteLine("Максимум в массиве {0} равен: {1:f2}", nameArray, max);
         return max;
      }

      public static double[] ReplacingMax(double[] inputArray, double max)
      {
         double[] outputArray = new double[inputArray.Length];
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(max) == 0)
            {
               outputArray[i] = inputArray[i];
            }
            else
            {
               outputArray[i] = i;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(max))
            //{
            //   outputArray[i] = inputArray[i];
            //}
            //else
            //{
            //   outputArray[i] = i;
            //}

            i++;
         }

         return outputArray;
      }

      public static void FileAppendString(string[] stringArray, string filePath)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         File.AppendAllLines(filePath, stringArray);
      }

      public static string[] VivodStringArray(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }
   }
}