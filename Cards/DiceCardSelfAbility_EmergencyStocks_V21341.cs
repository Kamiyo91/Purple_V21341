using System.Linq;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_EmergencyStocks_V21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(unit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
            if (!(unit.bufListDetail.GetActivatedBufList().FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341) is
                    BattleUnitBuf_SmokeBomb_V21341 buff)) return;
            unit.cardSlotDetail.RecoverPlayPoint(unit.MaxPlayPoint);
            unit.allyCardDetail.DrawCards(2);
            unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 10, unit);
            buff.OnAddBuf(10);
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }
    }
}