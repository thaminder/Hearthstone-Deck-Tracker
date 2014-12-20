using System.Linq;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace Hearthstone_Deck_Tracker
{
	public class Secret
	{
		public string CardId { get; private set; }
		public int Count { get; set; }

		public int AdjustedCount
		{
			get
			{
				return (Config.Instance.AutoGrayoutSecrets && (Game.CurrentGameMode == GameMode.Casual || Game.CurrentGameMode == GameMode.Ranked ||
				         Game.CurrentGameMode == GameMode.Friendly || Game.CurrentGameMode == GameMode.Practice) &&
				        Game.OpponentCards.Any(x => !x.IsStolen && x.Id == CardId & x.Count >= 2))
					       ? 0
					       : Count;
			}
		}

		public Secret(string cardId, int count)
		{
			CardId = cardId;
			Count = count;
		}
	}
}