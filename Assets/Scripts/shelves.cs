using UnityEngine;
using System.Collections.Generic;

public class shelves : MonoBehaviour
{
    public GameObject objectToSpawn;    
    public int numberOfObjects = 10;    
    public Vector2 spawnAreaSize = new Vector2(12, 5); 
    public float checkRadius = 0.5f;    
    public LayerMask obstacleLayer;     

    private List<Vector3> occupiedPositions = new List<Vector3>(); 

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomFreePosition();
            if (spawnPosition != Vector3.zero) 
            {
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                occupiedPositions.Add(spawnPosition);
            }
            else
            {
                Debug.LogWarning("Could not find a valid position for object " + i);
            }
        }
    }

    Vector3 GetRandomFreePosition()
    {
        int maxAttempts = 50; 
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPosition = GetRandomPositionInArea();
            if (IsPositionFree(randomPosition))
            {
                return randomPosition;
            }
        }
        return Vector3.zero; 
    }

    Vector3 GetRandomPositionInArea()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float z = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        return new Vector3(x, 0, z) + transform.position; 
    }

    bool IsPositionFree(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, checkRadius, obstacleLayer);
        if (colliders.Length > 0)
        {
            return false; 
        }

        foreach (Vector3 occupied in occupiedPositions)
        {
            if (Vector3.Distance(position, occupied) < checkRadius)
            {
                return false; // Too close to another object
            }
        }
        return true; // Position is free
    }
}
