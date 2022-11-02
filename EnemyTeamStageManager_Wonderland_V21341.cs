using System.Collections.Generic;
using BigDLL4221.Models;
using BigDLL4221.StageManagers;
using Purple_V21341.BLL;

namespace Purple_V21341
{
    public class EnemyTeamStageManager_Wonderland_V21341 : EnemyTeamStageManager_BaseWithCMU_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(new NpcMechUtilModels().PurplePoisonNpcUtil,
                new List<MapModel> { MapModels.PurplePoisonMap });
            base.OnWaveStart();
        }
    }
}