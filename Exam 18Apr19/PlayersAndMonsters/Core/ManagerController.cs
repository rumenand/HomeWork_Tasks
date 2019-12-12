namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private ICardRepository cards;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;
        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            this.players.Add(this.playerFactory.CreatePlayer(type, username));
            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            this.cards.Add(this.cardFactory.CreateCard(type, name));
            return String.Format(ConstantMessages.SuccessfullyAddedCard,type,name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var targetPlayer = this.players.Find(username);
            var targetCard = this.cards.Find(cardName);
            targetPlayer.CardRepository.Add(targetCard);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.players.Find(attackUser);
            var enemyPlayer = this.players.Find(enemyUser);
            new BattleField().Fight(attackPlayer, enemyPlayer);
            return String.Format(ConstantMessages.FightInfo,
                attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in this.players.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo,
                        card.Name, card.DamagePoints));
                }
                sb.AppendLine(String.Format(ConstantMessages.DefaultReportSeparator));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
