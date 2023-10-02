using PokeApiNet;

namespace PokeApiConsole
{
    public class PokemonService : IPokemonService
    {

        public HashSet<string> doubleDamageFrom = new HashSet<string>();
        public HashSet<string> doubleDamageTo = new HashSet<string>();
        public HashSet<string> halfDamageFrom = new HashSet<string>();
        public HashSet<string> halfDamageTo = new HashSet<string>();
        public HashSet<string> noDamageFrom = new HashSet<string>();
        public HashSet<string> noDamageTo = new HashSet<string>();

        public PokemonService()
        {
        }

        public void GetDamageDetails(PokeApiNet.Type pokemonType)
        {
            try
            {
                if (pokemonType.DamageRelations != null)
                {
                    foreach (var ddf in pokemonType.DamageRelations.DoubleDamageFrom)
                    {
                        doubleDamageFrom.Add(ddf.Name);
                    }
                    foreach (var ddt in pokemonType.DamageRelations.DoubleDamageTo)
                    {
                        doubleDamageTo.Add(ddt.Name);
                    }
                    foreach (var hdf in pokemonType.DamageRelations.HalfDamageFrom)
                    {
                        halfDamageFrom.Add(hdf.Name);
                    }
                    foreach (var hdt in pokemonType.DamageRelations.HalfDamageTo)
                    {
                        halfDamageTo.Add(hdt.Name);
                    }
                    foreach (var ndf in pokemonType.DamageRelations.NoDamageFrom)
                    {
                        noDamageFrom.Add(ndf.Name);
                    }
                    foreach (var ndt in pokemonType.DamageRelations.NoDamageTo)
                    {
                        noDamageTo.Add(ndt.Name);
                    }
                }
                else
                {
                    Console.WriteLine("No Strength or Weaknesses found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetTypes(Pokemon pokemonData)
        {
            Console.WriteLine("Type of the Pokemon");
            try
            {
                foreach (var type in pokemonData.Types)
                {
                    Console.WriteLine("-" + type.Type.Name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PrintDamageDetails()
        {
            try
            {
                if (doubleDamageFrom.Count != 0)
                {
                    Console.WriteLine("Double Damage from");
                    foreach (var s in doubleDamageFrom)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No Double Damage From relation found for this pokemon");
                }

                if (doubleDamageTo.Count != 0)
                {
                    Console.WriteLine("Double Damage To");
                    foreach (var s in doubleDamageTo)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No Double Damage To relation found for this pokemon");
                }
                if (halfDamageFrom.Count != 0)
                {
                    Console.WriteLine("Half Damage From");
                    foreach (var s in halfDamageFrom)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No Half Damage From relation found for this pokemon");
                }
                if (halfDamageTo.Count != 0)
                {
                    Console.WriteLine("Half Damage To");
                    foreach (var s in halfDamageTo)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No Half Damage To relation found for this pokemon");
                }
                if (noDamageFrom.Count != 0)
                {
                    Console.WriteLine("No Damage From");
                    foreach (var s in noDamageFrom)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No \'No Damage From\' relation found for this pokemon");
                }
                if (noDamageTo.Count != 0)
                {
                    Console.WriteLine("No Damage To");
                    foreach (var s in noDamageTo)
                    {
                        Console.WriteLine("-" + s);
                    }
                }
                else
                {
                    Console.WriteLine("No \'No Damage To\'  relation found for this pokemon");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

