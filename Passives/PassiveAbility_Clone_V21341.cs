using BigDLL4221.Models;
using BigDLL4221.Passives;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Clone_V21341 : PassiveAbility_UnitSummonedWithCustomData_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(new SummonedUnitStatModel(true, reviveAfterScenesNpc: 2, hpRecoveredWithRevive: owner.MaxHp,
                removeFromUIAfterDeath: owner.faction == Faction.Player));
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_Clone_V21341>())
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Clone_V21341());
            PassiveUtil.ChangeLoneFixerPassive(owner.faction, new LorId(PurpleModParameters.PackageId, 7));
        }

        public override int SpeedDiceNumAdder()
        {
            return owner.faction == Faction.Enemy ? 2 : base.SpeedDiceNumAdder();
        }

        public override int GetDamageReduction(BattleDiceBehavior behavior)
        {
            switch (behavior.card.card.XmlData.Spec.Ranged)
            {
                case CardRange.FarArea:
                    return 9999;
                case CardRange.FarAreaEach:
                    return 9999;
                default:
                    return base.GetDamageReduction(behavior);
            }
        }

        public override int GetBreakDamageReduction(BattleDiceBehavior behavior)
        {
            switch (behavior.card.card.XmlData.Spec.Ranged)
            {
                case CardRange.FarArea:
                    return 9999;
                case CardRange.FarAreaEach:
                    return 9999;
                default:
                    return base.GetBreakDamageReduction(behavior);
            }
        }
    }
}