using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_PoisonedBlade_V21341 : PassiveAbilityBase
    {
        public int Multiplier;
        public override void OnRoundStartAfter()
        {
            Multiplier = 1;
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            var target = behavior.card.target;
            if (target == null) return;
            var checkInt = 30 * Multiplier;
            if (RandomUtil.Range(0, 100) <= checkInt)
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 1, owner);
            var checkInt2 = 15 * Multiplier;
            if (RandomUtil.Range(0, 100) > checkInt2) return;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_PurplePoison_V21341) is
                BattleUnitBuf_PurplePoison_V21341 buff) buff.OnAddBuf(1);
            else target.bufListDetail.AddBuf(new BattleUnitBuf_PurplePoison_V21341());
        }
    }
}
