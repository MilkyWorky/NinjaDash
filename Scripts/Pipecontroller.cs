using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipecontroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
