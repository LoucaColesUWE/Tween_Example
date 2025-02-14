using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Scale Tween Settings", menuName = "ScriptableObjects/Scale Tween Settings", order = 4)]
public class ScaleTweenSettings : TweenSettings
{
    public bool uniformScale;
    public Vector3 targetScale;
    public float uniformTargetScale;

    public void TweenScale(RectTransform rectTransform)
    {
        Vector3 scale = uniformScale ? new Vector3(uniformTargetScale, uniformTargetScale, uniformTargetScale) : targetScale;
        rectTransform.DOScale(scale, duration).SetEase(easeType).SetLoops(loops, loopType);
    }
}
