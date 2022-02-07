using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] orbs;
    [SerializeField] private Transform[] orbSpawn;

    void Update()
    {
        if (BeatDetector.beatFull)
        {
            SpawnOrb();
        }
    }
    void SpawnOrb()
    {
        int orbIndex = Random.Range(0, orbs.Length);

        if (GameManager.isGameActive)
        {
            Instantiate(orbs[orbIndex], orbSpawn[orbIndex].position, orbs[orbIndex].transform.rotation);
        }
    }
}
