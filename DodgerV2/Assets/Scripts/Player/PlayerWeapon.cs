using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    [SerializeField]
    float weaponCooldown = 0.1f;
    [SerializeField]
    float cooldownEnd = 0f;

    [Header("Bullet Spawn")]
    [SerializeField]
    float yOffset = 1f;

    [SerializeField]
    public GameObject bulletPrefab;

    GameKeeper gameKeeper;
    void Awake()
    {
        gameKeeper = GameKeeper.GetGameKeeper();
    }

    void Fire()
    {
        if(Time.time >= cooldownEnd)
        {
            //Calculate where to put the bullet.
            Vector2 SpawnPosition = transform.position + (yOffset * transform.up);
            //Use same rotation as player ship.
            Quaternion Rotation = transform.rotation;

            //Spawn bullet.
            GameObject bullet = Instantiate(bulletPrefab, SpawnPosition, Rotation);
            //Set scorekeeper to the one we have.
            bullet.GetComponent<BulletTrigger>().gameKeeper = gameKeeper;

            //Set cooldown.
            cooldownEnd = Time.time + weaponCooldown;
        }
    }
    public void FireAction(InputAction.CallbackContext context)
    {
        Fire();
    }
}
