using DG.Tweening;
using Packets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField][Range(0f, 1f)] private float kickDuration = 0.3f;
    [SerializeField][Range(0f, 1f)] private float kickIntervalTime = 0.1f;

    [Header("-")]
    [SerializeField] private GameObject footAnchor;
    private PolygonCollider2D footCol;

    public void SetPosition(PlayerPacket playerData)
    {
        Vector3 pos = transform.position;
        pos.x = playerData.x;
        pos.y = playerData.y;

        transform.position = pos;
    }

    public void Kick()
    {
        Debug.Log("KickÈ£Ãâ");
        Sequence seq = DOTween.Sequence()
            .PrependCallback(() =>
            {
                footAnchor.SetActive(true);
                footCol.enabled = true;
            })
            .Append(footAnchor.transform.DORotate(new Vector3(0, 0, footAnchor.transform.localScale.x * -90), kickDuration))
            .AppendInterval(kickIntervalTime)
            .OnComplete(() =>
            {
                footAnchor.SetActive(false);
                footCol.enabled = false;
                footAnchor.transform.rotation = new Quaternion(0, 0, 0, 0);
            });

    }
}
