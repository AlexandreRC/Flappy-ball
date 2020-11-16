using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] float secondsToWait;
    [SerializeField] GameObject[] obstacle;

    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(GeneratorTimer());
    }

    IEnumerator GeneratorTimer()
    {
        yield return new WaitForSeconds(secondsToWait);
        GenerateRandomPosition(PickRandomObstacle());
        StartCoroutine(GeneratorTimer());
    }

    GameObject PickRandomObstacle()
    {
        var randomObstacle = Random.Range(0, obstacle.Length);
        return obstacle[randomObstacle];
    }

    private void GenerateRandomPosition(GameObject typeOfObstacle)
    {
        if (!player.WaitToStart)
        {
            var randomHeight = Random.Range(-2.5f, 2.5f);
            GameObject obstacle = Instantiate(typeOfObstacle.gameObject);
            obstacle.transform.position = new Vector3(transform.position.x, randomHeight, transform.position.z);
        }
    }

}
