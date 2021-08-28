using System;

namespace HomeWork3_10
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Задание 1. Создание игры на 2 игрока
             * 
             * Правила:
             * Загадывается число от 12 до 120, причем случайным образом. Назовем его gameNumber.
             * Игроки по очереди выбирают число от одного до четырех. Пусть это число обозначается как userTry.
             * userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.
             * Если после хода игрока gameNumber равняется нулю, то походивший игрок объявляется победителем.
             * Число "четыре" вводить нельзя.
             */

            Random rand = new Random(); //добавление генератора случайных чисел

            Console.Write("1-й игрок представьтесь: "); string gamer1 = Console.ReadLine(); //ввод своего имени первым игроком
            Console.Write("2-й игрок представьтесь: "); string gamer2 = Console.ReadLine(); //ввод своего имени вторым игроком

            int userTry, gameNumber;
            string revansh = "да"; //переменная для возможного реванша
            string winner = ""; //переменная для имени победителя
            while (revansh == "да") //проверка согласия на реванш
            {
                gameNumber = rand.Next(12, 121); //случайное число от 12 до 120
                for (; ; ) //запуск бесконечного цикла
                {
                    Console.Write($"{gamer1} введите число: "); userTry = int.Parse(Console.ReadLine()); //ввод любого целого числа первым игроком    
                    if (userTry != 4) //если введенное число не равно четырем, то выполнить...
                    {
                        gameNumber -= userTry; //вычитание userTry из gameNumber
                        Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося числа
                        if (gameNumber == 0) //если разность равна нулю, то...
                        {
                            Console.WriteLine($"Поздравляем {gamer1} с победой!!!"); //поздравить игрока
                            winner = gamer1; //переменная для вывода имени победителя
                            break; //выход из цикла for
                        }
                    }
                    else //если введенное число равно четырем, то переход хода другому игроку
                    {
                        Console.WriteLine("\nЧисло 'четыре' вводить нельзя по правилам игры. Переход хода."); //предупреждение о нарушении правил
                        //далее аналогично предыдущему игроку
                        Console.Write($"{gamer2} введите число: "); userTry = int.Parse(Console.ReadLine());
                        if (userTry != 4)
                        {
                            gameNumber -= userTry;
                            Console.WriteLine($"Оставшееся число: {gameNumber}");
                            if (gameNumber == 0)
                            {
                                Console.WriteLine($"Поздравляем {gamer2} с победой!!!");
                                winner = gamer2;
                                break;
                            }
                        } else Console.WriteLine("\nЧисло 'четыре' вводить нельзя по правилам игры. Переход хода.");
                    }       
                }
                //предложение победителю о реванше, если 'да' то продолжить цикл while, если 'нет' - закончить игру
                Console.Write($"{winner}, Вы согласны на реванш? введите 'да' или 'нет': "); revansh = Console.ReadLine();
            }
        }
    }
}
