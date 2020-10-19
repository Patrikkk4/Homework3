using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40); // задание размера консоли

            // Вывод правил игры
            Console.ForegroundColor = ConsoleColor.DarkBlue; // Задание цвета выводимого текста
            Console.Write($"{ "Правила игры:\n",60}" +
                $"{"Случайным образом генерируется число от 12 до 120\n",77}" +
                 $"{"Каждый игрок по очереди вводит число от 1 до 4\n",76}" +
                $"{"Побеждает игрок первым достигший нуля.\n",69}" +
                $"{"Если последний результат будет отрицательным\n",73}" +
                $"{"то будет сгенерированно случайное число от 10 до 50\n",78}" + 
                $"{"и ход перейдет к следующему игроку\n",68}");

            Console.WriteLine(" "); // Пустая строка для более удобного визуального восприятия

            int maxNumber = 4; // Максимальное вводимое число
            int minNumber = 1; // Минимально вводимое число

            Random RandomNum = new Random(); // генератор случайных чисел
            int gameNumber = RandomNum.Next(12, 121); // генерация случайного числа и запись его в переменную

            int GamerNum; // переменные ввода игроков

            Console.ForegroundColor = ConsoleColor.Gray; // Задание цвета выводимого текста

            Console.Write($"{"Введите имя первого игрока: ",63}"); //
            string Gamer1 = Console.ReadLine();                   // Ввод имени первого игрока

            Console.Write($"{"Введите имя второго игрока: ",63}"); //
            string Gamer2 = Console.ReadLine();                    // Ввод имени второго игрока

            Console.WriteLine($"{ "Заданное число: " + gameNumber,58}" + "\n"); // Вывод случайно заданного числа

            Console.WriteLine(" "); // Пустая строка для более удобного визуального восприятия

            // Метод получения данных и выполнения условий первого игрока
            bool Turn(int TempNum1, string TempGamer)
            {
                if (TempNum1 <= maxNumber && TempNum1 >= minNumber) // Условие соблюдения правил игры
                {
                    gameNumber = gameNumber - TempNum1; // вычисление разницы чисел первого игрока
                }
                else // Условие нарушения правил игры
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n" + $"{"Ошибка, ты играешь не по правилам! ход переходит к следующему игроку", 82}" + "\n");
                    Console.ReadKey();
                }
                if (gameNumber == 0) // Условие победы первого игрока
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Задание цвета выводимого текста

                    Console.WriteLine($"{" Победил " + TempGamer + "! Поздравления!!! Игра будет закрыта. Нажми любую клавишу", 83}");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else if (gameNumber < minNumber) // Условие при отрицательном последнем значении
                {
                    Console.ForegroundColor = ConsoleColor.Gray; // Задание цвета выводимого текста

                    Console.Write($"{"Последний результат не может быть отрицательным! ",73}" + "\n" +
                        $"{"Прибавляем случайное число от 10 до 50, и ход переходит к следующему игроку",88}" + "\n");
                    gameNumber = gameNumber + RandomNum.Next(10, 51); // Генерация нового случайного числа
                    Console.Write("\n" + $"{"новое число: " + gameNumber,56}" + "\n"); // Вывод нового случайного числа
                }
                return true; 
            }
            while (gameNumber > 0) // Цикл игры
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write("Ходит: " + Gamer1 + "\nВведи число от 1 до 4\nТвое число: "); // 
                int.TryParse(Console.ReadLine(), out GamerNum);                              // Ввод числа первого игрока

                Turn(GamerNum, Gamer1); // метод вычисления разницы gameNumber и числа одного из игроков
                Console.WriteLine($"{ "новое число: " + gameNumber,56}" + "\n"); // вывод в консоль разницы случайного числа и числа первого игрока.

                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("Ходит: " + Gamer2 + "\nВведи число от 1 до 4\nТвое число: "); // 
                int.TryParse(Console.ReadLine(), out GamerNum);                              // Ввод числа первого игрока

                Turn(GamerNum, Gamer2);
                Console.WriteLine($"{ "новое число: " + gameNumber,56}" + "\n"); // вывод в консоль разницы случайного числа и числа первого игрока.   
            }
        }
    }
}
