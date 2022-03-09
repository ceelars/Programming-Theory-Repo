using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] orbs;
    [SerializeField] private Transform[] orbSpawn;
    public static List<GameObject> activeOrbs;
    private int bankSize = 10;

    private void Start()
    {
        CreateOrbBank();
    }
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
    void CreateOrbBank()
    {
        activeOrbs = new List<GameObject>();

        for (int i = 0; i < bankSize; i++)
        {
            GameObject orbInstance = null;
            activeOrbs.Add(orbInstance);
        }
    }

    void CreateNewOrbInstance(GameObject orb)
    {
        activeOrbs.Add(orb);
    }
    public void ReassignEmptyOrbSlots(GameObject orb)
    {
        for (int i = 0; i < activeOrbs.Count; i++)
        {
            if (activeOrbs[i] == null)
            {
                activeOrbs[i] = orb;
                return;
            }
        }
        CreateNewOrbInstance(orb);
    }
    public static void DestroyAllOrbs()
    {
        for (int i = 0; i < activeOrbs.Count; i++)
        {
            if (activeOrbs[i] == null)
            {
                Destroy(activeOrbs[i]);
                return;
            }
        }
    }
}
