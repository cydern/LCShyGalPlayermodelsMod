using GameNetcodeStuff;
using ModelReplacement;
using TooManyEmotes;
using UnityEngine;
using ShyGalModelReplacement.Expression;

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
		protected FaceExpression surprisedExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression closedEyesExpression = new FaceExpression(0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 25, 0, 0, 50, 0);
		//protected FaceExpression scornExpression = new FaceExpression();
		//protected FaceExpression angryExpression = new FaceExpression();
		//protected FaceExpression hurtExpression = new FaceExpression();
		//protected FaceExpression fearExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0);

		protected Tweener tweenManager;

		protected override GameObject LoadAssetsAndReturnModel()
		{
			model_name = "Shygal";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}

		protected virtual void OnEmote(int emoteId)
		{
			if (Plugin.enableEmoteExpressions.Value)
			{
				switch (emoteId)
				{
					case 1:
					case -52: // company jig
					case -18: // blow kiss
					case -129: // hello friend!
					case -194: // mwuahaha
					case -302: // travelers
						tweenManager.CreateTweenAndRun(happyExpression, 0.1f);
						break;
					case 2:
					case -155: // it's you
						tweenManager.CreateTweenAndRun(surprisedExpression, 0.1f);
						break;
					case -3: // afk
					case -89: // facepalm
						tweenManager.CreateTweenAndRun(closedEyesExpression, 0.1f);
						break;
					case -36: // bunny hop
					case -46: // cheer
					case -170: // laugh it out
					case -133: // hooray!
					case -219: // primo moves
						tweenManager.CreateTweenAndRun(happyEyesClosedExpression, 0.1f);
						break;
					default:
						tweenManager.CreateTweenAndRun(defaultExpression, 0.1f);
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

		protected override void Awake()
		{
			base.Awake();
			tweenManager = new Tweener(replacementModel.GetComponentInChildren<SkinnedMeshRenderer>());
		}

		public override void LateUpdate()
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
			else { danceID = 0; }
			if (ModelReplacementAPI.tooManyEmotesPresent) { danceID = getEmoteIDWithTME(danceID); }
			if (previousDanceID != danceID)
			{
				OnEmote(danceID);
			}
			tweenManager.LateUpdate();
		}

		private int getEmoteIDWithTME(int emoteID)
		{
			if (EmoteControllerPlayer.allPlayerEmoteControllers.TryGetValue(controller, out var tooManyEmotesController))
			{
				if (tooManyEmotesController.IsPerformingCustomEmote())
				{
					return tooManyEmotesController.performingEmote.emoteId * -1 - 1;
				}
			}
			return emoteID;
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
				tweenManager.CreateTweenAndRun(surprisedExpression, 0.1f);
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
}