using System.Linq;
using Purple_V21341.Buffs;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_TimePerception_V21341 : DiceCardSelfAbilityBase
    {
        private int _count;

        public override void OnUseCard()
        {
            _count = 0;
            owner.allyCardDetail.DrawCards(1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 1, owner);
        }

        public override void OnWinParryingDef()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 1, owner);
            _count++;
        }

        public override void OnEndBattle()
        {
            if (!(owner.bufListDetail.GetActivatedBufList().FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341) is
                    BattleUnitBuf_SmokeBomb_V21341 buff)) return;
            if (_count <= 2) return;
            buff.OnAddBuf(1);
        }
    }
}