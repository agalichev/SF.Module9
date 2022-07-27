//  Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек.
//  Сортировка должна происходить при помощи события.
//  Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).

//  Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.

#region Up-level
List<string> peoples = new List<string> {"Смирнов", "Уткин", "Жуков", "Маслов", "Носов"};
bool isSorted;

NumberReader numberReader = new NumberReader();
numberReader.NumberReaderEvent += SortPeopleList;

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Вот список участников розыгрыша:\n");
    Console.ResetColor();

    ShowPeopleList(peoples);
    try
    {
        numberReader.Read(peoples);
    }
    catch (NumberEnteredException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Недопустимый формат значения");
    }
    catch (Exception ex) when (ex.Message == "Завершение работы приложения")
    {
        Console.WriteLine(ex.Message);
        break;
    }
    finally
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }
}
while (true);

static void SortPeopleList(int number, List<string> peoples)
{
    switch (number)
    {
        case 1:
            peoples.Sort();
            Console.WriteLine("Была выполнена операция 1 - Сортировка А-Я");
            break;
        case 2:
            peoples.Sort();
            peoples.Reverse();
            Console.WriteLine("Была выполнена операция 2 - Сортировка Я-А");
            break;
        case 3:
            throw new Exception("Завершение работы приложения");
            break;
    }
}

static void ShowPeopleList(List<string> peoples)
{
    foreach(var people in peoples)
        Console.WriteLine(people);
}
#endregion
/// <summary>
/// Можно создать событие с ссылкой на шаблонный делегат Action
/// </summary>
class NumberReader
{
    public delegate void NumberReaderDelegate(int number, List<string> peoples);
    public event NumberReaderDelegate NumberReaderEvent;

    public void Read(List<string> peoples)
    {
        Console.WriteLine();
        Console.WriteLine("Доступные операции:\n 1 - Сортровка А-Я\n 2 - Сортировка Я-А\n 3 - Завершить работу приложения\n");
        Console.Write("Необходимо выбрать операцию: ");

        int number = Convert.ToInt32(Console.ReadLine());

        if (number != 1 && number != 2 && number != 3) throw new NumberEnteredException("Введено некорректное число");

        NumberEntered(number, peoples);
    }

    protected virtual void NumberEntered(int number, List<string> peoples)
    {
        NumberReaderEvent?.Invoke(number, peoples);
    }
}

class NumberEnteredException : FormatException
{
    public NumberEnteredException(string message) : base(message) { }
}