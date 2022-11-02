using BigDLL4221.Passives;
using BigDLL4221.Utils;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_CloneHidedPassive_V21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            Hide();
            PassiveUtil.ChangeLoneFixerPassive(owner.faction, new PassiveAbility_LoneFixer_DLL4221());
        }
    }
}