namespace Purple_V21341
{
    public static class UnitUtilExpansion
    {
        public static void ChangeLoneFixerPassive(Faction unitFaction, LorId passiveId)
        {
            foreach (var unit in BattleObjectManager.instance.GetAliveList(unitFaction))
            {
                if (!(unit.passiveDetail.PassiveList.Find(x => !x.destroyed && x is PassiveAbility_230008) is
                        PassiveAbility_230008
                        passiveLone)) continue;
                unit.passiveDetail.DestroyPassive(passiveLone);
                unit.passiveDetail.AddPassive(passiveId);
                unit.passiveDetail.OnCreated();
            }
        }
    }
}