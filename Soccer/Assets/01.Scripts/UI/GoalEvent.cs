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

    [ContextMenu("Goal")]
    public void Goal()
    {
        Sequence seq = DOTween.Sequence();
        seq.PrependCallback(() =>
        {
            panel.transform.position = startPos.transform.position;
        });
        seq.Append(panel.transform.DOMove(midPos.transform.position, 1f).SetEase(Ease.OutQuint));
        seq.AppendInterval(0.2f);
        seq.Append(panel.transform.DOMove(endPos.transform.position, 1f).SetEase(Ease.InQuint));
        seq.OnComplete(() =>
        {
            panel.transform.position = endPos.transform.position;
        });
    }
}
