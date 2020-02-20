using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    //How long the weapon will remain on cooldown for.
    [SerializeField]
    float weaponCooldown = 0.1f;

    //Time when the current cooldown will end.
    float cooldownEnd = 0f;

    [Header("Bullet Spawn")]
    //How far infront of the player the bullet will spawn.
    [SerializeField]
    float yOffset = 1f;

    //Bullet Prefab.
    [SerializeField]
    public GameObject bulletPrefab;

    GameKeeper gameKeeper;
    void Start()
    {
        gameKeeper = GameKeeper.GetGameKeeper();
    }

    //Spawns a bullet infront of the player if their weapon isn't on cooldown.
    void Fire()
    {
        if(gameKeeper.GameTime >= cooldownEnd)
        {
            Debug.Log("Spawning bullet");

            //Calculate where to put the bullet.
            Vector2 SpawnPosition = transform.position + (yOffset * transform.up);
            //Use same rotation as player ship.
            Quaternion Rotation = transform.rotation;

            //Spawn bullet.
            GameObject bullet = Instantiate(bulletPrefab, SpawnPosition, Rotation);
            //Set scorekeeper to the one we have.
            bullet.GetComponent<BulletTrigger>().gameKeeper = gameKeeper;

            //Set cooldown.
            cooldownEnd = gameKeeper.GameTime + weaponCooldown;
        }
    }

    //Called when Player presses fire button.
    public void FireAction(InputAction.CallbackContext context)
    {
        Fire();
    }
}
