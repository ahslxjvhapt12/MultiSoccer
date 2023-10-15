using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] private float power = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball b))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(GetRandomDir() * power, ForceMode2D.Impulse);
        }
    }

    private Vector3 GetRandomDir() => ((Vector2.zero - Random.insideUnitCircle) + Vector2.up).normalized;
}
