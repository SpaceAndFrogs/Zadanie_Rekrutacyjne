using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool isMovingInX;
    [SerializeField]
    private float moveMagnitude;
    [SerializeField]
    private bool toMinusX;
    [SerializeField]
    private bool toMinusZ;
    private Vector2 startXZ;
    private void Start()
    {
        startXZ = new Vector2(transform.position.x, transform.position.z);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(isMovingInX) 
        {
            if(toMinusX) 
            {
                transform.position += Vector3.left * moveSpeed;
                if(transform.position.x <= startXZ.x - moveMagnitude) 
                {
                    toMinusX = false;
                }
            }else
            {
                transform.position += Vector3.right * moveSpeed;
                if (transform.position.x >= startXZ.x + moveMagnitude)
                {
                    toMinusX = true;
                }
            }
        }
        else
        {
            if (toMinusZ)
            {
                transform.position += Vector3.back * moveSpeed;
                if (transform.position.z <= startXZ.y - moveMagnitude)
                {
                    toMinusZ = false;
                }
            }
            else
            {
                transform.position += Vector3.forward * moveSpeed;
                if (transform.position.z >= startXZ.y + moveMagnitude)
                {
                    toMinusZ = true;
                }
            }
        }
    }
}
