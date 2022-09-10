using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using MonoMod.Utils;
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
            PurpleModParameters.Path =
                Path.GetDirectoryName(
                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(PurpleModParameters.Path);
            ModParameters.LocalizePackageIdAndPath.Add(PurpleModParameters.PackageId, PurpleModParameters.Path);
            ModParameters.SpritePreviewChange.AddRange(new Dictionary<string, List<LorId>>
            {
                {
                    "WonderlandDefault_V21341",
                    new List<LorId>
                    {
                        new LorId(PurpleModParameters.PackageId, 10000001),
                        new LorId(PurpleModParameters.PackageId, 10000002)
                    }
                }
            });
            ModParameters.UntransferablePassives.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 5), new LorId(PurpleModParameters.PackageId, 4)
            });
            ModParameters.PersonalCardList.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 1), new LorId(PurpleModParameters.PackageId, 2),
                new LorId(PurpleModParameters.PackageId, 3), new LorId(PurpleModParameters.PackageId, 4),
                new LorId(PurpleModParameters.PackageId, 11)
            });
            ModParameters.EgoPersonalCardList.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 12)
            });
            ModParameters.DynamicNames.AddRange(new Dictionary<LorId, LorId>
            {
                { new LorId(PurpleModParameters.PackageId, 10000001), new LorId(PurpleModParameters.PackageId, 1) },
                { new LorId(PurpleModParameters.PackageId, 10000002), new LorId(PurpleModParameters.PackageId, 2) }
            });
            ModParameters.DefaultKeyword.Add(PurpleModParameters.PackageId, "WonderlandModPage_V21341");
            ModParameters.SupportCharPassive.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 4)
            });
            ModParameters.BannedEmotionSelectionUnit.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 10000002)
            });
            ModParameters.NoEgoFloorUnit.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 10000002)
            });
            ModParameters.BooksIds.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 10000001)
            });
            ModParameters.BookList.AddRange(new List<LorId>
            {
                new LorId(PurpleModParameters.PackageId, 2)
            });
        }
    }
}