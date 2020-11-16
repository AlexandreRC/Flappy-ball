using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterEventManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public delegate void OnPass();
    public static event OnPass PassFromObstacle;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (PassFromObstacle != null && other.tag == "Player")
        {
            PassFromObstacle();
            Destroy(gameObject);
        }
    }   

}
