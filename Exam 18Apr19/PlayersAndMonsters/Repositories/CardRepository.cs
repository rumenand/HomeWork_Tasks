using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> list;
        public CardRepository()
        {
            this.list = new List<ICard>();
        }
        public int Count => this.list.Count;

        public IReadOnlyCollection<ICard> Cards => this.list.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null) throw new ArgumentException("Card cannot be null!");
            if (this.Find(card.Name) != null) throw new ArgumentException($"Card {card.Name} already exists!");
            this.list.Add(card);
        }

        public ICard Find(string name)
        {
            return this.list.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(ICard card)
        {
            if (card == null) throw new ArgumentException("Card cannot be null!");
            var chCard = this.Find(card.Name);
            if (chCard == null) return false;
            this.list.Remove(card);
            return true;
        }
    }
}
