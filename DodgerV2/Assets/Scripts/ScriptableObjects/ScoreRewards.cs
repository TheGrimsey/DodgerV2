using UnityEngine;

[CreateAssetMenu]
public class ScoreRewards : ScriptableObject
{
    //Score gained for destroying an Asteroid
    [SerializeField]
    int scoreDestroyedAsteroid = 10;
    public int ScoreDestroyedAsteroid => scoreDestroyedAsteroid;

    //Score gained for near misses.
    [SerializeField]
    int scoreDodgedAsteroid = 20;
    public int ScoreDodgedAsteroid => scoreDodgedAsteroid;

}
