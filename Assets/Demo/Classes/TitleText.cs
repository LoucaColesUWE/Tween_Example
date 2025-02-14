using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TitleText : MonoBehaviour
{
    public TweenSettings[] tweens;

    private RectTransform rectTransform;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DemoManager.OnJuiceChanged += ToggleJuice;
    }

    void OnDestroy()
    {
        DemoManager.OnJuiceChanged -= ToggleJuice;
    }

    private void ToggleJuice(bool juiceEnabled)
    {
        if (juiceEnabled)
        {
            foreach (var tween in tweens)
            {
                if (tween is ScaleTweenSettings scaleTween)
                {
                    scaleTween.TweenScale(rectTransform);
                }
            }
        }
        else
        {
            rectTransform.DOPause();
        }
    }
}
