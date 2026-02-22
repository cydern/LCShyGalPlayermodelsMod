using ModelReplacement;
using UnityEngine;

namespace ShyGalModelReplacement
{
	// RED SHY GAL
    public class MRSHYGALRED : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        { 
            string model_name = "Shygal Red";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }

        protected override void OnEmoteStart(int emoteId)
        {
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(7, 50);
						break;
					case -2: // afk
					case 88: // facepalm
						mask.SetBlendShapeWeight(4, 100);
						break;
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
						mask.SetBlendShapeWeight(5, 75);
						mask.SetBlendShapeWeight(10, 65);
						break;
				}
				//print("Red Shy Gal emoted with ID: " + emoteId);
			}
        }
        protected override void OnEmoteEnd()
        {
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 0);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 25);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
			}
		}
	}

	// BLUE SHY GAL
	public class MRSHYGALBLUE : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Blue";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 226: // rat dance
					case 128: // hello friend!
					case 301: // travelers
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(7, 50);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(4, 100);
						break;
					case 1:
					case 51:
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
					case 193: // mwuahaha
						mask.SetBlendShapeWeight(5, 75);
						mask.SetBlendShapeWeight(10, 65);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 20);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 0);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 25);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
			}
		}
	}

	// BLACK SHY GAL
	public class MRSHYGALBLACK : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Black";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						mask.SetBlendShapeWeight(6, 50);
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(6, 60);
						break;
					case -2: // afk
					case 88: // facepalm
						mask.SetBlendShapeWeight(4, 100);
						mask.SetBlendShapeWeight(6, 20);
						break;
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop		
						mask.SetBlendShapeWeight(5, 90);
						mask.SetBlendShapeWeight(6, 10);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 35);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 10);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 0);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
			}
		}
	}

	// GREEN SHY GAL
	public class MRSHYGALGREEN : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Green";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 301: // travelers
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(3, 20);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(3, 20);
						mask.SetBlendShapeWeight(4, 100);
						break;
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
					case 193: // mwuahaha
						mask.SetBlendShapeWeight(3, 0);
						mask.SetBlendShapeWeight(5, 85);
						mask.SetBlendShapeWeight(10, 65);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 50);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 100);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 100);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
				deadMask.SetBlendShapeWeight(14, 65);
			}
		}
	}

	// YELLOW SHY GAL
	public class MRSHYGALYELLOW : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Yellow";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
        protected override void OnEmoteStart(int emoteId)
        {
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				if (emoteId == 2)
				{
					SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
					mask.SetBlendShapeWeight(0, 100);
				}
			}
        }
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(0, 0);
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 100);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(0, 0);
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 0);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 30);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 100);
			}
		}
	}

	// WHITE SHY GAL
	public class MRSHYGALWHITE : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal White";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(7, 50);
						mask.SetBlendShapeWeight(8, 0);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(3, 40);
						mask.SetBlendShapeWeight(4, 75);
						mask.SetBlendShapeWeight(8, 15);
						break;
					case 45:  // cheer
					case 169: // laugh it out
					case 132: // hooray!
						mask.SetBlendShapeWeight(5, 100);
						mask.SetBlendShapeWeight(8, 15);
						break;
					// Little bit more of an unsure happiness.
					case 17:  // blow kiss
					case 35: // bunny hop
						mask.SetBlendShapeWeight(5, 50);
						mask.SetBlendShapeWeight(8, 5);
						mask.SetBlendShapeWeight(10, 75);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 35);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 10);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 100);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 0);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(14, 100);
			}
		}
	}

	// PURPLE SHY GAL
	public class MRSHYGALPURPLE : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Purple";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						mask.SetBlendShapeWeight(3, 30);
						mask.SetBlendShapeWeight(10, 70);
						mask.SetBlendShapeWeight(11, 0);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(7, 50);
						mask.SetBlendShapeWeight(11, 15);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(4, 100);
						mask.SetBlendShapeWeight(11, 0);
						break;
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
						mask.SetBlendShapeWeight(5, 75);
						mask.SetBlendShapeWeight(10, 65);
						mask.SetBlendShapeWeight(11, 0);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 30);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 0);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 20);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
			}
		}
	}

	// PINK SHY GAL
	public class MRSHYGALPINK : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Pink";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 51:
					case 226: // rat dance
						mask.SetBlendShapeWeight(5, 30);
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(2, 100);
						mask.SetBlendShapeWeight(7, 20);
						mask.SetBlendShapeWeight(10, 150);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(5, 100);
						break;
					case 1:
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						// mask.SetBlendShapeWeight(0, 100);
						mask.SetBlendShapeWeight(5, 100);
						mask.SetBlendShapeWeight(10, 30);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(0, 0);
			mask.SetBlendShapeWeight(2, 0);
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 30);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(0, 0);
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 95);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 50);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 30);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(12, 30);
				deadMask.SetBlendShapeWeight(14, 30);
			}
		}
	}

	// ORANGE SHY GAL
	public class MRSHYGALORANGE : BodyReplacementBase
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Orange";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				OnEmoteEnd();
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case 51:
					case 226: // rat dance
					case 128: // hello friend!
					case 193: // mwuahaha
					case 301: // travelers
						mask.SetBlendShapeWeight(10, 100);
						break;
					case 2:
					case 154: // it's you!
						mask.SetBlendShapeWeight(7, 100);
						break;
					case -2:  // afk
					case 88:  // facepalm
						mask.SetBlendShapeWeight(4, 100);
						break;
					case 45:  // cheer
					case 17:  // blow kiss
					case 169: // laugh it out
					case 132: // hooray!
					case 35: // bunny hop
						mask.SetBlendShapeWeight(5, 75);
						mask.SetBlendShapeWeight(10, 65);
						break;
				}
			}
		}
		protected override void OnEmoteEnd()
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			mask.SetBlendShapeWeight(3, 0);
			mask.SetBlendShapeWeight(4, 0);
			mask.SetBlendShapeWeight(5, 0);
			mask.SetBlendShapeWeight(6, 0);
			mask.SetBlendShapeWeight(7, 0);
			mask.SetBlendShapeWeight(8, 0);
			mask.SetBlendShapeWeight(9, 0);
			mask.SetBlendShapeWeight(10, 0);
			mask.SetBlendShapeWeight(11, 0);
		}
		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				SkinnedMeshRenderer deadMask = replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>();
				deadMask.SetBlendShapeWeight(3, 0);
				deadMask.SetBlendShapeWeight(4, 0);
				deadMask.SetBlendShapeWeight(5, 0);
				deadMask.SetBlendShapeWeight(6, 0);
				deadMask.SetBlendShapeWeight(7, 100);
				deadMask.SetBlendShapeWeight(8, 0);
				deadMask.SetBlendShapeWeight(9, 0);
				deadMask.SetBlendShapeWeight(10, 25);
				deadMask.SetBlendShapeWeight(11, 0);

				deadMask.SetBlendShapeWeight(13, 40);
			}
		}
	}

	
}