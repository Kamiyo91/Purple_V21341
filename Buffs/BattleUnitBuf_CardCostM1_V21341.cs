namespace Purple_V21341.Buffs
{
    public class BattleUnitBuf_CardCostM1_V21341 : BattleUnitBuf
    {
        public override void OnRoundEndTheLast()
        {
            _owner.bufListDetail.RemoveBuf(this);
        }

        public override int GetCardCostAdder(BattleDiceCardModel card)
        {
            return -1;
        }
    }
}
