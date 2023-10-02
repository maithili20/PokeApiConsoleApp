using PokeApiConsole;
using PokeApiNet;

namespace PokeApiConsoleTests;

public class PokemonServiceTests
{
    private readonly PokemonService _pokemonService;

    public PokemonServiceTests()
    {
        _pokemonService = new PokemonService();
    }
    [Fact]
    public void GetTypesValidPokemon()
    {
        //var pokemonData = new Pokemon
        //{
        //    Types = new List<PokemonType>
        //{
        //    new PokemonType { Type = new Type { Name = "Grass" } },
        //    new PokemonType { Type = new Type { Name = "Poison" } }
        //}
        //};
        var pokemonData = new Pokemon();
        //pokemonData.Types.Add("Grass");

        var expectedOutput = "-Grass\n-Poison\n";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        _pokemonService.GetTypes(pokemonData);
        var actualOutput = stringWriter.ToString();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }
    [Fact]
    public void ValidatePrintDamageDetails()
    {
        _pokemonService.doubleDamageFrom.Add("Test");
        
    }
}
