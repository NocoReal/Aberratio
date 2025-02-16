using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    [SerializeField] private InputActionReference Move;

    [SerializeField] float MoveSpeed = 12f, JumpHeight = 3f;

    public float gravity = -9.81f;

    bool isGrounded;

    public Transform groundCheck;
    public LayerMask groundMask;
    
    Vector2 moveAxis;
    Vector3 velocity;

    private void Awake()
    {
        Move.action.performed += ctx => moveAxis = ctx.ReadValue<Vector2>();
        Move.action.canceled += ctx => moveAxis = Vector2.zero;
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 moveDir = transform.right * moveAxis.x + transform.forward * moveAxis.y;

            Controller.Move(moveDir * MoveSpeed * Time.deltaTime);

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            Controller.Move(velocity * Time.deltaTime);
        }
    }

}
