// Программа на вход получает натуральное число. Необходимо его преобразовать таким образом, чтобы все нечетные числа стояли впереди, 
// а все четные позади. При этом внутри четных и нечетных чисел очередность должна сохраняться. Результатом должно быть новое число, 
// а не просто вывод на печать цифр в нужном порядке. Использовать можно только арифметические действия без работы со строкой.
// Пример:
// 12345 -> 13524
// 3658563 -> 3553686
// 48 -> 48
// 5497 -> 5974
// Для решения может понадобится функция возведения в степень и приведение типов. По крайней мере мне они понадобились:)
// Чтобы возвести в степень число используйте функцию Math.Pow(value, degree), где value - число, которое возводят в степень, а degree - собственно степень.
// Эта функция возвращает double. Если нужно привести полученный результат к int, используйте следующую конструкцию: (int)Math.Pow(value, degree)

// P. S. Я не использовал массивы, только цикл и ветвление.

ulong EnterNumber()     // Функция ввода числа с проверкой
{
    ulong number = 0;   // По хорошему тут надо бы присвоить -1, но тогда придется использовать long,
    while(true)         // а это значит, что число будет иметь на 12 разрядов меньше
    {
        System.Console.Write("Введите натуральное целое число (максимум 25 разрядов): ");  // ulong может и 26, но пусть будет один в запасе
        string sNumber = Console.ReadLine()!;
        try
        {
            number = ulong.Parse(sNumber);
            break;
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("Неправильный ввод числа. Повторите ввод.");
        }
    }

    return number;
}

ulong GetDigit(ulong number, int degree)         // Функция получения цифры из числа по его разряду в числе
{
    return number % (ulong)Math.Pow(10, degree) / (ulong)Math.Pow(10, degree - 1);
}

int GetDegree(ulong number)                      // Функция получения разрядности числа
{
    int degree = 1;
    while (number / 10 > 0)
    {
        number /= 10;
        degree++;
    }
    return degree;
}

ulong Swap(ulong number, ulong digit1, ulong digit2, int degree)   // Функция замены двух чисел местами
{
    ulong pow = (ulong)Math.Pow(10, degree);
    return number - digit1 * pow - digit2 * (pow / 10) + digit2 * pow + digit1 * (pow / 10);
}

ulong MoveDigits(ulong number)              // Функция перемещения чисел. Для ускорения работы
{                                           // программы за одну итерацию по циклу нечётные числа 
    int degree = GetDegree(number);         // двигаются влево, четные вправо (два последовательных
    bool flag = true;                       // условия в цикле)

    while (flag)
    {
        flag = false;
        for (int i = 1; i < degree; i++)    // В условиях проверям два рядомстоящих числа, и если что меняем их местами
        {
            if (GetDigit(number, i + 1) % 2 == 0 && GetDigit(number, i) % 2 != 0)
            {
                number = Swap(number, GetDigit(number, i + 1), GetDigit(number, i), i);
                flag = true;
            }
            if (GetDigit(number, degree - i + 1) % 2 == 0 && GetDigit(number, degree - i) % 2 != 0)
            {
                number = Swap(number, GetDigit(number, degree - i + 1), GetDigit(number, degree - i), degree - i);
                flag = true;
            }
        }
    }

    return number;
}

System.Console.WriteLine("Результат работы программы: " + MoveDigits(EnterNumber()));