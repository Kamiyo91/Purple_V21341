using BigDLL4221.Buffs;

namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_SmokeBombNpc_V21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_SmokeBombNpc_V21341() : base(infinite: true, lastOneScene: false)
        {
        }

        protected override string keywordId => "SmokeBomb_V21341";
        protected override string keywordIconId => "SmokeBomb_V21341";
        public override int MaxStack => 10;
        public override int MinStack => 10;

        public override void OnRoundStartAfter()
        {
            if (_owner.faction == Faction.Enemy) OnAddBuf(1);
            if (_owner.bufListDetail.HasBuf<BattleUnitBuf_CardCostM1_V21341>()) return;
            _owner.bufListDetail.AddBuf(new BattleUnitBuf_CardCostM1_V21341());
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (stack > 4) behavior.ApplyDiceStatBonus(new DiceStatBonus { min = 1, max = 1 });
            if (stack > 9) behavior.ApplyDiceStatBonus(new DiceStatBonus { min = 1, max = 1 });
        }
    }
}