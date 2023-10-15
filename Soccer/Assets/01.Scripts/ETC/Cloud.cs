using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
        if (transform.transform.position.x > 10)
        {
            transform.position -= new Vector3(20, 0, 0);
        }
    }
}
