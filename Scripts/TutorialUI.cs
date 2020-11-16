using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    Player player;
    [SerializeField] Text spaceTutorial;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        SpaceBarTutorial();
    }
    void SpaceBarTutorial()
    {
        if (player.WaitToStart)
        {
            spaceTutorial.gameObject.SetActive(true);
        }
        else
        {
            spaceTutorial.gameObject.SetActive(false);
        }
    }
}
