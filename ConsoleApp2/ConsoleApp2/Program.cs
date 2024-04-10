using System;

class Money
{
    // Поля
    protected int first;
    protected int second;

    // Конструктор
    public Money(int first, int second)
    {
        this.first = first;
        this.second = second;
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            if (index == 0)
                return first;
            else if (index == 1)
                return second;
            else
            {
                Console.WriteLine("Помилка: неправильний індекс");
                return -1; // Або будь-яке інше значення, що позначає помилку
            }
        }
        set
        {
            if (index == 0)
                first = value;
            else if (index == 1)
                second = value;
            else
                Console.WriteLine("Помилка: неправильний індекс");
        }
    }

    // Перевантаження операцій
    public static Money operator ++(Money money)
    {
        money.first++;
        money.second++;
        return money;
    }

    public static Money operator --(Money money)
    {
        money.first--;
        money.second--;
        return money;
    }

    public static bool operator !(Money money)
    {
        return money.second != 0;
    }

    public static Money operator +(Money money, int scalar)
    {
        money.second += scalar;
        return money;
    }

    // Методи
    public void PrintMoney()
    {
        Console.WriteLine($"Перший: {first}, Другий: {second}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Money
        Money wallet = new Money(100, 5); // Гаманець з 5 купюрами по 100 гривень кожна
        wallet.PrintMoney(); // Виводимо інформацію про гаманець

        // Використання індексатора
        Console.WriteLine(wallet[0]); // Повинно вивести перший елемент (100)
        Console.WriteLine(wallet[1]); // Повинно вивести другий елемент (5)
        Console.WriteLine(wallet[2]); // Повинно вивести помилку

        // Перевантажені операції
        wallet++; // Збільшуємо обидва поля на 1
        wallet.PrintMoney(); // Виводимо оновлену інформацію про гаманець

        wallet--; // Зменшуємо обидва поля на 1
        wallet.PrintMoney(); // Виводимо оновлену інформацію про гаманець

        Console.WriteLine(!wallet); // Повинно вивести True, якщо друге поле не нуль, інакше False

        wallet = wallet + 10; // Додаємо 10 до другого поля
        wallet.PrintMoney(); // Виводимо оновлену інформацію про гаманець
    }
}
