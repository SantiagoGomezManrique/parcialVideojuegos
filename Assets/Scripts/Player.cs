using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed = 10f;
    private float movement = 0f;
    private Vector2 speed;
    [Header("Lives")]
    [SerializeField] public int currentLives = 3;
    [SerializeField] public int currentPoints = 0;
    private float maxWidth;

    // Start is called before the first frame update
    void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        maxWidth = Camera.main.aspect * Camera.main.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        CameraPosition();
    }

    private void FixedUpdate()
    {
        MoveSideways();
    }

    private void MoveSideways()
    {
        speed = rb.velocity;
        speed.x = movement;
        rb.velocity = speed;
    }

    private void CameraPosition()
    {
        if (transform.position.x < -maxWidth)
        {
            transform.position = new Vector2(maxWidth, transform.position.y);
        }

        if (transform.position.x > maxWidth)
        {
            transform.position = new Vector2(-maxWidth, transform.position.y);
        }
    }
}
