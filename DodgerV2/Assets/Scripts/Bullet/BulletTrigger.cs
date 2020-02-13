using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    static int EnemyLayer = -1;

    private void Start()
    {
        //Cache EnemyLayer if we haven't already.
        if (EnemyLayer == -1)
        {
            EnemyLayer = LayerMask.NameToLayer("Enemy");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGER!");
        if(other.gameObject.layer == EnemyLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
