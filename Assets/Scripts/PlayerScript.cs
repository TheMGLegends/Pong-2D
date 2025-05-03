using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] string playerName = null;

    private Rigidbody2D rb;
    private RigidbodyConstraints2D originalConstraits;
    private float movementY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalConstraits = rb.constraints;
    }

    private void Update()
    {
        if (playerName == "LeftPlayer")
        {
            movementY = Input.GetAxisRaw("LeftPlayerVertical") * movementSpeed;
        }

        if (playerName == "RightPlayer")
        {
            movementY = Input.GetAxisRaw("RightPlayerVertical") * movementSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0f , movementY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            rb.constraints = originalConstraits;
        }
    }
}