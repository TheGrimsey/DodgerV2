using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            Vector3 position = new Vector3((i - 50) * 1.1f, 0);

            Instantiate(AsteroidPrefab, position, Quaternion.identity);
        }
    }
}
