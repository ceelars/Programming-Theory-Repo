using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] orbs;
    [SerializeField] private Transform[] orbSpawn;
    public float spawnInterval = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (BeatDetector.beatFull || (BeatDetector.beatCountD8 % 8 == 4 && BeatDetector.beatD8))
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
