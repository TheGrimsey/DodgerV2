using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    GameKeeper gameKeeper;

    public GameObject AsteroidPrefab;

    /*
     * Timings.
     */
    [Header("Timings")]
    //Delay before first asteroid spawns.
    [SerializeField]
    float StartDelay = 5f;

    //Time between each Asteroid spawn.
    [SerializeField]
    float TimeBetweenSpawns = 4f;
    //Variance in time between spawns.
    [SerializeField]
    float TimeVariance = 1f;

    //Minimum time between spawns.
    [SerializeField]
    float MinTime = .5f;

    //Next time we will spawn asteroids.
    [SerializeField]
    float NextSpawnTime = 0f;

    /*
     * Counts
     */
    [Header("Counts")]
    //Amount of asteroids to spawn.
    [SerializeField]
    int AsteroidSpawnCount = 7;
    //Variance in amount of asteroids to spawn.
    [SerializeField]
    int AsteroidSpawnVariance = 3;

    /*
     * Spawn properties
     */
    [Header("Spawning")]
    [SerializeField]
    float ArenaWidth = 9f;

    //Minimum scale of spawned asteroids.
    [SerializeField]
    float MinScale = 1f;

    //Maximum scale of spawned asteroids.
    [SerializeField]
    float MaxScale = 1.7f;

    //Variance in height from the spawner that asteroids will spawn.
    [SerializeField]
    float HeightVariance = 5f;

    //Minimum Z rotation of asteroids
    [SerializeField]
    float MinSpawnRotation = -45f;

    //Maximum Z rotation of asteroids
    [SerializeField]
    float MaxSpawnRotation = 45f;

    //A value between this value and 0 is applied to rotation to pull it closer to 0.
    [SerializeField]
    float RotationNormalizingWeight = 30f;

    void Start()
    {
        gameKeeper = GameKeeper.GetGameKeeper();

        NextSpawnTime = StartDelay;    
    }

    void Update()
    {
        if(gameKeeper.GameTime > NextSpawnTime)
        {
            SpawnAsteroids();

            //Randomize out next spawn time.
            NextSpawnTime = CalculateNextSpawnTime();
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

            //Scale asteroids
            float Scale = Random.Range(MinScale, MaxScale);
            Asteroid.transform.localScale = new Vector3(Scale, Scale, 1);
        }
    }

    float CalculateNextSpawnTime()
    {
        // TimeBetweenSpawns - 0.01x^1.25. With 4 seconds this gives the player ~120.7 seconds before there is a spawn every tick. But with a MinTime of 1 it ends up being about 95 seconds.
        float AdjustedTimeBetweenSpawns = TimeBetweenSpawns - (0.01f * Mathf.Pow(gameKeeper.GameTime, 1.25f));
        Debug.Log(AdjustedTimeBetweenSpawns);

        return gameKeeper.GameTime + Mathf.Max(MinTime, AdjustedTimeBetweenSpawns + Random.Range(-TimeVariance, TimeVariance));
    }
}
