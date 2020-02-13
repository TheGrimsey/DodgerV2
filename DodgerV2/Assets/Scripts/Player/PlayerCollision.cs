using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerCollision : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    int enemyLayer = -1;
    void Start()
    {
        scoreKeeper = ScoreKeeper.GetScoreKeeper();
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if we collided with an enemy.
        if (collision.gameObject.layer == enemyLayer)
        {
            scoreKeeper.EndRound();

            //TODO Go to end menu.
        }
    }
}
