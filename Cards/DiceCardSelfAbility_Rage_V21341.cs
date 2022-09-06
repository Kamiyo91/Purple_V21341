namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_Rage_V21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPoint(1);
            if (!(owner.bufListDetail.GetActivatedBuf(KeywordBuf.Smoke) is BattleUnitBuf_smoke smoke) || smoke.stack < 3) return;
            smoke.UseStack(3);
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus { power = 1 });
            owner.allyCardDetail.DrawCards(1);
        }
    }
}
