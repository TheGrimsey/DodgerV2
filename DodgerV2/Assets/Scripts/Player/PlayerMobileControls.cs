using UnityEngine;

public class PlayerMobileControls : MonoBehaviour
{
    public Joystick movementJoystick;

    public Joystick rotationJoystick;

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    PlayerWeapon playerWeapon;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        playerMovement = playerObject.GetComponent<PlayerMovement>();
        playerWeapon = playerObject.GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
         * Movement
         */
        //Set MovementInput based on this.
        if(movementJoystick.Direction != Vector2.zero)
        {
            playerMovement.MovementInput = movementJoystick.Direction;
        }

        /*
         * Rotation
         */
         if(rotationJoystick.Direction != Vector2.zero)
        {
            //Calculate target rotation.
            Vector3 TargetRotation = Quaternion.LookRotation(Vector3.forward, rotationJoystick.Direction).eulerAngles;

            //Set TargetZRotation
            playerMovement.TargetZRotation = TargetRotation.z;
        }
    }

    public void OnFireButtonClicked()
    {
        playerWeapon.Fire();
    }
}
