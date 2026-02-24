using ModelReplacement;
using UnityEngine;
using TooManyEmotes;
using GameNetcodeStuff;

namespace ShyGalModelReplacement
{
	public class MRSHYGALBASE : BodyReplacementBase
	{
		private int danceID = 0;
		private int previousDanceID = 0;

		protected string model_name;
		protected FaceExpression defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression happyExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0);
		protected FaceExpression happyEyesClosedExpression = new FaceExpression(0, 0, 0, 0, 0, 75, 0, 0, 0, 0, 65, 0, 0, 0, 0);
		protected FaceExpression surprisedExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression closedEyesExpression = new FaceExpression(0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 25, 0, 0, 50, 0);

		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}

		protected virtual void OnEmote(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
				switch (emoteId)
				{
					case 1:
					case -52: // company jig
					case -18: // blow kiss
					case -129: // hello friend!
					case -194: // mwuahaha
					case -302: // travelers
						happyExpression.setExpression(mask);
						break;
					case 2:
					case -155: // it's you
						surprisedExpression.setExpression(mask);
						break;
					case -3: // afk
					case -89: // facepalm
						closedEyesExpression.setExpression(mask);
						break;
					case -36: // bunny hop
					case -46: // cheer
					case -170: // laugh it out
					case -133: // hooray!
					case -219: // primo moves
						happyEyesClosedExpression.setExpression(mask);
						break;
					default:
						defaultExpression.setExpression(mask);
						break;
				}
			}
		}

		protected override void OnDeath()
		{
			if (Plugin.enableDeathExpressions.Value)
			{
				deadExpression.setExpression(replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>());
			}
		}

		public void LateUpdate()
		{
			base.LateUpdate();
			previousDanceID = danceID;
			
			int fullPathHash = controller.playerBodyAnimator.GetCurrentAnimatorStateInfo(1).fullPathHash;
			if (controller.performingEmote)
			{
				switch (fullPathHash)
				{
					case -462656950:
						danceID = 1;
						break;
					case 2103786480:
						danceID = 2;
						break;
					default:
						danceID = 3;
						break;
				}
			}
			else
			{
				danceID = 0;
			}

			int tooManyEmotesDanceID = 0;
			if (ModelReplacementAPI.tooManyEmotesPresent)
			{
				tooManyEmotesDanceID = getTooManyEmotesCurrentEmoteID();
			}
			switch (tooManyEmotesDanceID) 
			{
				case 0:
					break;
				default:
					danceID = tooManyEmotesDanceID;
					break;
			}
			if (previousDanceID != danceID)
			{
				OnEmote(danceID);
			}
		}

		private int getTooManyEmotesCurrentEmoteID()
		{
			if (EmoteControllerPlayer.allPlayerEmoteControllers.TryGetValue(controller, out var tooManyEmotesController))
			{
				if (tooManyEmotesController.IsPerformingCustomEmote())
				{
					return tooManyEmotesController.performingEmote.emoteId * -1 - 1;
				}
			}
			return 0;
		}

		protected override void OnHitEnemy(bool dead) { return; }
		protected override void OnHitAlly(PlayerControllerB ally, bool dead) { return; }
		protected override void OnDamageTaken(bool dead) { return; }
		protected override void OnDamageTakenByAlly(PlayerControllerB ally, bool dead) { return; }
		protected override void OnEmoteStart(int emoteId) { return; }
		protected override void OnEmoteEnd() { return; }
	}

	// RED SHY GAL
	public class MRSHYGALRED : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Red";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}

	}

	// BLUE SHY GAL
	public class MRSHYGALBLUE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Blue";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0);
			happyExpression = happyEyesClosedExpression;
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// BLACK SHY GAL
	public class MRSHYGALBLACK : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Black";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0);
			happyExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 100, 0, 0, 0, 0);
			surprisedExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0);
			deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 10, 0, 0, 0, 0, 0, 0);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		
	}

	// GREEN SHY GAL
	public class MRSHYGALGREEN : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Green";
			defaultExpression = new FaceExpression(0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			happyExpression = new FaceExpression(0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0);
			surprisedExpression = new FaceExpression(0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 25, 0, 0, 0, 0, 25, 0);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}	 

	// YELLOW SHY GAL
	public class MRSHYGALYELLOW : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Yellow";
			deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 50, 30);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// WHITE SHY GAL
	public class MRSHYGALWHITE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal White";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0);
			happyExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 100, 0, 0, 0, 0);
			deadExpression = new FaceExpression(0, 0, 0, 0, 20, 0, 0, 100, 65, 0, 0, 0, 0, 50, 0);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// PURPLE SHY GAL
	public class MRSHYGALPURPLE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Purple";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0);
			happyExpression = new FaceExpression(0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// PINK SHY GAL
	public class MRSHYGALPINK : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Pink";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0);
			happyExpression = new FaceExpression(100, 0, 0, 0, 0, 75, 0, 0, 0, 0, 65, 0, 0, 0, 0);
			surprisedExpression = new FaceExpression(0, 0, 100, 0, 0, 0, 0, 20, 0, 0, 100, 0, 0, 0, 0);
			deadExpression = new FaceExpression(0, 0, 0, 0, 95, 0, 0, 100, 50, 0, 30, 0, 30, 0, 30);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}

		protected override void OnEmote(int emoteId)
		{
			base.OnEmote(emoteId);
			if (emoteId == -18) // blow kiss
			{
				surprisedExpression.setExpression(replacementModel.GetComponentInChildren<SkinnedMeshRenderer>());
			}
		}
	}

	// ORANGE SHY GAL
	public class MRSHYGALORANGE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal Orange";
			happyExpression = happyEyesClosedExpression;
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	public class FaceExpression
	{
		private short[] faceBlendshapes;

		public FaceExpression(short blush, short tribal, short heartEyes, short eyesHalfClosed, short eyesClosed, short eyesClosedHappy, short eyesAngry, short eyesSurprised, short eyesSad, short eyesConfused, short eyesHappy, short eyesSmug, short a, short o, short ch) 
		{ 
			faceBlendshapes = new short[] { blush, tribal, heartEyes, eyesHalfClosed, 
											eyesClosed, eyesClosedHappy, eyesAngry, eyesSurprised, 
											eyesSad, eyesConfused, eyesHappy, eyesSmug, 
											a, o, ch };
		}

		public void setExpression(SkinnedMeshRenderer mask)
		{
			for (int i = 0; i < faceBlendshapes.Length; i++)
			{
				mask.SetBlendShapeWeight(i, faceBlendshapes[i]);
			}
		}
	}

}