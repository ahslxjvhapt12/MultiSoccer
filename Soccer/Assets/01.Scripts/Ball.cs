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

    [ContextMenu("Init Game")]
    public void InitGame()
    {
        transform.position = Vector3.zero;
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);

        GameObject player = GameObject.Find("Player_Blue");
        GameObject otherPlayer = GameObject.Find("OtherPlayer");

        player.transform.position = new Vector3(-5, -2, 0);
        otherPlayer.transform.position = new Vector3(5, -2, 0);
    }
}
