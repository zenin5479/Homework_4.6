using System;
using System.IO;

// Даны три одномерных массива А, В и С разного размера, для каждого из которых сформировать новый массив
// из элементов исходного массива, удовлетворяющих заданному условию
// Выбрать подходящий тип элементов массива
// Для обработки массива (или пары массивов) использовать подпрограмму
// Результатом этой подпрограммы должен быть новый массив, а также количество элементов в нем
// Предусмотреть случай, когда формируемый массив будет пустой
// Для ввода и вывода массивов также использовать подпрограммы
// Составить тесты, позволяющие проверить все возможные случаи
// Для каждого из этих массивов сформировать массив, содержащий номера элементов исходного массива,
// которые не равны максимальному его значению
// Для формирования массива из номеров элементов, неравных максимальному, использовать подпрограмму

namespace Homework_4._6
{
   internal class Program
   {
      static void Main()
      {
         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         string nameOne = "A";
         string nameTwo = "B";
         string nameThree = "C";

         int elementsOne = MethodsForArray.NumberArrayElements(nameOne);
         int elementsTwo = MethodsForArray.NumberArrayElements(nameTwo);
         int elementsThree = MethodsForArray.NumberArrayElements(nameThree);

         string pathOne = Path.GetFullPath("a.txt");
         if (!File.Exists(pathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathTwo = Path.GetFullPath("b.txt");
         if (!File.Exists(pathTwo))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathThree = Path.GetFullPath("c.txt");
         if (!File.Exists(pathThree))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathFour = Path.GetFullPath("finish.txt");
         if (!File.Exists(pathFour))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
            File.Create(pathFour);
         }
         else
         {
            Console.WriteLine("Файл существует. Очищаем");
            // Очищаем содержимое файла
            // Вариант 1
            File.Create(pathFour).Close();
            // Вариант 2
            //File.WriteAllLines(pathFour, new string[0]);
            //File.WriteAllLines(pathFour, Array.Empty<string>());
            // Вариант 3
            //File.WriteAllText(pathFour, string.Empty);
            // Вариант 4
            //File.WriteAllBytes(pathFour, new byte[0]);
            //File.WriteAllBytes(pathFour, Array.Empty<byte>());
            // Вариант 5
            //FileStream fileStream = new FileStream(pathFour, FileMode.Truncate);
            //fileStream.Close();
            // Вариант 6
            //FileStream fileStream = new FileStream(pathFour, FileMode.Open);
            //fileStream.SetLength(0);
            //fileStream.Close();
         }

         double[] sourceOne = MethodsForArray.VvodArray(pathOne, nameOne);
         if (sourceOne.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameOne);
         }
         else
         {
            double[] searchOne = MethodsForArray.InputArray(sourceOne, elementsOne, nameOne);
            double maxOne = MethodsForArray.FindMaxArray(searchOne, nameOne);
            double[] replacingOne = MethodsForArray.ReplacingMax(searchOne, maxOne);
            string[] arrayOne = MethodsForArray.VivodStringArray(replacingOne);
            MethodsForArray.FileAppendString(arrayOne, pathFour);
         }

         double[] sourceTwo = MethodsForArray.VvodArray(pathTwo, nameTwo);
         if (sourceTwo.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameTwo);
         }
         else
         {
            double[] searchTwo = MethodsForArray.InputArray(sourceTwo, elementsTwo, nameTwo);
            double maxTwo = MethodsForArray.FindMaxArray(searchTwo, nameTwo);
            double[] replacingTwo = MethodsForArray.ReplacingMax(searchTwo, maxTwo);
            string[] arrayTwo = MethodsForArray.VivodStringArray(replacingTwo);
            MethodsForArray.FileAppendString(arrayTwo, pathFour);
         }

         double[] sourceThree = MethodsForArray.VvodArray(pathThree, nameThree);
         if (sourceThree.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameThree);
         }
         else
         {
            double[] searchThree = MethodsForArray.InputArray(sourceThree, elementsThree, nameThree);
            double maxThree = MethodsForArray.FindMaxArray(searchThree, nameThree);
            double[] replacingThree = MethodsForArray.ReplacingMax(searchThree, maxThree);
            string[] arrayThree = MethodsForArray.VivodStringArray(replacingThree);
            MethodsForArray.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}