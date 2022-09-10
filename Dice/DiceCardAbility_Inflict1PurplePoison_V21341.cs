using System.Linq;
using Purple_V21341.Buffs;

namespace Purple_V21341.Dice
{
    public class DiceCardAbility_Inflict1PurplePoison_V21341 : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target?.bufListDetail.GetActivatedBufList()
                    .FirstOrDefault(x => x is BattleUnitBuf_PurplePoison_V21341) is BattleUnitBuf_PurplePoison_V21341
                buff)
            {
                buff.AddStacks(1);
            }
            else
            {
                var newBuff = new BattleUnitBuf_PurplePoison_V21341
                {
                    stack = 1
                };
                target?.bufListDetail.AddBuf(newBuff);
            }
        }
    }
}