using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalEvent : MonoBehaviour
{
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject midPos;
    [SerializeField] GameObject endPos;

    [SerializeField] GameObject panel;

    public void Goal()
    {
        Sequence seq = DOTween.Sequence();
        seq.PrependCallback(() =>
        {
            panel.transform.position = startPos.transform.position;
        });
        seq.Append(panel.transform.DOMove(midPos.transform.position, 0.3f).SetEase(Ease.OutQuint));
        seq.AppendInterval(0.1f);
        seq.Append(panel.transform.DOMove(endPos.transform.position, 0.2f).SetEase(Ease.InQuint));
        seq.OnComplete(() =>
        {
            panel.transform.position = endPos.transform.position;
        });
    }
}
