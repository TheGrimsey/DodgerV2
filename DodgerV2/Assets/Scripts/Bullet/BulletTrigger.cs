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

    //Our spriterenderer;
    SpriteRenderer spriteRenderer;

    //Cached gameKeeper.
    public GameKeeper gameKeeper;

    private void Awake()
    {
        //Cache EnemyLayer if we haven't already.
        if (enemyLayer == -1)
        {
            enemyLayer = LayerMask.NameToLayer("Enemy");
        }

        //Get our GameObjectEntity.
        gameObjectEntity = GetComponent<GameObjectEntity>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if we hit an enemy and if we are visible. We don't want to be able to shoot out of the scene.
        if(other.gameObject.layer == enemyLayer && spriteRenderer.isVisible)
        {
            int ScoreReward = (int)(gameKeeper.scoreRewards.ScoreDestroyedAsteroid / other.gameObject.transform.localScale.x);

            //Add score for destroying asteroid.
            gameKeeper.scoreKeeper.AddScore(ScoreReward);

            //Pick position right between us and them.
            Vector3 textPosition = gameObject.transform.position - (gameObject.transform.position - other.gameObject.transform.position) / 2;

            //Spawn score popup text where the enemy was.
            gameKeeper.SpawnPopupText(textPosition, ScoreReward.ToString(), Color.green);

            //Destroy enemy.
            Destroy(other.gameObject);

            //Destroy self.
            Destroy(this.gameObject);
        }
    }
}
