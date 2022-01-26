using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HomeButton : Button
{
    [SerializeField]
    private float _duration;

    [SerializeField]
    private float _strenght;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        PlayAnimation();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ActivateAnimation();
    }

    private void ActivateAnimation()
    {
        _rectTransform.DOShakeRotation(_duration, _strenght);
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence().SetLoops(-1);
        sequence.Insert(0, transform.DOScale(2, 3).SetEase(Ease.InElastic));
        sequence.Insert(3, transform.DOScale(1, 3).SetEase(Ease.InElastic));
    }

}
