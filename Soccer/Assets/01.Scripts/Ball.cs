using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    [ContextMenu("Init Ball")]
    public void InitializePosition()
    {
        transform.position = Vector3.zero;
        _rigid.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
    }
}
