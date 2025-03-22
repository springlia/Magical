using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float speed = -1.5f;

    void Start()
    {
        InvokeRepeating("MoveX", 0f, 0.01f);
    }

    void MoveX()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x < -30.8f)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = 40.6f;
            transform.position = newPosition;
        }
    }
}
