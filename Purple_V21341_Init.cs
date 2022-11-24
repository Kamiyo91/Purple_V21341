using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using Purple_V21341.BLL;
using UnityEngine;

namespace Purple_V21341
{
    public class Purple_V21341_Init : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(PurpleModParameters.Path + "/ArtWork"));
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, PurpleModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(PurpleModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(PurpleModParameters.PackageId);
            ArtUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(PurpleModParameters.PackageId);
            PurpleModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(PurpleModParameters.PackageId, PurpleModParameters.Path);
            ModParameters.DefaultKeyword.Add(PurpleModParameters.PackageId, "WonderlandModPage_V21341");
            OnInitSprites();
            OnInitKeypages();
            OnInitCards();
            OnInitStageOptions();
            OnInitPassives();
            OnInitDropBook();
            OnInitRewards();
            OnInitCredenza();
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(PurpleModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "WonderlandDefault_V21341"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "WonderlandDefault_V21341")
            });
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(new Dictionary<LorId, int>
            {
                { new LorId(PurpleModParameters.PackageId, 2), 0 }
            }));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(PurpleModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(1, CardOption.Personal),
                new CardOptions(2, CardOption.Personal),
                new CardOptions(3, CardOption.Personal),
                new CardOptions(4, CardOption.Personal),
                new CardOptions(11, CardOption.Personal),
                new CardOptions(12, CardOption.EgoPersonal),
                new CardOptions(9,
                    cardColorOptions: new CardColorOptions(new Color(0.69f, 0.4f, 1f),
                        customIconColor: new Color(0.69f, 0.4f, 1f),
                        useHSVFilter: false))
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(PurpleModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(4, false, bannedEgoFloorCards: true,
                    bannedEmotionCardSelection: true),
                new PassiveOptions(5, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.69f, 0.4f, 1f),
                        new Color(0.69f, 0.4f, 1f))),
                new PassiveOptions(1, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.69f, 0.4f, 1f),
                        new Color(0.69f, 0.4f, 1f)))
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(PurpleModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.69f, 0.4f, 1f),
                        new Color(0.69f, 0.4f, 1f))),
                new KeypageOptions(1, bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.69f, 0.4f, 1f),
                        new Color(0.69f, 0.4f, 1f))),
                new KeypageOptions(10000002, bookCustomOptions: new BookCustomOptions(nameTextId: 2))
            });
        }

        private static void OnInitStageOptions()
        {
            ModParameters.StageOptions.Add(PurpleModParameters.PackageId, new List<StageOptions>
            {
                new StageOptions(1,
                    stageColorOptions: new StageColorOptions(new Color(0.69f, 0.4f, 1f), new Color(0.69f, 0.4f, 1f)))
            });
        }

        private static void OnInitDropBook()
        {
            ModParameters.DropBookOptions.Add(PurpleModParameters.PackageId, new List<DropBookOptions>
            {
                new DropBookOptions(1, new DropBookColorOptions(new Color(0.69f, 0.4f, 1f), new Color(0.69f, 0.4f, 1f)))
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(PurpleModParameters.PackageId, new CredenzaOptions(
                CredenzaEnum.ModifiedCredenza, new List<int> { 10000001 },
                "PurplePoisonV21341.Mod", "", "PurplePoisonV21341.Mod",
                bookDataColor: new CredenzaColorOptions(new Color(0.69f, 0.4f, 1f), new Color(0.69f, 0.4f, 1f))));
        }
    }
}