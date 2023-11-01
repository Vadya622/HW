using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string result = await ConcatenateAsync();
        Console.WriteLine(result);
    }

    static async Task<string> ReadFileAsync(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            return await reader.ReadToEndAsync();
        }
    }

    static async Task<string> ConcatenateAsync()
    {
        Task<string> helloTask = ReadFileAsync("Hello.txt");
        Task<string> worldTask = ReadFileAsync("World.txt");

        await Task.WhenAll(helloTask, worldTask);

        string helloText = await helloTask;
        string worldText = await worldTask;

        return helloText + " " + worldText;
    }
}
