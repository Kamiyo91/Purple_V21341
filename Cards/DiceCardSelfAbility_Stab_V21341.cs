namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_Stab_V21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPoint(1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 2, owner);
        }
    }
}