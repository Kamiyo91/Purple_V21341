using System.Linq;
using Purple_V21341.Passives;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_PoisonedSword_V21341 : DiceCardSelfAbilityBase
    {
        private PassiveAbility_PoisonedBlade_V21341 _passive;
        public override void OnStartBattle()
        {
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPoint(1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 3, owner);
            _passive = owner.passiveDetail.PassiveList.FirstOrDefault(x => x is PassiveAbility_PoisonedBlade_V21341) as PassiveAbility_PoisonedBlade_V21341;
            if (_passive != null) _passive.BuffUsed = true;
        }
    }
}
