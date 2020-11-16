using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]Rigidbody2D ThRB;
    [SerializeField] float jumpForce;
    bool isAlive;
    bool waitToStart;
    [SerializeField] Transform spawnPoint;
    [SerializeField] CounterManager _counterManager;
    Obstacle[] _obstacle;
    [SerializeField] float moveSpeed;
    private void OnEnable()
    {
        isAlive = true;
        waitToStart = true;
    }
    private void Update()
    {
        Jump();
        Move();
        if (!waitToStart)
        {
            ThRB.gravityScale = 2;
        }
        else
        {
            ThRB.velocity = Vector3.zero;
            ThRB.gravityScale = 0;
        }
        
    }

    private void Move()
    {
        if(isAlive)
        {
            ThRB.velocity = new Vector2(moveSpeed, ThRB.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            ThRB.velocity = new Vector2(moveSpeed, jumpForce);
            waitToStart = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Die();
        }
    }

    private void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            StartCoroutine(ResetTimer());
        }
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(1);
        Obstacle[] allObstacle = FindObjectsOfType(typeof(Obstacle)) as Obstacle[];
        foreach (Obstacle obstacle in allObstacle)
        {
            Destroy(obstacle.gameObject);
        }
        _counterManager.SetCounter(0);
        string setCounterUI = _counterManager.SetCounterUI;
        transform.position = spawnPoint.position;
        ThRB.freezeRotation = true;
        ThRB.SetRotation(0);
        waitToStart = true;
        isAlive = true;
        ThRB.freezeRotation = false;
    }
    public bool WaitToStart => waitToStart;
}
