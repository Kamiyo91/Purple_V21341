using KamiyoStaticUtil.Utils;
using LOR_DiceSystem;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_MysticEyeOfTimePerception_V21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2, owner);
        }

        public override void OnRoundEnd()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 2, owner);
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Evasion ||
                owner.passiveDetail.HasPassive<PassiveAbility_Clone_V21341>())
                behavior.ApplyDiceStatBonus(
                    new DiceStatBonus
                    {
                        min = 2,
                        max = 2
                    });
        }

        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            if (attackerCard == null) return;
            var playerSpeed = attackerCard.target.currentDiceAction.speedDiceResultValue;
            var enemySpeed = attackerCard.speedDiceResultValue;
            if (playerSpeed <= enemySpeed) return;
            attackerCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                max = -1
            });
        }

        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            var battlePlayingCardDataInUnitModel = card?.target.currentDiceAction;
            var playerSpeed = card?.speedDiceResultValue;
            var targetSpeed = card?.target.currentDiceAction.speedDiceResultValue;
            if (playerSpeed <= targetSpeed) return;
            UnitUtil.SetPassiveCombatLog(this, owner);
            battlePlayingCardDataInUnitModel?.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                max = -1
            });
        }
    }
}