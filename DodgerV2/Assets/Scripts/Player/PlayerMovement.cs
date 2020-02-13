using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed = 10f;
    [SerializeField]
    float TurnSpeedDeg = 90f;

    [SerializeField]
    Vector2 MovementInput;

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
        _rigidbody2D.AddForce(MovementInput * MovementSpeed * Time.deltaTime, ForceMode2D.Impulse);

        _rigidbody2D.AddTorque((RotationInput * TurnSpeedDeg) * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }
    public void Rotate(InputAction.CallbackContext context)
    {
        RotationInput = context.ReadValue<float>();
    }
}
