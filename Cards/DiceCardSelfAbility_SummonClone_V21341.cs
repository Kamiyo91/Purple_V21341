using System.Linq;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_SummonClone_V21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341)?.stack > -1;
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
            SummonSpecialUnit(Singleton<StageController>.Instance.GetCurrentStageFloorModel(), 10000002, new LorId(PurpleModParameters.PackageId, 2), unit.emotionDetail.EmotionLevel);
            UnitUtil.RefreshCombatUI();
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }
        public static void SummonSpecialUnit(StageLibraryFloorModel floor, int unitId, LorId unitNameId, int emotionLevel)
        {
            UnitUtil.AddNewUnitPlayerSideCustomDataOnPlay(floor, new UnitModel
            {
                Id = unitId,
                Name = ModParameters.NameTexts
                    .FirstOrDefault(x => x.Key.Equals(unitNameId)).Value,
                EmotionLevel = emotionLevel,
                Pos = BattleObjectManager.instance.GetList(Faction.Player).Count,
                Sephirah = floor.Sephirah,
            }, PurpleModParameters.PackageId,true);
        }
    }
}
