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

int GetDigit(int number, int degree)
{
    return number % (int)Math.Pow(10, degree) / (int)Math.Pow(10, degree - 1);
}

int GetDegree(int number)
{
    int degree = 1;
    while (number / 10 > 0)
    {
        number /= 10;
        degree++;
    }
    return degree;
}

int Swap(int number, int digit1, int digit2, int degree)
{
    int pow = (int)Math.Pow(10, degree);
    return number - digit1 * pow - digit2 * (pow / 10) + digit2 * pow + digit1 * (pow / 10);
}

System.Console.Write("Введите целое натуральное число: ");
int num = int.Parse(Console.ReadLine());
int degree = GetDegree(num);
bool flag = true;

while (flag)
{
    flag = false;
    for (int i = 1; i < degree; i++)
    {
        if (GetDigit(num, i) % 2 != 0 && GetDigit(num, i + 1) % 2 == 0)
        {
            num = Swap(num, GetDigit(num, i + 1), GetDigit(num, i), i);
            flag = true;
        }
    }
}

System.Console.WriteLine(num);
