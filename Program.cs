using System.Text;
using System.Text.Json;
using Task030923.Sorts;
using Task030923.Generator;
using Task030923.Interfaces;
using Microsoft.Extensions.Configuration;

var sortList = new List<ISort>()
{
    new Bubble(),
    new Bucket(),
    new Counting(),
    new Heap(),
    new Insertion(),
    new Merge(),
    new Quick()
};

var random = new Random().Next(0, sortList.Count);
ISort randomSorted = sortList[random];

var randomArray = new RandomArray().GetArray();
var sortRandom = sortList[random];

var sorting = sortRandom.Sort(ref randomArray);
var sortName = sortRandom.GetType().Name;

var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true);
var endpoint = configBuilder.Build().GetSection("EndpointPath").Value;


static async Task SendPostMessage(List<int> sort, string name, string endPoint)
{
    using var client = new HttpClient();
    var content = new StringContent(JsonSerializer.Serialize(sort), Encoding.UTF8, "application/json");
    await client.PostAsync(endPoint, content);

    await Console.Out.WriteLineAsync($"Sort name:{name} \n Sort array:{string.Join(",", sort)}");
}

await Task.Run(async () => await SendPostMessage(sorting, sortName, endpoint));

Console.ReadLine();
