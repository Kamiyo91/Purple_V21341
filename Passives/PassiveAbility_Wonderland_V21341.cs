using BigDLL4221.Passives;
using Purple_V21341.BLL;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Wonderland_V21341 : PassiveAbility_PlayerMechBase_DLL4221
    {
        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new MechUtilModels().PurplePoisonPlayerUtil);
        }
    }
}