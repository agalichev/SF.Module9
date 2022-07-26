Exception myExeption = new Exception("Пользовательское исключение");
myExeption.HelpLink = "https://docs.microsoft.com/ru-ru/dotnet/csharp/fundamentals/exceptions/";
myExeption.Data.Add("Дата создания исключения: ", DateTime.Now);

Exception[] exceptions = new Exception[5];
exceptions[0] = myExeption;
exceptions[1] = new ArgumentException("Недопустимый аргумент");
exceptions[2] = new FormatException("Значение не соответствует формату преобразования");
exceptions[3] = new FileNotFoundException("Такой файл не существует");
exceptions[4] = new OverflowException("Операция привела к переполнению");

foreach (Exception e in exceptions)
{
    try
    {
        throw e;
    }
    catch (Exception ex)
    {
        if (ex.Equals(myExeption)) 
        {
            Console.WriteLine($"{myExeption.Message}\nПерейдите по ссылке {ex.HelpLink}");

        } 
        else Console.WriteLine($"Ошибка: {ex.Message}");
    }
    finally
    {
        Console.WriteLine();
    }
}

Console.ReadLine();