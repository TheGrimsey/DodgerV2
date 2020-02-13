using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    [SerializeField]
    float WeaponCooldown = 0.1f;
    [SerializeField]
    float CooldownEnd = 0f;

    [Header("Bullet Spawn")]
    [SerializeField]
    float YOffset = 1f;

    [SerializeField]
    public GameObject BulletPrefab;

    void Fire()
    {
        if(Time.time >= CooldownEnd)
        {
            Vector2 SpawnPosition = transform.position + (YOffset * transform.up);
            Quaternion Rotation = transform.rotation;

            Instantiate(BulletPrefab, SpawnPosition, Rotation);

            CooldownEnd = Time.time + WeaponCooldown;
        }
    }
    public void FireAction(InputAction.CallbackContext context)
    {
        Fire();
    }
}
