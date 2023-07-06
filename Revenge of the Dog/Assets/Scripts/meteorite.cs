using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class meteorite : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 5.0f;
    public Vector3 minSpawnPosition;
    public Vector3 maxSpawnPosition;
    public float movementSpeed = 5.0f; 
    public Vector3 minSpawnScale;
    public Vector3 maxSpawnScale;
    public boss script;

    private void Start()
    {
        StartCoroutine(SpawnPrefabAtRandomIntervals());
    }

    private IEnumerator SpawnPrefabAtRandomIntervals()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnScale = GetRandomSpawnScale();
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject spawnedPrefab = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
            spawnedPrefab.transform.localScale = new Vector3(spawnScale.x, spawnScale.x, spawnScale.z);
            MovePrefabToBottomLeft(spawnedPrefab);
        }
    }
    private void Update()
    {
        if (script.hp <= 25)
        {
            maxSpawnInterval = 1;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
        float Y = 5.0f;
        float Z = 1.0f;

        return new Vector3(randomX, Y, Z);
    }
    private Vector3 GetRandomSpawnScale()
    {
        float randomX = Random.Range(minSpawnScale.x, maxSpawnScale.x);
        float Y = randomX;
        float Z = 1.0f;

        return new Vector3(randomX, Y, Z);
    }

    private void MovePrefabToBottomLeft(GameObject prefab)
    {
        StartCoroutine(MovePrefabCoroutine(prefab));
    }

    private IEnumerator MovePrefabCoroutine(GameObject prefab)
    {
        while (prefab.transform.position.y > -5)
        {
            Vector3 targetPosition = new Vector3(prefab.transform.position.x, -10, prefab.transform.position.z);
            prefab.transform.position = Vector3.MoveTowards(prefab.transform.position, targetPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(prefab);
    }
}