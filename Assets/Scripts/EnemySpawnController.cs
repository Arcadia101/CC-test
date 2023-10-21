using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Range(1, 10)][SerializeField]float SpawnRate = 3;
    [SerializeField] GameObject[] EnemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3/SpawnRate);
            float random = Random.Range(0.0f,1.0f);
            print(random);
            if(random < GameManager.Instance.dificulty * 0.1f )
            {
                if (random > 0.2f)
                {
                    Instantiate(EnemyPrefab[0]);
                }
                else
                {
                    Instantiate(EnemyPrefab[1]);
                }
            }
            else
            {
                Instantiate(EnemyPrefab[2]);
            }
        }
    }
}
