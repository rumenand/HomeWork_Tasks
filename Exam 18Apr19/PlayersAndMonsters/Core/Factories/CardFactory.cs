

namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards;
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            switch (type)
            {
                case "Magic": return new MagicCard(name);
                case "Trap": return new TrapCard(name);
            }
            return null;
        }
    }
}
