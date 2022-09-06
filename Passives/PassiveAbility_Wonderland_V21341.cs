using Purple_V21341.BLL;
using Purple_V21341.Buffs;

namespace Purple_V21341.Passives
{
    public class PassiveAbility_Wonderland_V21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            if(!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeBomb_V21341>())owner.bufListDetail.AddBuf(new BattleUnitBuf_SmokeBomb_V21341());
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 1));
        }

        public override void OnRoundStartAfter()
        {
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId,1));
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 1));
            owner.personalEgoDetail.RemoveCard(new LorId(PurpleModParameters.PackageId, 1));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 1));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 1));
            owner.personalEgoDetail.AddCard(new LorId(PurpleModParameters.PackageId, 1));
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_SmokeBomb_V21341>()) owner.bufListDetail.AddBuf(new BattleUnitBuf_SmokeBomb_V21341());
        }
    }
}
