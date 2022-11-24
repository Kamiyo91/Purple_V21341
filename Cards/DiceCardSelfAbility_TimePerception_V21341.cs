using BigDLL4221.Extensions;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_TimePerception_V21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 2, owner);
            var speedDiceResultValue = card.speedDiceResultValue;
            var target = card.target;
            var targetSlotOrder = card.targetSlotOrder;
            if (targetSlotOrder < 0 || targetSlotOrder >= target.speedDiceResult.Count) return;
            var speedDice = target.speedDiceResult[targetSlotOrder];
            var targetDiceBroken = target.speedDiceResult[targetSlotOrder].breaked;
            if (speedDiceResultValue - speedDice.value <= 0 && !targetDiceBroken) return;
            owner.GetActiveBuff<BattleUnitBuf_SmokeBomb_V21341>()?.OnAddBuf(1);
        }
    }
}