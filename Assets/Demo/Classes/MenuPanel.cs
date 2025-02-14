using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MenuPanel : MonoBehaviour
{
    private bool juiceEnabled = false;
    private bool isExtended = false;
    private RectTransform rectTransform;
    private float retractedY;
    private float extendedY;

    public bool IsExtended
    {
        get => isExtended;
    }

    [Header("Elements")] public TextMeshProUGUI buttonText;
    public MenuPanel[] parentPanels;
    public MenuPanel[] childPanels;

    [Header("Boring Tweening")] public MoveTweenSettings boringButtonSelect;
    public MoveTweenSettings boringButtonDeselect;
    public ColourTweenSettings boringButtonTextHover;
    public ColourTweenSettings boringButtonTextUnhoverColor;
    public MoveTweenSettings boringButtonClick;

    [Header("Juiced Tweening")] public MoveTweenSettings juiceButtonSelect;
    public MoveTweenSettings juiceButtonDeselect;
    public ColourTweenSettings juiceButtonTextHover;
    public ColourTweenSettings juiceButtonTextUnhoverColor;
    public MoveTweenSettings juiceButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        retractedY = rectTransform.anchoredPosition.y;
        extendedY = retractedY + boringButtonClick.targetLocation.y;
        DemoManager.OnJuiceChanged += ToggleJuice;
        DemoManager.OnCancelPressed += RetractPanel;
    }

    private void OnDestroy()
    {
        DemoManager.OnJuiceChanged -= ToggleJuice;
        DemoManager.OnCancelPressed -= RetractPanel;
    }

    private void ToggleJuice(bool _juiceEnabled)
    {
        juiceEnabled = _juiceEnabled;
    }

    public void OnButtonSelected()
    {
        if (juiceEnabled)
        {
            juiceButtonSelect.TweenY(rectTransform);
            
        }
        else
        {
            boringButtonSelect.TweenY(rectTransform);
        }
    }

    public void OnButtonDeselected()
    {
        if (juiceEnabled)
        {
            juiceButtonDeselect.TweenY(rectTransform);
        }
        else
        {
            boringButtonDeselect.TweenY(rectTransform);
        }
    }

    public void OnButtonHovered()
    {
        if (juiceEnabled)
        {
            juiceButtonTextHover.TweenColour(buttonText);
        }
        else
        {
            boringButtonTextHover.TweenColour(buttonText);
        }
    }

    public void OnButtonUnhovered()
    {
        if (juiceEnabled)
        {
            juiceButtonTextUnhoverColor.TweenColour(buttonText);
        }
        else
        {
            boringButtonTextUnhoverColor.TweenColour(buttonText);
        }
    }

    public void OnButtonClicked()
    {
        ExpandPanel();

        foreach (var parent in parentPanels)
        {
            parent.ExpandPanel();
        }

        foreach (var child in childPanels)
        {
            child.RetractPanel();
        }
    }

    public void ExpandPanel()
    {
        if (!isExtended)
        {
            if (juiceEnabled)
            {
                juiceButtonClick.TweenY(rectTransform, extendedY);
            }
            else
            { 
                boringButtonClick.TweenY(rectTransform, extendedY);
            }

            isExtended = true;
        }
    }

    public void RetractPanel()
    {
        if (isExtended)
        {
            if (juiceEnabled)
            {
                juiceButtonClick.TweenY(rectTransform, retractedY);
            }
            else
            {
                boringButtonClick.TweenY(rectTransform, retractedY);
            }

            isExtended = false;
        }
    }
}
