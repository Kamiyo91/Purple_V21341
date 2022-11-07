using System;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_PoisonedBlade_V21341 : PassiveAbilityBase
    {
        private Random _random;
        public int Multiplier;

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            _random = new Random();
        }

        public override void OnRoundEndTheLast_ignoreDead()
        {
            Multiplier = 1;
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            var target = behavior.card.target;
            if (target == null) return;
            if (_random.Next(0, 100) <= 30 * Multiplier)
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 1, owner);
            if (_random.Next(0, 100) > 15 * Multiplier) return;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_PurplePoison_V21341) is
                BattleUnitBuf_PurplePoison_V21341 buff) buff.OnAddBuf(1);
            else target.bufListDetail.AddBuf(new BattleUnitBuf_PurplePoison_V21341());
        }
    }
}