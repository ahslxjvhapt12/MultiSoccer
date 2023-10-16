using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] private float power = 10;
    [SerializeField] GameObject visual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball b))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(GetDir() * power, ForceMode2D.Impulse);
        }
    }

    private Vector3 GetDir() => new Vector2(-visual.transform.localScale.x * 1.5f, 2).normalized;
}
