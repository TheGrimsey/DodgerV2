using UnityEngine;

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
        }
    }
}
