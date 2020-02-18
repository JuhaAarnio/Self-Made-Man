using System.Collections;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bottlePrefab;
    [SerializeField]
    private Transform spawnerPos;
    [SerializeField]
    GameObject rockPrefab;

    Vector3 spawnLocation;

    public float value;
    public Vector2 size;
    public Material color;

    private void Start()
    {
        StartSpawning();
    }

    void SpawnSmallBottle()
    {
        spawnLocation = new Vector3(spawnerPos.position.x + Random.Range(-10, 10),
                                    spawnerPos.position.y, spawnerPos.position.z);

        GameObject bottle = Instantiate(bottlePrefab, spawnLocation, Quaternion.Euler(0, 0, 0));
        bottle.GetComponent<Bottles>().bottleValue = 0.10f;
        bottle.transform.localScale = new Vector2(0.5f, 0.5f);
    }
    void SpawnNormalBottle()
    {
        spawnLocation = new Vector3(spawnerPos.position.x + Random.Range(-10, 10), 
                                    spawnerPos.position.y, spawnerPos.position.z);
        
        GameObject bottle = Instantiate(bottlePrefab, spawnLocation, Quaternion.Euler(0, 0, 0));
        bottle.GetComponent<Bottles>().bottleValue = 0.20f;
        bottle.transform.localScale = new Vector2(0.7f, 0.7f);
    }
    void SpawnRareBottle()
    {
        spawnLocation = new Vector3(spawnerPos.position.x + Random.Range(-10, 10),
                                    spawnerPos.position.y, spawnerPos.position.z);

        GameObject bottle = Instantiate(bottlePrefab, spawnLocation, Quaternion.Euler(0, 0, 0));
        bottle.GetComponent<Bottles>().bottleValue = 0.4f;
        bottle.transform.localScale = new Vector2(1f, 1f);
    }
    void SpawnRocks()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnLocation = new Vector3(spawnerPos.position.x + Random.Range(-10, 10),
                                    spawnerPos.position.y, spawnerPos.position.z);

            GameObject bottle = Instantiate(rockPrefab, spawnLocation, Quaternion.Euler(0, 0, 0)); 
        }
    }

    IEnumerator SpawningFunc()
    {
        while (true)
        {
            SpawnRocks();
            int roll = Random.Range(0, 100);
            if (roll < 30)
            {
                SpawnSmallBottle();
                yield return new WaitForSecondsRealtime(2);
            }
            if (roll < 80 && roll >= 30)
            {
                SpawnNormalBottle();
                yield return new WaitForSecondsRealtime(2);
            }
            else
            {
                SpawnRareBottle();
                yield return new WaitForSecondsRealtime(2);
            } 
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawningFunc());
    }
    void StopSpawning()
    {
        StopCoroutine(SpawningFunc());
    }
}
