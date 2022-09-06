using UnityEngine;

namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_PurplePoison_V21341 : BattleUnitBuf
    {
        public override void OnRoundStartAfter()
        {
            _owner.TakeDamage(stack * _owner.MaxHp / 100);
            AddStacks(-1);
            if (stack == 0) _owner.bufListDetail.RemoveBuf(this);
        }
        public void AddStacks(int stacks)
        {
            stack += stacks;
            stack = Mathf.Clamp(stack, 0, 25);
        }
    }
}
