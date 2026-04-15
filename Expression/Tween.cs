using UnityEngine;

namespace ShyGalModelReplacement.Expression
{
	public class Tweener : MonoBehaviour
	{
		private SkinnedMeshRenderer mesh;
		private Tween activeTween;

		private float currentTweenTimeElapsed;
		private float currentTweenCompletion;
		private FaceExpression previousFaceExpression;

		private short[] beforeValues;
		private short[] afterValues;

		public Tweener(SkinnedMeshRenderer mesh)
		{
			this.mesh = mesh;
			beforeValues = new short[15];
			afterValues = new short[15];
		}

		public void LateUpdate()
		{
			if (currentTweenCompletion >= 1.0f) { activeTween = null; currentTweenTimeElapsed = 0; currentTweenCompletion = 0; }
			if (activeTween != null)
			{
				currentTweenTimeElapsed += Time.deltaTime;
				currentTweenCompletion = currentTweenTimeElapsed / activeTween.tweenTime;
				if (currentTweenCompletion >= 1.0f)
				{
					activeTween.exitExpression.setExpression(mesh);
				}
				else
				{
					beforeValues = previousFaceExpression.faceBlendshapes;
					afterValues = activeTween.exitExpression.faceBlendshapes;
					for (int i = 0; i < beforeValues.Length; i++)
					{
						mesh.SetBlendShapeWeight(i, (afterValues[i] - beforeValues[i]) * currentTweenCompletion + beforeValues[i]);
					}
				}
			}
		}

		public void CreateTweenAndRun(FaceExpression face, float tweenTime, int weight = 0, bool queue = false)
		{
			activeTween = new Tween(face, tweenTime);
			currentTweenTimeElapsed = 0;
			currentTweenCompletion = 0;
			FillNewPreviousFaceExpression();
		}

		private void FillNewPreviousFaceExpression()
		{
			short[] blendshapes = new short[15];
			for (int i = 0; i < blendshapes.Length; i++)
			{
				blendshapes[i] = (short)mesh.GetBlendShapeWeight(i);
			}
			previousFaceExpression = new FaceExpression(blendshapes);
		}
	}

	public class Tween
	{
		public FaceExpression exitExpression;
		public float tweenTime;

		public Tween(FaceExpression exitExpression, float tweenTime)
		{
			this.exitExpression = exitExpression;
			this.tweenTime = tweenTime;
		}
	}
}
