using UnityEngine;

/*
 * Handles player collision with enemies.
 */
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerCollision : MonoBehaviour
{
    GameKeeper gameKeeper;

    int enemyLayer = -1;

    void Start()
    {
        gameKeeper = GameKeeper.GetGameKeeper();

        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    //When a trigger enters our CircleCollider.
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Check if we collided with an enemy.
        if (collider.gameObject.layer == enemyLayer)
        {
            //Notify gameKeeper we got hit.
            gameKeeper.OnPlayerHit();

            //Spawn popup text notifying we got hit.
            {
                //Pick position right between us and them.
                Vector3 textPosition = gameObject.transform.position - (gameObject.transform.position - collider.gameObject.transform.position) / 2;

                gameKeeper.SpawnPopupText(textPosition, "HIT", Color.red);
            }

            Destroy(collider.gameObject);
        }
    }
}
