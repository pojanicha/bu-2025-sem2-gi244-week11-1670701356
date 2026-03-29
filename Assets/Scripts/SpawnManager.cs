using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public Wave[] wave;


    void Start()
    {
        StartCoroutine(WaveRoutine());
        //StartCoroutine(SpwanRoutine());
        //InvokeRepeating(nameof(RandomSpawn), 0, 5f);
    }

    void RandomSpawn(int numberOfPoints)
    {
        var index = Random.Range(0, numberOfPoints);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    /*IEnumerator SpwanRoutine()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }


    }*/


    IEnumerator WaveRoutine()
    { 
        for (int w = 0; w < wave.Length; w++)
        {
            Wave waves = wave[w];
            
            yield return new WaitForSeconds(waves.delayStart);

            for (int i = 0; i < waves.totalSpawnEneies; i++)
            {
                RandomSpawn(waves.numberOfRandomSpawnPoint);
                yield return new WaitForSeconds(waves.spawnInterval);


            }


        }



    }






}




