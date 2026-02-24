using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;

namespace ShyGalModelReplacement
{
    [BepInPlugin("com.cydern.shygalplayermodels", "Shy Gal Playermodels", "0.1.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;

        public static ConfigEntry<bool> enableEmoteExpressions { get; private set; }
		public static ConfigEntry<bool> enableDeathExpressions { get; private set; }

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

			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Red", typeof(MRSHYGALRED));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Blue", typeof(MRSHYGALBLUE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Black", typeof(MRSHYGALBLACK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Green", typeof(MRSHYGALGREEN));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Yellow", typeof(MRSHYGALYELLOW));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal White", typeof(MRSHYGALWHITE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Purple", typeof(MRSHYGALPURPLE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Pink", typeof(MRSHYGALPINK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Orange", typeof(MRSHYGALORANGE));
            
			Harmony harmony = new Harmony("com.cydern.shygalplayermodels");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"com.cydern.shygalplayermodels"} is loaded!");
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