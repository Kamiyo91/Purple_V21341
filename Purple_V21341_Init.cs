using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using Purple_V21341.BLL;

namespace Purple_V21341
{
    public class Purple_V21341_Init : ModInitializer
    {
        public override void OnInitializeMod()
        {
            InitParameters();
            MapStaticUtil.GetArtWorks(new DirectoryInfo(PurpleModParameters.Path + "/ArtWork"));
            UnitUtil.ChangeCardItem(ItemXmlDataList.instance, PurpleModParameters.PackageId);
            UnitUtil.ChangePassiveItem(PurpleModParameters.PackageId);
            SkinUtil.LoadBookSkinsExtra(PurpleModParameters.PackageId);
            LocalizeUtil.AddLocalLocalize(PurpleModParameters.Path, PurpleModParameters.PackageId);
            SkinUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
            UnitUtil.InitKeywords(Assembly.GetExecutingAssembly());
            UnitUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
        }

        public void InitParameters()
        {
            ModParameters.PackageIds.Add(PurpleModParameters.PackageId);
            PurpleModParameters.Path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(PurpleModParameters.Path);
            ModParameters.LocalizePackageIdAndPath.Add(PurpleModParameters.PackageId, PurpleModParameters.Path);
        }
    }
}
