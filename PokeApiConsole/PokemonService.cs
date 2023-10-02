using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using PokeApiNet;

namespace PokeApiConsole
{
	public class PokemonService : IPokemonService
	{
        public PokemonService()
        {
        }

        public HashSet<string> doubleDamageFrom = new HashSet<string>();
        public HashSet<string> doubleDamageTo = new HashSet<string>();
        public HashSet<string> halfDamageFrom = new HashSet<string>();
        public HashSet<string> halfDamageTo = new HashSet<string>();
        public HashSet<string> noDamageFrom = new HashSet<string>();
        public HashSet<string> noDamageTo = new HashSet<string>();

        public void GetDamageDetails(PokeApiNet.Type pokemonType)
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

        public void GetTypes(Pokemon pokemonData)
        {
            Console.WriteLine("Type of the Pokemon");
            foreach (var type in pokemonData.Types)
            {
                Console.WriteLine("-" + type.Type.Name);
            }

            // throw new NotImplementedException();
        }

        public void PrintDamageDetails()
        {
            Console.WriteLine("Double Damage from");
            foreach (var s in doubleDamageFrom)
            {
                Console.WriteLine("-" + s);
            }
            Console.WriteLine("Double Damage To");
            foreach (var s in doubleDamageTo)
            {
                Console.WriteLine("-" + s);
            }
            Console.WriteLine("Half Damage From");
            foreach (var s in halfDamageFrom)
            {
                Console.WriteLine("-" + s);
            }
            Console.WriteLine("Half Damage To");
            foreach (var s in halfDamageTo)
            {
                Console.WriteLine("-" + s);
            }
            Console.WriteLine("No Damage From");
            foreach (var s in noDamageFrom)
            {
                Console.WriteLine("-" + s);
            }
            Console.WriteLine("No Damage To");
            foreach (var s in noDamageTo)
            {
                Console.WriteLine("-" + s);
            }

            //throw new NotImplementedException();
        }
    }
}

