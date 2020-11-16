using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float offset;
    Player player;
    private void Awake()
    {
       
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        offset = transform.position.x + 5.191f;
    }
    private void LateUpdate()
    {
       
        transform.position = new Vector3(offset + player.transform.position.x, transform.position.y, transform.position.z);
    }
}
