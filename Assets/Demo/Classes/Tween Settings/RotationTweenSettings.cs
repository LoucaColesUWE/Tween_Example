using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Rotation Tween Settings", menuName = "ScriptableObjects/Rotation Tween Settings", order = 3)]
public class RotationTweenSettings : TweenSettings
{
    public Vector3 targetRotation;
    public RotateMode rotateMode;

    public void TweenRotation(RectTransform rectTransform)
    {
        rectTransform.DORotate(targetRotation, duration, rotateMode).SetEase(easeType).SetLoops(loops, loopType);
    }
}
