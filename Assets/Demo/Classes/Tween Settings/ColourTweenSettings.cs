using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

[CreateAssetMenu(fileName = "Colour Tween Settings", menuName = "ScriptableObjects/Colour Tween Settings", order = 2)]
public class ColourTweenSettings : TweenSettings
{
    public Color targetColour;

    public void TweenColour(TextMeshProUGUI text)
    {
        text.DOColor(targetColour, duration)
            .SetLoops(loops, loopType);
    }
}
