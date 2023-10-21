using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int dificulty = 1;
    [SerializeField]int score;
    public int Score
    {
        get => score;
        set 
        {
            score = value;
            if (score % 1000 == 0)
            {
                dificulty++;
            }
        }
    }
    private void Start()
    {
        StartCoroutine(CountdownRoutine());    
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    IEnumerator CountdownRoutine()
    {
        while (time > 0)
        {
        yield return new WaitForSeconds(1);
        time --;
        }
        //GameOver
    }
}
