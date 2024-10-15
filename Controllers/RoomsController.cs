using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class Room
{
    public string Type { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public string Creator { get; set; }
}

public class RoomsController : Controller
{
    private readonly HttpClient _httpClient;

    public RoomsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetStringAsync("https://tryhackme.com/api/new-rooms");
        var rooms = JsonConvert.DeserializeObject<List<Room>>(response);
        return View(rooms);
    }
}
