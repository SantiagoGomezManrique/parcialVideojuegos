using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatforms : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 speed;
    private float jumpImpulse = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = collision.collider.GetComponent<Rigidbody2D>();

        if(collision.relativeVelocity.y <= 0f)
        {
            if (rb.tag == "Player")
            {
                BoostJump();
            }
        }

    }

    private void BoostJump()
    {
        speed = rb.velocity;
        speed.y = jumpImpulse;
        rb.velocity = speed;
    }
}
