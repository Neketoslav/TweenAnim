using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TweenCube : MonoBehaviour
{

    [SerializeField]
    private float _duration;

    [SerializeField]
    private Transform[] _points;

    [SerializeField]
    private int _countLoops;


    private List<Vector3> _pointsPosition = new List<Vector3>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveX(3, _duration).SetEase(Ease.InBack));
        sequence.Insert(4, transform.DOScale(3, 5).SetEase(Ease.InElastic));
        sequence.Insert(2, transform.DOJump(Vector3.forward, 3, 3, 3).SetEase(Ease.InElastic));
    }
}
