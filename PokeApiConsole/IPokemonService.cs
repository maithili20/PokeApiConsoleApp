using PokeApiNet;

namespace PokeApiConsole
{
    public interface IPokemonService
    {
        void GetTypes(Pokemon pokemonData);
        void GetDamageDetails(PokeApiNet.Type pokemonType);
        void PrintDamageDetails();

    }
}

