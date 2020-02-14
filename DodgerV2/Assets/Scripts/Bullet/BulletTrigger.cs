using UnityEngine;
using Unity.Entities;

public class BulletTrigger : MonoBehaviour
{
    //Cached enemylayer.
    static int enemyLayer = -1;

    //Our gameobjectentity.
    GameObjectEntity gameObjectEntity;

    //Cached scorekeeper.
    public GameKeeper gameKeeper;

    private void Start()
    {
        //Cache EnemyLayer if we haven't already.
        if (enemyLayer == -1)
        {
            enemyLayer = LayerMask.NameToLayer("Enemy");
        }

        gameObjectEntity = GetComponent<GameObjectEntity>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If we hit an enemy destroy it and ourselves.
        if(other.gameObject.layer == enemyLayer)
        {
            GameObjectEntity enemyObjEntity = other.GetComponent<GameObjectEntity>();
            if(enemyObjEntity != null)
            {
                enemyObjEntity.EntityManager.AddComponent<DestroyComponent>(enemyObjEntity.Entity);
                gameObjectEntity.EntityManager.AddComponent<DestroyComponent>(gameObjectEntity.Entity);

                //Add score for destroying asteroid.
                gameKeeper.scoreKeeper.AddScore(gameKeeper.scoreRewards.ScoreDestroyedAsteroid);
                gameKeeper.SpawnPopupText(other.transform.position, gameKeeper.scoreRewards.ScoreDestroyedAsteroid.ToString());
            }
        }
    }
}
