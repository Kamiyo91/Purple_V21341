using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_PoisonedBlade_V21341 : PassiveAbilityBase
    {
        public int Multiplier;

        public override void OnRoundEndTheLast_ignoreDead()
        {
            Multiplier = 1;
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            var target = behavior.card.target;
            if (target == null) return;
            if (RandomUtil.Range(0, 100) <= 45 * Multiplier)
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 1, owner);
            if (RandomUtil.Range(0, 100) > 25 * Multiplier) return;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_PurplePoison_V21341) is
                BattleUnitBuf_PurplePoison_V21341 buff) buff.OnAddBuf(1);
            else target.bufListDetail.AddBuf(new BattleUnitBuf_PurplePoison_V21341());
        }
    }
}