using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackgroundCloud : MonoBehaviour
{
    public TweenSettings[] tweens;

    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
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
                if (tween is RotationTweenSettings rotationTween)
                {
                    rotationTween.TweenRotation(rectTransform);
                }

                if (tween is ScaleTweenSettings scaleTween)
                {
                    scaleTween.TweenScale(rectTransform);
                }

                if (tween is FadeTweenSettings fadeTween)
                {
                    fadeTween.TweenFade(image);
                }

                if (tween is MoveTweenSettings moveTween)
                {
                    moveTween.TweenMove(rectTransform);
                }
            }
        }
        else
        {
            image.DOPause();
            rectTransform.DOPause();
        }
    }
}
