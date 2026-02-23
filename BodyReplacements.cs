using ModelReplacement;
using UnityEngine;

namespace ShyGalModelReplacement
{
	public class MRSHYGALBASE : BodyReplacementBase
	{
		protected FaceExpression defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		protected FaceExpression happyExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0);
		protected FaceExpression happyEyesClosedExpression = new FaceExpression(0, 0, 0, 0, 0, 75, 0, 0, 0, 0, 65, 0, 0, 0, 0);
		// protected FaceExpression unsureHappyExpression = new FaceExpression(0, 0, 0, 0, 0, 50, 0, 0, 5, 0, 75, 0, 0, 0, 0);
		protected FaceExpression surprisedExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0);
		// protected FaceExpression closedEyesExpression = new FaceExpression(0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		// protected FaceExpression sadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0);

		protected FaceExpression deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 25, 0, 0, 50, 0);

		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
		protected override void OnEmoteStart(int emoteId)
		{
			SkinnedMeshRenderer mask = replacementModel.GetComponentInChildren<SkinnedMeshRenderer>();
			switch (emoteId)
			{
			case 1:
				happyExpression.setExpression(mask);
				break;
			case 2:
				surprisedExpression.setExpression(mask);
				break;
			default:
				defaultExpression.setExpression(mask);
				break;
			}
		}
		protected override void OnEmoteEnd()
		{
			defaultExpression.setExpression(replacementModel.GetComponentInChildren<SkinnedMeshRenderer>());
		}
		protected override void OnDeath()
		{
			deadExpression.setExpression(replacementDeadBody.GetComponentInChildren<SkinnedMeshRenderer>());
		}

	}

	// RED SHY GAL
	public class MRSHYGALRED : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Red";
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}

	}

	// BLUE SHY GAL
	public class MRSHYGALBLUE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Blue";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0);
			happyExpression = new FaceExpression(0, 0, 0, 0, 0, 75, 0, 0, 0, 0, 65, 0, 0, 0, 0);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// BLACK SHY GAL
	public class MRSHYGALBLACK : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Black";
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
			string model_name = "Shygal Green";
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
			string model_name = "Shygal Yellow";
			deadExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 50, 30);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// WHITE SHY GAL
	public class MRSHYGALWHITE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal White";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0);
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
			string model_name = "Shygal Purple";
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
			string model_name = "Shygal Pink";
			defaultExpression = new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0);
			happyExpression = new FaceExpression(100, 0, 0, 0, 0, 75, 0, 0, 0, 0, 65, 0, 0, 0, 0);
			surprisedExpression = new FaceExpression(0, 0, 100, 0, 0, 0, 0, 20, 0, 0, 100, 0, 0, 0, 0);
			deadExpression = new FaceExpression(0, 0, 0, 0, 95, 0, 0, 100, 50, 0, 30, 0, 30, 0, 30);
			return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
		}
	}

	// ORANGE SHY GAL
	public class MRSHYGALORANGE : MRSHYGALBASE
	{
		protected override GameObject LoadAssetsAndReturnModel()
		{
			string model_name = "Shygal Orange";
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