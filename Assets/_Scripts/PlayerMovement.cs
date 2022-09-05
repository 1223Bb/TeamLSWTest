using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movespeed = 35f;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 desiredPosition;
        Vector3 vec3Ddirection = new Vector3(direction.x, direction.y, 0) * movespeed * Time.deltaTime;
        desiredPosition = this.transform.position + vec3Ddirection;
        rb.MovePosition(desiredPosition);
    }
}
