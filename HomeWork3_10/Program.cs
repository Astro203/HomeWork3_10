using System;

namespace HomeWork3_10
{
    class Program
    {
        static void Main(string[] args)
        {

            //Задание 1. Создание игры на 2 игрока

            Console.ForegroundColor = ConsoleColor.Green; //Цвет текста выводимый далее в консоль зеленый
            Console.WriteLine("Правила игры:");
            Console.WriteLine("Загадывается число от 12 до 120, причем случайным образом. Назовем его gameNumber.");
            Console.WriteLine("Игроки по очереди выбирают число от одного до четырех. Пусть это число обозначается как userTry.");
            Console.WriteLine("userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
            Console.WriteLine("Если после хода игрока gameNumber равняется нулю, то походивший игрок объявляется победителем.");
            Console.WriteLine("Число четыре вводить нельзя, если userTry больше чем gameNumber");
            Console.ResetColor(); //Сброс цвета на стандартный
            Console.WriteLine();

            Random rand = new Random(); //добавление генератора случайных чисел

            Console.Write("1-й игрок представьтесь: "); string gamer1 = Console.ReadLine(); //ввод своего имени первым игроком
            Console.Write("2-й игрок представьтесь: "); string gamer2 = Console.ReadLine(); //ввод своего имени вторым игроком
            Console.WriteLine(); //переход на строку ниже

            int userTry;
            int gameNumber;
            string revansh = "да"; //переменная для возможного реванша
            string winner = ""; //переменная для имени победителя
            while (revansh == "да") //проверка согласия на реванш
            {
                gameNumber = rand.Next(12, 121); //случайное число от 12 до 120
                for (; ; ) //запуск бесконечного цикла
                {
                    userTry = 0; //перед вводом числа выполнить условие для цикла ниже
                    while (userTry < 1 || userTry > 4) //пока введенное число меньше 1 или болше 4, повторять ввод числа
                    {
                        Console.Write($"{gamer1}, введите число от 1 до 4: "); userTry = int.Parse(Console.ReadLine()); //ввод любого целого числа первым игроком 
                    }
                    while (userTry > gameNumber && userTry == 4) //пока введенное число больше оставшегося gameNumber и равно четырем, повторять ввод числа
                    {
                        Console.Write($"{gamer1}, введите число от 1 до 3: "); userTry = int.Parse(Console.ReadLine()); //ввод целого числа от 1 до 3 первым игроком 
                    }
                    if (userTry <= gameNumber) //если введенное число меньше или равно оставшегося gameNumber, то выполнить...
                    {
                        gameNumber -= userTry; //вычитание userTry из gameNumber
                        Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося числа
                        if (gameNumber == 0) //если разность равна нулю, то...
                        {
                            Console.WriteLine($"Поздравляем {gamer1} с победой!!!"); //поздравление первого игрока
                            winner = gamer1; //переменная для вывода имени победителя
                            break; //выход из цикла for
                        }
                    }
                    userTry = 0;  //перед вводом числа выполнить условие для цикла ниже
                    while (userTry < 1 || userTry > 4) //пока введенное число меньше 1 или больше 4, повторять ввод числа
                    {
                        Console.Write($"{gamer2}, введите число от 1 до 4: "); userTry = int.Parse(Console.ReadLine()); //ввод любого целого числа вторым игроком 
                    }
                    while (userTry > gameNumber && userTry == 4) //пока введенное число больше оставшегося gameNumber и равно четырем, повторять ввод числа
                    {
                        Console.Write($"{gamer2}, введите число от 1 до 3: "); userTry = int.Parse(Console.ReadLine()); //ввод целого числа от 1 до 3 вторым игроком 
                    }
                    if (userTry <= gameNumber) //если введенное число меньше или равно оставшегося gameNumber, то выполнить...
                    {
                        gameNumber -= userTry; //вычитание userTry из gameNumber
                        Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося числа
                        if (gameNumber == 0) //если разность равна нулю, то...
                        {
                            Console.WriteLine($"Поздравляем {gamer2} с победой!!!"); //поздравление второго игрока
                            winner = gamer2; //переменная для вывода имени победителя
                            break; //выход из цикла for
                        }
                    }
                }
                //предложение победителю о реванше, если 'да' то продолжить цикл while(revansh), если 'нет' - закончить игру
                Console.Write($"{winner}, Вы согласны на реванш? введите 'да' или 'нет': "); revansh = Console.ReadLine();
            }
            Console.Write("Игра закончена");
        }
    }
}
