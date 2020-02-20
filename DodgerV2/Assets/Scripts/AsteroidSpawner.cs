using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    /*
     * Timings.
     */
    [Header("Timings")]
    //Delay before first asteroid spawns.
    [SerializeField]
    float StartDelay = 5f;

    [SerializeField]
    float TimeBetweenSpawns = 3f;
    [SerializeField]
    float TimeVariance = 1f;

    [SerializeField]
    float NextSpawnTime = 0f;

    /*
     * Counts
     */
    [Header("Counts")]
    [SerializeField]
    int AsteroidSpawnCount = 7;
    [SerializeField]
    int AsteroidSpawnVariance = 3;

    /*
     * Spawn properties
     */
    [Header("Spawning")]
    [SerializeField]
    float ArenaWidth = 9f;

    [SerializeField]
    float MinScale = 1f;

    [SerializeField]
    float MaxScale = 1.7f;

    [SerializeField]
    float HeightVariance = 10f;

    [SerializeField]
    float MinSpawnRotation = -35f;

    [SerializeField]
    float MaxSpawnRotation = 35f;

    //A value between this value and 0 is applied to rotation to pull it closer to 0.
    [SerializeField]
    float RotationNormalizingWeight = 20f;

    void Start()
    {
        NextSpawnTime = StartDelay;    
    }

    void Update()
    {
        if(Time.time > NextSpawnTime)
        {
            SpawnAsteroids();

            //Randomize out next spawn time.
            NextSpawnTime = Time.time + (TimeBetweenSpawns + Random.Range(-TimeVariance, TimeVariance));
        }
    }
    void SpawnAsteroids()
    {
        int AsteroidsToSpawn = AsteroidSpawnCount + (UnityEngine.Random.Range(0, AsteroidSpawnVariance * 2) / 2);

        for (int i = 0; i < AsteroidsToSpawn; i++)
        {
            //Randomize position.
            Vector3 position = new Vector3(transform.position.x + Random.Range(-ArenaWidth/2,ArenaWidth/2), transform.position.y + Random.Range(-HeightVariance/2, HeightVariance/2));

            //Randomize Z-rotation.
            float ZRotation = Random.Range(MinSpawnRotation, MaxSpawnRotation);
            //Pull rotation closer to 0.
            if(ZRotation < 0)
            {
                ZRotation += Random.Range(0, Mathf.Min(RotationNormalizingWeight, Mathf.Abs(ZRotation))) ;
            } 
            else if(ZRotation > 0)
            {
                ZRotation -= Random.Range(0, Mathf.Min(RotationNormalizingWeight, Mathf.Abs(ZRotation)));
            }

            //Assemble rotation.
            Quaternion rotation = Quaternion.Euler(0,0, ZRotation);

            //Spawn asteroid object.
            GameObject Asteroid = Instantiate(AsteroidPrefab, position, rotation);

            float Scale = Random.Range(MinScale, MaxScale);

            Asteroid.transform.localScale = new Vector3(Scale, Scale, 1);
        }
    }
}
