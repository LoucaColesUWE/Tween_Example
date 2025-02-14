using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[CreateAssetMenu(fileName = "Fade Tween Settings", menuName = "ScriptableObjects/Fade Tween Settings", order = 5)]
public class FadeTweenSettings : TweenSettings
{
    public float targetFade;

    public void TweenFade(Image image)
    {
        image.DOFade(targetFade, duration).SetEase(easeType).SetLoops(loops, loopType);
    }
}
