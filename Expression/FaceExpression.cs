using UnityEngine;

namespace ShyGalModelReplacement.Expression
{
	public class FaceExpression
	{
		public short[] faceBlendshapes { get; private set; }

		public FaceExpression(short blush, short tribal, short heartEyes, short eyesHalfClosed, short eyesClosed, short eyesClosedHappy, short eyesAngry, short eyesSurprised, short eyesSad, short eyesConfused, short eyesHappy, short eyesSmug, short a, short o, short ch)
		{
			faceBlendshapes = new short[] { blush, tribal, heartEyes, eyesHalfClosed,
											eyesClosed, eyesClosedHappy, eyesAngry, eyesSurprised,
											eyesSad, eyesConfused, eyesHappy, eyesSmug,
											a, o, ch };
		}

		public FaceExpression(short[] blendshapes)
		{
			faceBlendshapes = blendshapes;
		}

		public void setExpression(SkinnedMeshRenderer mask, float tweenTime = 0)
		{
			for (int i = 0; i < faceBlendshapes.Length; i++)
			{
				mask.SetBlendShapeWeight(i, faceBlendshapes[i]);
			}
		}

	}
}
