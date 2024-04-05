using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ModelsCourse.Data;
using ModelsCourse.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelsCourse 
{
    internal class Program 
    {
        static void Main(string[] agrs) 
        {   
            // Get config info from json file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            // Computer myComputer = new Computer()
            // {
            //     Motherboard = "GT908", 
            //     HasWifi = false, 
            //     HasLTE = false, 
            //     ReleaseDate = DateTime.Now, 
            //     Price = 698.99m, 
            //     CPUCores = 6, 
            //     VideoCard = "GTX 20410"
            // };

            // Console.WriteLine(myComputer.Motherboard);

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard, 
            //     HasWifi, 
            //     HasLTE, 
            //     ReleaseDate, 
            //     Price, 
            //     CPUCores, 
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard 
            //     + "','" + myComputer.HasWifi
            //     + "','" + myComputer.HasLTE
            //     + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //     + "','" + myComputer.Price
            //     + "','" + myComputer.CPUCores
            //     + "','" + myComputer.VideoCard
            // + "')";

            // File.WriteAllText("log.txt", sql);

        //     using StreamWriter openFile = new("log.txt", append: true); 

        //     openFile.WriteLine(sql + "\n");

        //     openFile.Close();

            string computersJson = File.ReadAllText("ComputersSnake.json");

            Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
                cfg.CreateMap<ComputerSnake, Computer>()
                    .ForMember(destination => destination.ComputerId, options =>
                        options.MapFrom(source => source.computer_id))
                    .ForMember(destination => destination.Motherboard, options =>
                        options.MapFrom(source => source.motherboard))
                    .ForMember(destination => destination.CPUCores, options =>
                        options.MapFrom(source => source.cpu_cores))
                    .ForMember(destination => destination.HasWifi, options =>
                        options.MapFrom(source => source.has_wifi))
                    .ForMember(destination => destination.HasLTE, options =>
                        options.MapFrom(source => source.has_lte))
                    .ForMember(destination => destination.VideoCard, options =>
                        options.MapFrom(source => source.video_card))
                    .ForMember(destination => destination.ReleaseDate, options =>
                        options.MapFrom(source => source.release_date))
                    .ForMember(destination => destination.Price, options =>
                        options.MapFrom(source => source.price));
            }));

            // IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

            // if(computersSystem != null) 
            // {
            //     IEnumerable<Computer> computersResult = mapper.Map<IEnumerable<Computer>>(computersSystem);

            //     foreach(Computer computer in computersResult) 
            //     {
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }

            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if(computersSystem != null) 
            {
                foreach(Computer computer in computersSystem) 
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }
            

            // JsonSerializerOptions options = new JsonSerializerOptions() 
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };

            // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
            // IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // if(computersNewtonsoft != null) 
            // {
            //     foreach(Computer computer in computersNewtonsoft) {
            //         string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //             Motherboard, 
            //             HasWifi, 
            //             HasLTE, 
            //             ReleaseDate, 
            //             Price, 
            //             VideoCard
            //         ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
            //             + "','" + computer.HasWifi
            //             + "','" + computer.HasLTE
            //             + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd")
            //             + "','" + computer.Price
            //             + "','" + EscapeSingleQuote(computer.VideoCard)
            //         + "')";

            //         // Console.WriteLine(sql);

            //         dapper.ExecuteSql(sql);
            //     }
            // }

            // JsonSerializerSettings settings = new JsonSerializerSettings()
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };

            // string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);
            // File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);

            // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersNewtonsoft, options);
            // File.WriteAllText("computersCopySystem.txt", computersCopySystem);
        }

        static string EscapeSingleQuote(string input) 
        {
            string output = input.Replace("'", "''");

            return output;
        }
    }   
}