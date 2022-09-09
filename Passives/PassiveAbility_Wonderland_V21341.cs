using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Wonderland_V21341 : PassiveAbilityBase
    {
        private BattleUnitBuf_SmokeBomb_V21341 _buff;
        public BattleUnitModel Clone;
        public bool SummonUsed;

        public override void OnWaveStart()
        {
            _buff = new BattleUnitBuf_SmokeBomb_V21341();
            if (!(owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_SmokeBomb_V21341) is
                    BattleUnitBuf_SmokeBomb_V21341 buff))
                owner.bufListDetail.AddBuf(_buff);
            else _buff = buff;
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 1));
        }

        public override void OnRoundStartAfter()
        {
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 2));
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 3));
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 4));
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 11));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 11));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 2));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 3));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 4));
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeBomb_V21341>())
            {
                _buff = new BattleUnitBuf_SmokeBomb_V21341();
                owner.bufListDetail.AddBuf(_buff);
            }

            _buff.OnAddBuf(1);
            if (!SummonUsed) return;
            SummonUsed = false;
            if (Clone == null) return;
            BattleObjectManager.instance.UnregisterUnit(Clone);
            UnitUtil.RefreshCombatUI();
            Clone.Book.owner = null;
            Clone = null;
        }

        public override void OnBattleEnd()
        {
            if (Clone != null) Clone.Book.owner = null;
        }
    }
}