using System;

public interface IPrintable
{
    void Print();
}

public interface IScannable
{
    void Scan();
}

public class Printer : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Printing document...");
    }
}

public class Scanner : IScannable
{
    public void Scan()
    {
        Console.WriteLine("Scanning document...");
    }
}

public class PrintScanner : IPrintable, IScannable
{
    public void Print()
    {
        Console.WriteLine("Printing from print-scanner...");
    }

    public void Scan()
    {
        Console.WriteLine("Scanning from print-scanner...");
    }
}

public class TaskManager
{
    public void PrintTask(int taskId, IPrintable device)
    {
        Console.WriteLine($"Executing Print Task: {taskId}");
        device.Print();
    }

    public void ScanTask(int taskId, IScannable device)
    {
        Console.WriteLine($"Executing Scan Task: {taskId}");
        device.Scan();
    }
}

public class Program
{
    public static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();
        var printScanner = new PrintScanner();

        var scheduler = new TaskManager();

        scheduler.PrintTask(101, printer);
        scheduler.ScanTask(102, scanner);

        scheduler.PrintTask(103, printScanner);
        scheduler.ScanTask(104, printScanner);
    }
}
