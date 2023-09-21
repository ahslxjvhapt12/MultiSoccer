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
    [SerializeField] private float maxHP = 100;
    private float currentHP;
    private bool onKick = false;

    [Header("-")]
    [SerializeField] private Transform origin = null;
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject footAnchor;

    private Rigidbody2D _rigid;

    private event Action EndOfKick;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    private void OnEnable()
    {
        EndOfKick += SetAnchorScale;
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetMouseButtonDown(0) && onKick == false)
            Kick();
        if (Input.GetMouseButtonDown(1))
            Dash();
    }

    private void OnDisable()
    {
        EndOfKick -= SetAnchorScale;
    }

    private void Move()
    {
        Debug.Log("Move호출");
        float h = Input.GetAxis("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(h, 0, 0) * Time.deltaTime * speed;
        if (x != 0)
        {
            visual.transform.localScale = new Vector3(-x, 1, 1);
            if (onKick == false)
                SetAnchorScale();
        }
    }

    private void Jump()
    {
        Debug.Log("Jump호출");
        if (Physics2D.Raycast(origin.position, Vector2.down, rayDinstance))
        {
            _rigid.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Kick()
    {
        Debug.Log("Kick호출");
        DG.Tweening.Sequence seq = DOTween.Sequence()
            .PrependCallback(() =>
            {
                onKick = true;
                footAnchor.SetActive(true);
            })
            .Append(footAnchor.transform.DORotate(new Vector3(0, 0, footAnchor.transform.localScale.x * -90), kickDuration))
            .AppendInterval(0.1f)
            .OnComplete(() =>
            {
                footAnchor.SetActive(false);
                footAnchor.transform.rotation = new Quaternion(0, 0, 0, 0);
                onKick = false;
                EndOfKick?.Invoke();
            });
    }

    private void SetAnchorScale()
    {
        footAnchor.transform.localScale = visual.transform.localScale;
    }

    private void Dash()
    {
        Debug.Log("Dash호출");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin.position, origin.position - new Vector3(0, rayDinstance, 0));
    }
}
