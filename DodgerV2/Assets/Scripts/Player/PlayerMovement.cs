using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Handles player movement.
 */
[RequireComponent(typeof(Rigidbody2D))]
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
    [SerializeField]
    Vector2 MovementInput;

    //Last rotation input. Determines direction of rotation.
    [SerializeField]
    float RotationInput;

    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Add force based on movement input and speed.
        _rigidbody2D.AddForce(MovementInput * MovementSpeed * Time.deltaTime, ForceMode2D.Impulse);


        //Rotate based on rotationinput and rotation speed.
        Vector3 Rotation = new Vector3(0, 0, RotationInput * TurnSpeedDeg * Time.deltaTime);
        transform.Rotate(Rotation);
    }

    //Called when player presses any of the move keys.
    public void Move(InputAction.CallbackContext context)
    {
        //Save input value to MovementInput.
        MovementInput = context.ReadValue<Vector2>();
    }

    //Called when player presses any of the rotation keys.
    public void Rotate(InputAction.CallbackContext context)
    {
        //Save input value to RotationInput
        RotationInput = context.ReadValue<float>();
    }
}
