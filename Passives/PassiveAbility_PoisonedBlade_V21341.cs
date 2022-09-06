using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_PoisonedBlade_V21341 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            var target = behavior.card.target;
            if (target == null) return;
            if (RandomUtil.Range(0, 100) <= 25)
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 1, owner);
            if (RandomUtil.Range(0, 100) > 10) return;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_PurplePoison_V21341) is
                BattleUnitBuf_PurplePoison_V21341 buff) buff.OnAddBuf(1);
            else target.bufListDetail.AddBuf(new BattleUnitBuf_PurplePoison_V21341());
        }
    }
}
