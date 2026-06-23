using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;
using BepInEx.Logging;

namespace ShyGalModelReplacement
{
    [BepInPlugin("com.cydern.shygalplayermodels", "ShyGal Playermodels", "1.2.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
	[BepInDependency("x753-More_Suits", BepInDependency.DependencyFlags.SoftDependency)]
	public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;
        public static ConfigEntry<bool> enableEmoteExpressions { get; private set; }
		public static ConfigEntry<bool> enableDeathExpressions { get; private set; }

        internal static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("ShyGal Playermodels");

		private static void InitConfig()
        {
			enableEmoteExpressions = config.Bind<bool>("Expressions (Client-Sided)", "Enable Expressions on Emote", true, "When enabled, ShyGals will change expressions when emoting.");
			enableDeathExpressions = config.Bind<bool>("Expressions (Client-Sided)", "Enable Expressions on Death", true, "When enabled, ShyGals will change expressions on death");
		}
        private void Awake()
        {
            config = base.Config;
            InitConfig();
            Assets.PopulateAssets();

			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Red", typeof(SHYGALRED));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Blue", typeof(SHYGALBLUE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Black", typeof(SHYGALBLACK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Green", typeof(SHYGALGREEN));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Yellow", typeof(SHYGALYELLOW));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal White", typeof(SHYGALWHITE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Purple", typeof(SHYGALPURPLE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Pink", typeof(SHYGALPINK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Orange", typeof(SHYGALORANGE));

			logger.LogInfo($"Plugin {"ShyGal Playermodels"} is loaded!");
        }

    }
    public static class Assets
    {
        public static string mainAssetBundleName = "ShyGalPlayermodels";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name.Replace(" ","_");
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}