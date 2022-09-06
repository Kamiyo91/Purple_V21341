using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Time_Recession_V21341 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            UnitUtil.ReadyCounterCard(owner,10,PurpleModParameters.PackageId);
        }
    }
}
