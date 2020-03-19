using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Handles player movement.
 */
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    //How fast the player moves.
    [SerializeField]
    float MovementSpeed = 10f;
    //How fast the player turns.
    [SerializeField]
    float TurnSpeedDeg = 90f;

    //Last Movement Input. Determines direction of movement.
    public Vector2 MovementInput;

    //Rotation input. Determines Z rotation.
    public float RotationInput = 0;

    //The Z rotation to set us to during Update()
    public float TargetZRotation = 0;

    public bool TouchControlsEnabled = false;

    public delegate void OnTouchControlsToggled();
    public event OnTouchControlsToggled OnTouchEnabledListeners;
    public event OnTouchControlsToggled OnTouchDisabledListeners;

    CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        SetTouchControlsEnabled(Application.isMobilePlatform, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculate how far we should move.
        Vector3 movementDistance = MovementInput * MovementSpeed * Time.deltaTime;

        //Raycast for movement.

        Collider2D hitCollider = Physics2D.OverlapCircle(gameObject.transform.position + movementDistance, circleCollider2D.radius, 1 << LayerMask.NameToLayer("Default"));

        //Check so we didnt hit anything
        if (hitCollider == null)
        {
            //If we didnt then we can move.
            transform.Translate(movementDistance, Space.World);
        }

        //If we have rotation input add it onto the targetZrotation.
        if (RotationInput != 0)
        {
            TargetZRotation += RotationInput * TurnSpeedDeg * Time.deltaTime;
        }

        //Rotate based on rotationinput and rotation speed.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, TargetZRotation));
    }

    /*
     * Keyboard Input
     * TODO Move to different class?
     */

    //Called when player presses any of the move keys.
    public void Move(InputAction.CallbackContext context)
    {
        //Save input value to MovementInput.
        MovementInput = context.ReadValue<Vector2>();

        //Take over controls from touch.
        SetTouchControlsEnabled(false);
    }

    //Called when player touches the screen.
    public void Touch(InputAction.CallbackContext context)
    {
        SetTouchControlsEnabled(true);
    }

    void SetTouchControlsEnabled(bool enabled, bool InvokeEvenIfSame = false)
    {
        if(TouchControlsEnabled != enabled || InvokeEvenIfSame)
        {
            TouchControlsEnabled = enabled;

            if (enabled)
            {
                if(OnTouchEnabledListeners != null)
                {
                    OnTouchEnabledListeners.Invoke();
                }
            }
            else
            {
                if(OnTouchDisabledListeners != null)
                {
                    OnTouchDisabledListeners.Invoke();
                }
            }
        }
    }
}
