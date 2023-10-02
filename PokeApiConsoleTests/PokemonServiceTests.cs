using PokeApiConsole;
using PokeApiNet;


namespace PokeApiConsoleTests;

public class PokemonServiceTests
{
    private readonly PokemonService _pokemonService;
    private readonly PokeApiClient _pokeApiClient;

    public PokemonServiceTests()
    {
        _pokemonService = new PokemonService();
        _pokeApiClient = new PokeApiClient();
    }
    [Fact]
    public async Task ValidateGetDamageDetailsAsyncNotEmpty()
    {

        PokeApiNet.Type pokemonType = await _pokeApiClient.GetResourceAsync<PokeApiNet.Type>("grass");

        _pokemonService.GetDamageDetails(pokemonType);


        Assert.NotEmpty(_pokemonService.doubleDamageFrom);
    }

    [Fact]
    public async Task ValidateGetDamageDetailsAsyncIsEmpty()
    {

        PokeApiNet.Type pokemonType = await _pokeApiClient.GetResourceAsync<PokeApiNet.Type>("");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            _pokemonService.GetDamageDetails(pokemonType);
            string actualOutput = sw.ToString();
            string expectedOutput = "No Strength or Weaknesses found\n";

            Assert.Empty(_pokemonService.doubleDamageFrom);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }

    [Fact]
    public void ValidatePrintDamageDetails()
    {
        _pokemonService.doubleDamageFrom = new HashSet<string> { "Grass", "Poison" };
        _pokemonService.doubleDamageTo = new HashSet<string> { "Water", "Fire" };
        _pokemonService.halfDamageFrom = new HashSet<string> { "Bug", "Ghost" };
        _pokemonService.halfDamageTo = new HashSet<string> { "Steel", "Electric" };
        _pokemonService.noDamageFrom = new HashSet<string> { "Psychic", "Ice" };
        _pokemonService.noDamageTo = new HashSet<string> { "Dragon", "Fairy" };

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            _pokemonService.PrintDamageDetails();

            string actualOutput = sw.ToString();
            string expectedOutput = string.Format("Double Damage from\n-Grass\n-Poison\nDouble Damage To" +
                "\n-Water\n-Fire\nHalf Damage From\n-Bug\n-Ghost\nHalf Damage To\n-Steel\n-Electric\nNo Damage From" +
                "\n-Psychic\n-Ice\nNo Damage To\n-Dragon\n-Fairy\n");
            Assert.Equal(expectedOutput, actualOutput);


        }


    }

    [Fact]
    public void ValidatePrintDamageDetailsWhenNoDamageEmpty()
    {
        _pokemonService.doubleDamageFrom = new HashSet<string> { "Grass", "Poison" };
        _pokemonService.doubleDamageTo = new HashSet<string> { "Water", "Fire" };
        _pokemonService.halfDamageFrom = new HashSet<string> { "Bug", "Ghost" };
        _pokemonService.halfDamageTo = new HashSet<string> { "Steel", "Electric" };

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            _pokemonService.PrintDamageDetails();

            string actualOutput = sw.ToString();

            string expectedOutput = string.Format("Double Damage from\n-Grass\n-Poison\nDouble Damage To" +
                "\n-Water\n-Fire\nHalf Damage From\n-Bug\n-Ghost\nHalf Damage To\n-Steel\n-Electric" +
                "\nNo 'No Damage From' relation found for this pokemon\nNo 'No Damage To'  relation found for this pokemon\n");
            Assert.Equal(expectedOutput, actualOutput);


        }
    }
}