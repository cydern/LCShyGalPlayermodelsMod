using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShyGalModelReplacement
{
	public class Expressions : MonoBehaviour
	{
		private SkinnedMeshRenderer MaskMesh;

		private ExpressionLayer baseExpression = new ExpressionLayer();
		private List<ExpressionLayer> uninteruptableLayers = new List<ExpressionLayer>();

		public Expressions(FaceExpression baseExpression, SkinnedMeshRenderer maskMesh) 
		{ 
			this.MaskMesh = maskMesh;
			this.baseExpression.currentExpression = baseExpression;
			this.baseExpression.previousExpression = baseExpression;
		}

		public void SetBaseExpression(FaceExpression expression, float tweenTime = 0.1f)
		{
			SetExpressionLayer(baseExpression, expression, tweenTime);
		}

		private void SetExpressionLayer(ExpressionLayer layer, FaceExpression expression, float tweenTime) 
		{
			layer.previousExpression = GetProcessedFaceExpression(layer, false);
			layer.currentExpression = expression;
			layer.tweenTime = tweenTime;
			layer.timer = 0;
		}

		public void Update()
		{
			FaceExpression processedBase = GetProcessedFaceExpression(baseExpression, true);

			processedBase.setExpression(MaskMesh);
		}

		private FaceExpression GetProcessedFaceExpression(ExpressionLayer layer, bool addDeltaTime = false)
		{
			if (layer.currentExpression == layer.previousExpression) { return layer.currentExpression; }
			if (addDeltaTime) { layer.timer += Time.deltaTime; }
			float transitionBlend = layer.timer / layer.tweenTime;
			if (transitionBlend >= 1) 
			{
				layer.previousExpression = layer.currentExpression;
				return layer.currentExpression;
			}
			int[] processedExpression = new int[15];
			int[] beforeExpression = layer.previousExpression.faceBlendshapes;
			int[] afterExpression = layer.currentExpression.faceBlendshapes;
			for (int i = 0; i < 15; i++)
			{
				processedExpression[i] = (int)((afterExpression[i] - beforeExpression[i]) * transitionBlend + beforeExpression[i]);
			}
			return new FaceExpression(processedExpression);
		}

		private FaceExpression CombineAdditiveBlendshapes(FaceExpression baseline, FaceExpression additive) 
		{ 
			int[] newFaceBlends = new int[15];
			int[] baseBlends = baseline.faceBlendshapes;
			int[] additiveBlends = additive.faceBlendshapes;
			for (int i = 0; i < baseBlends.Length; i++)
			{
				newFaceBlends[i] = Math.Clamp(baseBlends[i] + additiveBlends[i], 0, 100);
			}
			return new FaceExpression(newFaceBlends);
		}

		class ExpressionLayer 
		{
			public FaceExpression currentExpression;
			public FaceExpression previousExpression;
			public float tweenTime = 0;
			public float timer = 0;
		}
	}
}
