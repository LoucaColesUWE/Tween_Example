using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenSettings : ScriptableObject
{
    public float duration = 1;
    public Ease easeType = Ease.Linear;
    public bool relative = true;
    [Tooltip("If -1 then loop infinitely.")] public int loops = 0;
    [Tooltip("Only takes effect if loops != 0.")] public LoopType loopType = LoopType.Yoyo;
}
