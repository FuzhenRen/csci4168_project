/*
    This is the player controller to control the player movement and get track of its direction for rotating its direction to the right direction and sync with cam.
*/
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float jumpForce = 5f;   
    private bool isGrounded;        
    private Rigidbody rb;           

    public float mouseSensitivity = 2f;  
    private float yaw;                    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;  //hide the mouse
        yaw = transform.eulerAngles.y; // initial the mouse angle
    }

    private void Update()
    {
        Move();         
        Jump();         
        Rotate();       
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // get the move direction.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // get player moving direction
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

        Vector3 desiredMoveDirection = (right * moveHorizontal + forward * moveVertical).normalized;

        // move player by its rigidbody.
        rb.MovePosition(rb.position + desiredMoveDirection * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        // get the player's angle
        Quaternion targetRotation = Quaternion.Euler(0, yaw, 0);
        
        // rotate the player to the mouse direction
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // is on the ground and set the tag.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //if player jump then 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
        }
    }
}
