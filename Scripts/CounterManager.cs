using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    [SerializeField] Text textCounter = null;
    int counter;
    private void Awake()
    {
        counter = 0;
        textCounter.text = getCountertoString;
    }
    private void OnEnable()
    {
        CounterEventManager.PassFromObstacle += CountUp;
    }
    private void OnDisable()
    {
        CounterEventManager.PassFromObstacle -= CountUp;
    }
    public string getCountertoString => "Score: " + counter.ToString();
    void CountUp()
    {
        counter++;
        textCounter.text = getCountertoString;
    }

    public int GetCounter => counter;
    public int SetCounter(int score) => counter = score;
    public string SetCounterUI => textCounter.text = getCountertoString;
}
