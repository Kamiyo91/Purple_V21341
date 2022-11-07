using BigDLL4221.Passives;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Clone_V21341 : PassiveAbility_UnitSummonedWithCustomData_DLL4221
    {
        public override void OnWaveStart()
        {
            var passive = owner.passiveDetail.AddPassive(new PassiveAbility_CloneHidedPassive_V21341());
            passive.OnWaveStart();
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_Clone_V21341>())
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Clone_V21341());
            base.OnWaveStart();
        }

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetParameters(new SummonedUnitStatModels().CloneStatModel);
        }

        public override int SpeedDiceNumAdder()
        {
            return owner.faction == Faction.Enemy ? 1 : base.SpeedDiceNumAdder();
        }
    }
}