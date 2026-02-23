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

        // Example Config for single model mod
        public static ConfigEntry<bool> enableModelForAllSuits { get; private set; }
        public static ConfigEntry<bool> enableModelAsDefault { get; private set; }
        public static ConfigEntry<string> suitNamesToEnableModel { get; private set; }

        public static ConfigEntry<bool> enableEmoteExpressions { get; private set; }
		public static ConfigEntry<bool> enableDeathExpressions { get; private set; }

		private static void InitConfig()
        {
			// enableModelForAllSuits = config.Bind<bool>("Suits to Replace Settings", "Enable Model for all Suits", false, "Enable to model replace every suit. Set to false to specify suits");
			// enableModelAsDefault = config.Bind<bool>("Suits to Replace Settings", "Enable Model as default", false, "Enable to model replace every suit that hasn't been otherwise registered.");
			// suitNamesToEnableModel = config.Bind<string>("Suits to Replace Settings", "Suits to enable Model for", "Default,Orange suit", "Enter a comma separated list of suit names.(Additionally, [Green suit,Pajama suit,Hazard suit])");
			enableEmoteExpressions = config.Bind<bool>("Expressions (Client-Sided)", "Enable Expressions on Emote", true, "When enabled, ShyGals will change expressions when emoting. Expressions can get stuck if TooManyEmotes is installed!");
			enableDeathExpressions = config.Bind<bool>("Expressions (Client-Sided)", "Enable Expressions on Death", true, "When enabled, ShyGals will change expressions on death");

		}
        private void Awake()
        {
            config = base.Config;
            InitConfig();
            Assets.PopulateAssets();

            /*
            // Plugin startup logic
            if (enableModelForAllSuits.Value)
        {
                ModelReplacementAPI.RegisterModelReplacementOverride(typeof(MRSHYGALRED));

            }
            if (enableModelAsDefault.Value)
            {
                ModelReplacementAPI.RegisterModelReplacementDefault(typeof(MRSHYGALRED));

            }
            var commaSepList = suitNamesToEnableModel.Value.Split(',');
            foreach (var item in commaSepList)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement(item, typeof(MRSHYGALRED));
            }
            */

			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Red", typeof(MRSHYGALRED));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Blue", typeof(MRSHYGALBLUE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Black", typeof(MRSHYGALBLACK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Green", typeof(MRSHYGALGREEN));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Yellow", typeof(MRSHYGALYELLOW));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal White", typeof(MRSHYGALWHITE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Purple", typeof(MRSHYGALPURPLE));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Pink", typeof(MRSHYGALPINK));
			ModelReplacementAPI.RegisterSuitModelReplacement("Shygal Orange", typeof(MRSHYGALORANGE));
            // ModelReplacementAPI has forced my hand
            
			Harmony harmony = new Harmony("com.cydern.shygalplayermodels");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"com.cydern.shygalplayermodels"} is loaded!");
        }
    }
    public static class Assets
    {
        // Replace mbundle with the Asset Bundle Name from your unity project 
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