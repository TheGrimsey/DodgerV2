using UnityEngine;
using Unity.Entities;

/*
 * Handles bullet logic for colliding with enemies.
 */
public class BulletTrigger : MonoBehaviour
{
    //Cached enemylayer.
    static int enemyLayer = -1;

    //Our gameobjectentity.
    GameObjectEntity gameObjectEntity;

    //Cached gameKeeper.
    public GameKeeper gameKeeper;

    private void Start()
    {
        //Cache EnemyLayer if we haven't already.
        if (enemyLayer == -1)
        {
            enemyLayer = LayerMask.NameToLayer("Enemy");
        }

        //Get our GameObjectEntity.
        gameObjectEntity = GetComponent<GameObjectEntity>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if we hit an enemy.
        if(other.gameObject.layer == enemyLayer)
        {
            //Add score for destroying asteroid.
            gameKeeper.scoreKeeper.AddScore(gameKeeper.scoreRewards.ScoreDestroyedAsteroid);
            //Spawn score popup text where the enemy was.
            gameKeeper.SpawnPopupText(other.transform.position, gameKeeper.scoreRewards.ScoreDestroyedAsteroid.ToString(), Color.green);

            //Destroy enemy and self.
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
