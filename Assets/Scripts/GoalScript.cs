using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField] GameObject scoreCounter;
    private AudioSource goalSound;

    private void Start()
    {
        goalSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            goalSound.Play();
            scoreCounter.GetComponent<ScoreScript>().IncrementScore();
            collision.gameObject.GetComponent<BallScript>().ResetBall();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(transform.localScale.x, transform.localScale.y));
    }
}