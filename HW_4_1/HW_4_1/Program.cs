using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        await GetUsers();
        await RegisterUser();
        // Вы можете реализовать и другие методы аналогичным образом
    }

    static async Task GetUsers()
    {
        HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/users");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }

    static async Task RegisterUser()
    {
        var user = new { email = "eve.holt@reqres.in", password = "pistol" };
        HttpResponseMessage response = await client.PostAsJsonAsync("https://reqres.in/api/register", user);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
    }
}
