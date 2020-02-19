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
            gameKeeper.SpawnPopupText(other.transform.position, gameKeeper.scoreRewards.ScoreDestroyedAsteroid.ToString());

            //Get the GameObjectEntity of the other object.
            GameObjectEntity enemyObjEntity = other.GetComponent<GameObjectEntity>();
            if(enemyObjEntity != null)
            {

                //Mark both object for destroy using DestroyComponent.
                enemyObjEntity.EntityManager.AddComponent<DestroyComponent>(enemyObjEntity.Entity);
                gameObjectEntity.EntityManager.AddComponent<DestroyComponent>(gameObjectEntity.Entity);
            }
            else
            {
                //If there isn't a gameobject entity let's just destroy it anyway.
                Destroy(other.gameObject);
            }
        }
    }
}
