using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField][Range(1f, 15f)] private float speed = 5f;
    [SerializeField][Range(0f, 1f)] private float rayDinstance = 1f;
    [SerializeField][Range(1f, 10f)] private float jumpPower = 10f;

    [Header("-")]
    [SerializeField] private Transform origin = null;
    [SerializeField] private GameObject visual;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        Kick();
        Dash();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(h, 0, 0) * Time.deltaTime * speed;
        if (x != 0)
            visual.transform.localScale = new Vector3(-x, 1, 1);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(origin.position, Vector2.down, rayDinstance))
            {
                _rigid.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }
    private void Kick()
    {

    }
    private void Dash()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin.position, origin.position - new Vector3(0, rayDinstance, 0));
    }
}
