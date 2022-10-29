using BigDLL4221.Utils;
using UnityEngine;

namespace Purple_V21341
{
    public class Wonderland_V21341MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs => new[] { "PurplePoison_V21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}