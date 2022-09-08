using KamiyoStaticUtil.Utils;

namespace Purple_V21341
{
    public class PassiveAbility_LoneFixer_V21341 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (UnitUtil.SupportCharCheck(owner) == 1)
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3);
        }
    }
}