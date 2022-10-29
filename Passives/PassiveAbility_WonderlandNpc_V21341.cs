using BigDLL4221.Passives;
using Purple_V21341.BLL;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_WonderlandNpc_V21341 : PassiveAbility_NpcMechBase_DLL4221
    {
        public override void OnWaveStart()
        {
            SetUtil(NpcMechUtilModels.PurplePoisonNpcUtil);
            base.OnWaveStart();
        }

        public override int SpeedDiceNumAdder()
        {
            return BattleObjectManager.instance.ExistsUnit(x =>
                x.passiveDetail.HasPassive<PassiveAbility_Clone_V21341>() && x.faction == owner.faction &&
                !x.IsDead())
                ? 0
                : base.SpeedDiceNumAdder();
        }
    }
}