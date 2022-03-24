// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using basic;

Console.WriteLine("Hello, World!");
var countryName = "France";

var request = new HttpRequestMessage(HttpMethod.Get, $"https://restcountries.com/v3.1/name/{countryName}");
var client = new HttpClient();

var response = await client.SendAsync(request);

if (response.IsSuccessStatusCode)
{
    var content = await response.Content.ReadAsStringAsync();

    var details =  JsonSerializer.Deserialize<List<Country>>(content);
    Console.WriteLine(details?[0].Name.Official);
}