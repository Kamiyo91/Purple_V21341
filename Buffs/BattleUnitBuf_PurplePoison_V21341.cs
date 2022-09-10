using UnityEngine;

namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_PurplePoison_V21341 : BattleUnitBuf
    {
        protected override string keywordId => "WonderlandPosion_V21341";
        protected override string keywordIconId => "WonderlandPosion_V21341";

        public override void OnRoundStartAfter()
        {
            _owner.TakeDamage(stack * _owner.MaxHp / 100);
            OnAddBuf(-1);
            if (stack == 0) _owner.bufListDetail.RemoveBuf(this);
        }

        public override void OnAddBuf(int addedStack)
        {
            stack += addedStack;
            stack = Mathf.Clamp(stack, 0, 25);
        }
    }
}