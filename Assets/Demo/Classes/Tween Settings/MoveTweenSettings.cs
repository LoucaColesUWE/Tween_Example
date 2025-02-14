using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Move Tween Settings", menuName = "ScriptableObjects/Move Tween Settings", order = 1)]
public class MoveTweenSettings : TweenSettings
{
    public Vector3 targetLocation = Vector3.zero;

    public void TweenY(RectTransform rectTransform)
    {
        rectTransform.DOAnchorPosY(targetLocation.y, duration, false)
            .SetEase(easeType).SetRelative(relative);
    }

    public void TweenY(RectTransform rectTransform, float yOverride)
    {
        rectTransform.DOAnchorPosY(yOverride, duration, false)
            .SetEase(easeType).SetRelative(relative);
    }

    public void TweenMove(RectTransform rectTransform)
    {
        rectTransform.DOAnchorPos(targetLocation, duration, false)
            .SetEase(easeType).SetRelative(relative).SetLoops(loops, loopType);
    }
}
