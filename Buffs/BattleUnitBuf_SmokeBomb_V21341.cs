﻿using LOR_DiceSystem;
using UnityEngine;

namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_SmokeBomb_V21341 : BattleUnitBuf
    {
        public int HitCount;
        protected override string keywordId => "SmokeBomb_V21341";
        protected override string keywordIconId => "SmokeBomb_V21341";

        public override void OnRoundStartAfter()
        {
            if (_owner.faction == Faction.Enemy) OnAddBuf(1);
            HitCount = 0;
            if (stack < 10 || _owner.bufListDetail.HasBuf<BattleUnitBuf_CardCostM1_V21341>()) return;
            _owner.bufListDetail.AddBuf(new BattleUnitBuf_CardCostM1_V21341());
        }

        public override void BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (dmg == 0) return;
            HitCount++;
            if (HitCount < 3) return;
            HitCount = 0;
            OnAddBuf(-1);
        }

        public override void OnAddBuf(int addedStack)
        {
            stack += addedStack;
            stack = Mathf.Clamp(stack, 0, 10);
            if (stack > 9 && !_owner.bufListDetail.HasBuf<BattleUnitBuf_CardCostM1_V21341>())
                _owner.bufListDetail.AddBuf(new BattleUnitBuf_CardCostM1_V21341());
        }

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Evasion) OnAddBuf(1);
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (stack > 9) behavior.ApplyDiceStatBonus(new DiceStatBonus { min = 1, max = 1 });
        }
    }
}