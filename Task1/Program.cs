List<Exception> exceptions = new List<Exception>() {new MyException("Пользовательское исключение"),
                                                     new ArgumentException("Недопустимый аргумент"),
                                                     new FormatException("Значение не соответствует формату преобразования"),
                                                     new FileNotFoundException("Такой файл не существует"),
                                                     new OverflowException("Операция привела к переполнению")};

foreach (Exception e in exceptions)
{
    try
    {
        throw e;
    }
    catch (MyException ex)
    {
        Console.WriteLine($"{ex.Message}\nПерейдите по ссылке https://docs.microsoft.com/ru-ru/dotnet/csharp/fundamentals/exceptions/");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    finally
    {
        Console.WriteLine();
    }
}

Console.ReadLine();

public class MyException : Exception
{
    public MyException(string message) : base(message) { }
}