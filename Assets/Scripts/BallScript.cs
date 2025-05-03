using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    [SerializeField] float initialSpeed = 10f;
    [SerializeField] float speedIncrease = 0.25f;

    private int hitCount;
    private Rigidbody2D rb;
    private AudioSource collisionSound;
    private Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionSound = GetComponent<AudioSource>();
        Invoke(nameof(StartBall), 2);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCount));
    }

    private void StartBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x, y) * (initialSpeed + speedIncrease * hitCount);
    }

    public void ResetBall()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        hitCount = 0;
        Invoke(nameof(StartBall), 2);
    }

    private void Bounce(Transform playerObject)
    {
        hitCount++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = playerObject.position;

        float xDirection, yDirection; ;

        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPos.y - playerPos.y) / playerObject.GetComponent<Collider2D>().bounds.size.y;

        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCount));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionSound.Play();

        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce(collision.transform);
        }
    }
}