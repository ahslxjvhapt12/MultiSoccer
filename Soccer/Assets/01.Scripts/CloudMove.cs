using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    List<Cloud> cloud = new List<Cloud>();
    [SerializeField]
    [Range(0f, 10f)]
    private float max;

    private void Awake()
    {
        cloud = GetComponentsInChildren<Cloud>().ToList();
        cloud.ForEach(c => c.speed = Random.Range(0.3f, max));
    }

}
