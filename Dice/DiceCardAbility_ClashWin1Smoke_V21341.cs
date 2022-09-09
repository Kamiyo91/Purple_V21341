namespace Purple_V21341.Dice
{
    public class DiceCardAbility_ClashWin1Smoke_V21341 : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            card.target?.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Smoke, 1, owner);
        }
    }
}