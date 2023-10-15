using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField][Range(1f, 15f)] private float speed = 5f;
    [SerializeField][Range(0f, 1f)] private float rayDinstance = 1f;
    [SerializeField][Range(1f, 10f)] private float jumpPower = 10f;
    [SerializeField][Range(0f, 1f)] private float kickDuration = 0.3f;
    [SerializeField][Range(0f, 1f)] private float kickIntervalTime = 0.1f;
    private bool onKick = false;

    [Header("-")]
    [SerializeField] private Transform origin = null;
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject footAnchor;
    private PolygonCollider2D footCol;

    private Rigidbody2D _rigid;


    [Header("Networks")]
    [SerializeField] float syncDelay = 0.05f;
    [SerializeField] float syncDistanceErr = 0.1f;
    private float lastSyncTime = 0f;
    private Vector3 lastSyncPosition = Vector3.zero;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        footCol = footAnchor.transform.GetChild(0).GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetMouseButtonDown(0) && onKick == false)
            Kick();
    }

    private void Move()
    {
        Debug.Log("Moveȣ��");
        float h = Input.GetAxis("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(h, 0, 0) * Time.deltaTime * speed;
    }

    private void Jump()
    {
        Debug.Log("Jumpȣ��");
        if (Physics2D.Raycast(origin.position, Vector2.down, rayDinstance))
        {
            _rigid.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Kick()
    {
        Debug.Log("Kickȣ��");
        DG.Tweening.Sequence seq = DOTween.Sequence()
            .PrependCallback(() =>
            {
                onKick = true;
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
                onKick = false;
            });
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin.position, origin.position - new Vector3(0, rayDinstance, 0));
    }

}
