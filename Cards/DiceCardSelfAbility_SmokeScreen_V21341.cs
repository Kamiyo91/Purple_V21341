using System.Linq;
using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_SmokeScreen_V21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.bufListDetail.GetActivatedBufList()
                       .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341)?.stack > 4 &&
                   BattleObjectManager.instance.GetAliveList(owner.faction).Count > 1 &&
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
            if (unit.bufListDetail.GetActivatedBufList()
                    .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341) is BattleUnitBuf_SmokeBomb_V21341
                buff)
            {
                unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, buff.stack, unit);
                buff.OnAddBuf(-10);
            }

            if (!unit.bufListDetail.HasBuf<BattleUnitBuf_SmokeScreen_V21341>())
                unit.bufListDetail.AddBuf(new BattleUnitBuf_SmokeScreen_V21341());
            UnitUtil.RemoveDiceTargetsWithoutBreak(unit);
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }
    }
}