using BigDLL4221.Extensions;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_ExhaleSmoke_V21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (!(owner.bufListDetail.GetActivatedBuf(KeywordBuf.Smoke) is BattleUnitBuf_smoke smoke) ||
                smoke.stack < 3) return;
            smoke.UseStack(3);
            owner.GetActiveBuff<BattleUnitBuf_SmokeBomb_V21341>()?.OnAddBuf(1);
            card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_smoke3atk());
            owner.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
}