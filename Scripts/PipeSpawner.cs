using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float maxtime = 1.5f;
    //[SerializeField]
    //private GameObject pipeTotal;
    [SerializeField]
    private GameObject spawnLocation;
    [SerializeField]
    private GameObject top;
    [SerializeField]
    private GameObject bottom;

    private int dice;
    private float timer;

    private void Start()
    {
        SpawningPipe();
    }

    private void Update()
    {
        if(timer > maxtime)
        {
            SpawningPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawningPipe()
    {
        dice = Random.Range(0, 2);
        Debug.Log(dice);
        if (dice == 0)
        {
            GameObject topas = Instantiate(top);

            Destroy(topas, 10f);
        }
        else
        {
            GameObject bottomas = Instantiate(bottom);
            Destroy(bottomas, 10f);
        }
    }
}
