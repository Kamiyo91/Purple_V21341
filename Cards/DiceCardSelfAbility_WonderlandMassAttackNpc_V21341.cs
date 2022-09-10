using System.Linq;
using Purple_V21341.Buffs;
using Purple_V21341.Dice;

namespace Purple_V21341.Cards
{
    public class DiceCardSelfAbility_WonderlandMassAttackNpc_V21341 : DiceCardSelfAbilityBase
    {
        private bool _motionChanged;
        public override void OnUseCard()
        {
            var buff = owner.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_SmokeBomb_V21341) as BattleUnitBuf_SmokeBomb_V21341;
            if (buff != null && buff.stack > 9)
                card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_Inflict2PurplePoison_V21341());
            else card.ApplyDiceAbility(DiceMatch.AllDice, new DiceCardAbility_Inflict1PurplePoison_V21341());
            buff?.OnAddBuf(-10);
        }

        public override void OnEndAreaAttack()
        {
            if (!_motionChanged) return;
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }

        public override void OnApplyCard()
        {
            if (!string.IsNullOrEmpty(owner.UnitData.unitData.workshopSkin) ||
                owner.UnitData.unitData.bookItem != owner.UnitData.unitData.CustomBookItem) return;
            _motionChanged = true;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Hit);
        }

        public override void OnReleaseCard()
        {
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }
    }
}