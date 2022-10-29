using System.Linq;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;
using Purple_V21341.Dice;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Time_Recession_V21341 : PassiveAbilityBase
    {
        private BattleUnitBuf _buff;
        private bool _counterReload;

        public override void OnStartBattle()
        {
            _buff = owner.bufListDetail.GetActivatedBufList().FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341);
            UnitUtil.ReadyCounterCard(owner, 10, PurpleModParameters.PackageId);
            var aliveList = BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction));
            if (!aliveList.Any()) return;
            var target = RandomUtil.SelectOne(aliveList);
            var cards = owner.allyCardDetail.GetAllDeck().Where(x =>
                x.XmlData.Spec.Ranged != CardRange.FarArea && x.XmlData.Spec.Ranged != CardRange.FarAreaEach &&
                x.XmlData.Spec.Ranged != CardRange.Special && x.GetOriginCost() < 4).ToList();
            if (!cards.Any()) return;
            var cardInfo = RandomUtil.SelectOne(cards);
            var card = new BattlePlayingCardDataInUnitModel
            {
                owner = owner,
                card = cardInfo,
                target = target
            };
            Singleton<StageController>.Instance.AddAllCardListInBattle(card, target);
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            if (_buff == null || _buff.stack < 10) _counterReload = false;
            else _counterReload = behavior.abilityList.Exists(x => x is DiceCardAbility_WonderlandEvasion_V21341);
        }

        public override void OnDrawParrying(BattleDiceBehavior behavior)
        {
            if (_buff == null || _buff.stack < 10) _counterReload = false;
            else _counterReload = behavior.abilityList.Exists(x => x is DiceCardAbility_WonderlandEvasion_V21341);
        }

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (_buff == null || _buff.stack < 10) _counterReload = false;
            else _counterReload = behavior.abilityList.Exists(x => x is DiceCardAbility_WonderlandEvasion_V21341);
        }

        public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
        {
            if (!_counterReload) return;
            _counterReload = false;
            UnitUtil.SetPassiveCombatLog(this, owner);
            UnitUtil.ReadyCounterCard(owner, 10, PurpleModParameters.PackageId);
        }
    }
}