using System.Linq;
using KamiyoStaticUtil.Utils;
using LOR_DiceSystem;
using Purple_V21341.BLL;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Time_Recession_V21341 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
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
    }
}