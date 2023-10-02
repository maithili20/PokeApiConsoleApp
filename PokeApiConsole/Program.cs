using Microsoft.Extensions.DependencyInjection;
using PokeApiNet;


namespace PokeApiConsole
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IPokemonService, PokemonService>()
            .BuildServiceProvider();


            Console.WriteLine("Enter Pokemon Name -");
            string name = Console.ReadLine();

            try
            {
                if (name != "")
                {
                    PokeApiClient pokeClient = new PokeApiClient();
                    Pokemon pokemonData = await pokeClient.GetResourceAsync<Pokemon>(name);
                    var pokemonService = serviceProvider.GetRequiredService<IPokemonService>();
                    pokemonService.GetTypes(pokemonData);

                    Console.WriteLine($"Strengths and Weaknesses for {name}:");
                    foreach (var type in pokemonData.Types)
                    {
                        string typeName = type.Type.Name;
                        PokeApiNet.Type pokemonType = await pokeClient.GetResourceAsync<PokeApiNet.Type>(typeName);
                        pokemonService.GetDamageDetails(pokemonType);
                    }
                    pokemonService.PrintDamageDetails();

                }
                else
                {
                    Console.WriteLine("Pokemon name cannot be null. Please try again");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Not Found"))
                {
                    Console.WriteLine("Pokemon not found. Please try again with new pokemon");
                }
                else
                {
                    throw new Exception();
                }

            }
        }
    }
}


