namespace Pokedex.Core
{
    public class APICodes
    {
        public const string PokeListed = "[P-100] Listed All Pokemons.";
        public const string PokeAdded = "[P-101] New Pokedex Entry: ";
        public const string PokeUpdated = "[P-102] Pokedex Entry Updated: ";
        public const string PokeDeleted = "[P-103] Pokedex Entry Removed: ";
        public const string PokeDisplayed = "[P-104] Accessed Pokemon From Pokedex: ";


        public const string TrainerListed = "[T-100] Listed All Trainers.";
        public const string TrainerAdded = "[T-101] New Trainer Added: ";
        public const string TrainerUpdated = "[T-102] Trainer Updated: ";
        public const string TrainerDeleted = "[T-103] Trainer Deleted: ";
        public const string TrainerDisplaed = "[T-104] Trainer Accessed: ";


        public const string PokeNotFound = "[P-404] Couldn't Fetch Information About Following Pokemon: ";
        public const string TrainerNotFound = "[T-404] Couldn't Fetch Information About Following Trainer: ";

        public const string EmptyPokedex = "[Pokdex-404] Pokedex Have Not Been Populated Yet.";
    }
}