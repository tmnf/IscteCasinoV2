using UnityEngine;

public class EntitySpawner : MonoBehaviour
{

    public int entitiesToSpawn;

    public GameObject bird;

    void Start()
    {
        for (int i = 0; i != entitiesToSpawn; i++)
            Instantiate(bird, new Vector3(Random.Range(-14f, 14f), Random.Range(1f, 1.4f), 0), Quaternion.identity);
    }
}
