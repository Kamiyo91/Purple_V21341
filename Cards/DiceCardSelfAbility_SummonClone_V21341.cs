using System.Linq;
using BigDLL4221.Utils;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_SummonClone_V21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.bufListDetail.GetActivatedBufList()
                       .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341)?.stack > 4 &&
                   !owner.cardSlotDetail.cardAry.Exists(x =>
                       x?.card?.GetID() == new LorId(PurpleModParameters.PackageId, 12));
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
                buff.OnAddBuf(-5);
            SummonSpecialUnit(unit.emotionDetail.EmotionLevel);
            UnitUtil.RefreshCombatUI();
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }

        public static BattleUnitModel SummonSpecialUnit(int emotionLevel)
        {
            return UnitUtil.AddNewUnitPlayerSideCustomData(UnitModels.PlayerClone,
                BattleObjectManager.instance.GetList(Faction.Player).Count, emotionLevel);
        }
    }
}