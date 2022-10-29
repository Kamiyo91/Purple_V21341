using BigDLL4221.Models;
using BigDLL4221.Passives;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Clone_V21341 : PassiveAbility_UnitSummonedWithCustomData_DLL4221
    {
        public override void OnWaveStart()
        {
            var passive = owner.passiveDetail.AddPassive(new PassiveAbility_CloneHidedPassive_V21341());
            passive.OnWaveStart();
            SetParameters(new SummonedUnitStatModel(true, reviveAfterScenesNpc: 2, hpRecoveredWithRevive: owner.MaxHp,
                removeFromUIAfterDeath: owner.faction == Faction.Player,damageOptions: 
                new DamageOptions(lessMassAttackDamage:9999,lessMassAttackBreakDamage:9999,lessMassAttackIndividualDamage:9999,lessMassAttackIndividualBreakDamage:9999)));
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_Clone_V21341>())
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Clone_V21341());
        }

        public override int SpeedDiceNumAdder()
        {
            return owner.faction == Faction.Enemy ? 2 : base.SpeedDiceNumAdder();
        }
    }
}