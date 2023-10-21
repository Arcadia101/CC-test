using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
     [SerializeField]int ItemSpawnRate = 3;
     [Range(1, 10)][SerializeField]float ItemSpawnRange = 3;
    [SerializeField] GameObject[] ItemPrefab;
    [SerializeField]int PowerSpawnRate = 3;
     [Range(1, 10)][SerializeField]float PowerSpawnRange = 3;
    [SerializeField] GameObject[] powerUpPrefab;
    void Start()
    {
        StartCoroutine(SpawnNewItem());
        StartCoroutine(SpawnNewPowerUp());
    }

    IEnumerator SpawnNewItem() 
    {
        while (true)
        {
            yield return new WaitForSeconds(ItemSpawnRate);
            float random = Random.Range(0.0f,1.0f);
           
            Vector2 randomPosition = Random.insideUnitCircle * ItemSpawnRange;
            if(random < GameManager.Instance.dificulty * 0.1f )
            {
                if (random > 0.2f)
                {
                    Instantiate(ItemPrefab[0],randomPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(ItemPrefab[1],randomPosition, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(ItemPrefab[2],randomPosition, Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnNewPowerUp() 
    {
        while (true)
        {
            yield return new WaitForSeconds(PowerSpawnRate);
            int randomP = Random.Range(0, powerUpPrefab.Length);
           
            Vector2 randomPosition = Random.insideUnitCircle * PowerSpawnRange;
            
            Instantiate(powerUpPrefab[randomP],randomPosition, Quaternion.identity);
            
        }
    }
}
