using System.Linq;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_SmokeBomb_V21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.bufListDetail.GetActivatedBufList()
                       .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341)?.stack > 0 &&
                   !owner.cardSlotDetail.cardAry.Exists(x =>
                       x?.card?.GetID() == new LorId(PurpleModParameters.PackageId, 12));
            ;
        }

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(unit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
            if (!(unit.bufListDetail.GetActivatedBufList()
                        .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341) is BattleUnitBuf_SmokeBomb_V21341
                    buff)) return;
            unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 1, unit);
            unit.cardSlotDetail.RecoverPlayPoint(1);
            unit.allyCardDetail.DrawCards(1);
            buff.OnAddBuf(-1);
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }
    }
}