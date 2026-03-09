using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityScale;
    private float rotationVelocity;
    private float rotationSmoothFactor = 0.3f;

    [Header("Ground Detection")]
    [SerializeField] private Transform feet;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask whatIsGround;

    private CharacterController controller;

    private bool isGrounded;
    private Vector2 inputVector; 
    private Vector3 horizontalMovement; 
    private Vector3 verticalMovement;
    private Vector3 totalMovement;

    private PlayerInput input;
    private Animator anim;
    private Camera cam;
    private float targetSpeed;
    private float currentSpeed;
    private float speedVelocity;
    private float movementSmoothFactor= 0.3f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
        anim = GetComponentInChildren<Animator>();
        
        //bloquea el mouse y lo esconde
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //.started: cuando empieza a hacerse la acción
        //.performed: se dispara cuando hay cambios de valor
        //.canceled: cuando esa acción se cancela
        input.actions["Jump"].started += JumpStarted;
        input.actions["Move"].performed += UpdateMovement;
        input.actions["Move"].canceled += UpdateMovement;
    }

    private void UpdateMovement(InputAction.CallbackContext obj)
    {
        inputVector = obj.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        input.actions["Jump"].started -= JumpStarted;
        input.actions["Move"].performed -= UpdateMovement;
        input.actions["Move"].canceled -= UpdateMovement;
    }
    private void JumpStarted(InputAction.CallbackContext obj)
    {
        if (isGrounded) Jump();
    }
    
    private void Jump()
    {
        Debug.Log("Jump!");
        //mrua
        verticalMovement.y= Mathf.Sqrt(-2 * gravityScale * jumpHeight);
    }
    void Update()
    {
        GroundCheck(); 
        ApplyGravity();
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        //Calcula la velocidad objetivo (respetando tanto joystick como teclado)
        targetSpeed = movementSpeed * inputVector.magnitude;
        
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, movementSmoothFactor);
        
        if (inputVector.sqrMagnitude > 0) //el jugador se mueve por input
        {
            float angleToRotate = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            //multiplicar un cuaternión por un vector es rotar el vector
            horizontalMovement = (Quaternion.Euler(0, angleToRotate, 0) * Vector3.forward) * currentSpeed;

            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleToRotate,
                ref rotationVelocity,
                rotationSmoothFactor);
            
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else
        {
            horizontalMovement = Vector3.zero;
        }
        
        anim.SetFloat("Blend", currentSpeed / movementSpeed);
        totalMovement = horizontalMovement + verticalMovement;
        controller.Move(totalMovement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (isGrounded && verticalMovement.y < 0)
        {
            //asegurarse de que se está tocando el suelo
            verticalMovement.y = -2f;
        }
        else
        {
            //cuando estoy en el aire se me aplica la gravedad
            verticalMovement.y += gravityScale * Time.deltaTime;
        }
    }

    private void GroundCheck()
    {
        if (Physics.CheckSphere(feet.position, detectionRadius, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feet.position, detectionRadius);
    }
}
