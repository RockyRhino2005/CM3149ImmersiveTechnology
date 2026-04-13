using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private CharacterController cc;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update()
    {
        bool _isGrounded = IsGrounded();
        if (_isGrounded && movement.y < 0)
        {
            movement.y = -2f;
        }
        else
        {
            movement.y += gravity * Time.deltaTime;
        }
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded)
        {
            Jump();
        }

        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}
