using UnityEngine;

namespace ShyGalModelReplacement
{
	public class FaceExpression
	{
		public int[] faceBlendshapes { get; private set; }

		public FaceExpression(int blush, int tribal, int heartEyes, int eyesHalfClosed, int eyesClosed, int eyesClosedHappy, int eyesAngry, int eyesSurprised, int eyesSad, int eyesConfused, int eyesHappy, int eyesSmug, int a, int o, int ch)
		{
			faceBlendshapes = new int[] { blush, tribal, heartEyes, eyesHalfClosed,
											eyesClosed, eyesClosedHappy, eyesAngry, eyesSurprised,
											eyesSad, eyesConfused, eyesHappy, eyesSmug,
											a, o, ch };
		}

		public FaceExpression(int[] blendshapes)
		{
			faceBlendshapes = blendshapes;
		}

		public void setExpression(SkinnedMeshRenderer mask)
		{
			for (int i = 0; i < faceBlendshapes.Length; i++)
			{
				mask.SetBlendShapeWeight(i, faceBlendshapes[i]);
			}
		}

		public static FaceExpression GetZeroedExpression() 
		{
			return new FaceExpression(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		public FaceExpression Multiply(float multiplier) 
		{ 
			if (multiplier == 1 ) { return this; }
			if (multiplier <= 0) { return GetZeroedExpression(); }
			int[] newFaceExpression = new int[faceBlendshapes.Length];
			for (int i = 0; i < newFaceExpression.Length; i++) 
			{
				newFaceExpression[i] = (int)(faceBlendshapes[i] * multiplier);
			}
			return new FaceExpression(newFaceExpression);
		}

	}
}
