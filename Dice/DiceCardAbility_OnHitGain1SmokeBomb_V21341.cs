using BigDLL4221.Extensions;
using Purple_V21341.Buffs;

namespace Purple_V21341.Dice
{
    public class DiceCardAbility_OnHitGain1SmokeBomb_V21341 : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            owner.GetActiveBuff<BattleUnitBuf_SmokeBomb_V21341>()?.OnAddBuf(1);
        }
    }
}