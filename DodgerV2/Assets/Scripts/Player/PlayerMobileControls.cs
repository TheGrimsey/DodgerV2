using UnityEngine;

public class PlayerMobileControls : MonoBehaviour
{
    public Joystick movementJoystick;

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    PlayerWeapon playerWeapon;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        playerMovement = playerObject.GetComponent<PlayerMovement>();
        playerWeapon = playerObject.GetComponent<PlayerWeapon>();

        playerMovement.OnTouchEnabledListeners += OnTouchControlsEnabled;
        playerMovement.OnTouchDisabledListeners += OnTouchControlsDisabled;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
         * Movement
         */
        //Set MovementInput based on this.
        playerMovement.MovementInput = movementJoystick.Direction;
    }

    public void OnFireButtonClicked()
    {
        playerWeapon.Fire();
    }
    void OnTouchControlsEnabled()
    {
        gameObject.SetActive(true);
    }
    void OnTouchControlsDisabled()
    {
        gameObject.SetActive(false);
    }
}
