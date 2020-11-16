using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int randomRotation;
    private void Awake()
    {
        transform.Rotate(0, 0, Random.Range(-randomRotation, randomRotation), Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ObstacleDestroyer")
        {
            Destroy(gameObject);
        }
    }

}
