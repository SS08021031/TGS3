using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public List<EnemyWave> waveSpawn;

    private float spawnCounter;
    public float waitFirstSpawn;

    public Transform spawnPoint;    //エネミーが発生する場所

    public Crystal_Test TheCrystal;
    public Path ThePath;

    public bool isSpawn = true;
    public float waveDisplayTime;


    public GameObject parentObject;
    void Start()
    {
        spawnCounter = waitFirstSpawn;

    }


    void Update()
    {

        if (isSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                if (waveSpawn[0].shouldDisplayWave)
                {
                    waveSpawn[0].shouldDisplayWave = false;



                }

                if (waveSpawn.Count > 0)
                {
                    if (waveSpawn[0].enemySpawnOrder.Count > 0)
                    {
                        var child = Instantiate(waveSpawn[0].enemySpawnOrder[0], spawnPoint.position, spawnPoint.rotation);
                        child.transform.parent = parentObject.transform;


                        spawnCounter = waveSpawn[0].timeBetweenSpawn;
                        waveSpawn[0].enemySpawnOrder.RemoveAt(0);
                        if (waveSpawn[0].enemySpawnOrder.Count == 0)
                        {
                            spawnCounter = waveSpawn[0].timeNextWave;

                            waveSpawn.RemoveAt(0);


                            if (waveSpawn.Count == 0)
                            {
                                isSpawn = false;
                            }
                        }
                    }
                }
            }
        }
    }
}


[System.Serializable]
public class EnemyWave
{
    public List<GameObject> enemySpawnOrder = new List<GameObject>(0);

    public float timeBetweenSpawn;
    public float timeNextWave;
    [HideInInspector]
    public bool shouldDisplayWave = true;
}