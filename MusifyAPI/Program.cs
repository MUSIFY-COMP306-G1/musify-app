
using Microsoft.EntityFrameworkCore;
using MusifyLibrary.Models;
using MusifyAPI.Services;
using Newtonsoft.Json;

namespace MusifyAPI;

public class Program
{
    static HttpClient client = new HttpClient();
    public static void Main(string[] args)
    {
        RunAsync().GetAwaiter().GetResult();
        Console.WriteLine("this working working");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MusifyContext>(options =>
        options.UseSqlServer(
        builder.Configuration.GetConnectionString("Connection2RDS")
        ));

        builder.Services.AddScoped<IMusifyRepository, MusifyRepository>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

      
    }

    static async Task RunAsync()
    {
        client.BaseAddress = new Uri("https://localhost:7111");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
            string json;
            HttpResponseMessage response;
            response = await client.GetAsync("/api/SongItem.json");
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                IEnumerable<SongItem> items = JsonConvert.DeserializeObject <IEnumerable<SongItem >> (json);
                foreach(SongItem item in items)
                {
                    Console.WriteLine(item);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Internal Server error");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
    }
}



