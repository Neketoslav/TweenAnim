using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CustomButton : Button
{
    public static string ChangeButtonType => nameof(_animationButtonType);
    public static string Duration => nameof(_duration);

    [SerializeField]
    private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;

    [SerializeField]
    private float _duration = 0.5f;

    private float _strenght = 30.0f;

    private RectTransform _rectTransform;

    protected override void Awake()
    {
        base.Awake();

        _rectTransform = GetComponent<RectTransform>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        ActivateAnimation();
    }

    private void ActivateAnimation()
    {
        switch (_animationButtonType)
        {
            case AnimationButtonType.ChangePosition:
                _rectTransform.DOShakeAnchorPos(_duration, _strenght);
                break;
            case AnimationButtonType.ChangeRotation:
                _rectTransform.DOShakeRotation(_duration, _strenght);
                break;
        }
    }
}
