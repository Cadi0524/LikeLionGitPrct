using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    
    //나중에 그냥 데이터 받아오는걸로 하자
    //지금은 두 번 캐싱중
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    public Transform cameraTransform;
    public float mouseSensitivity = 0.2f;
    private float eulerAngleX;
    private float eulerAngleY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 moveInput)
    {
       Vector3 forward = cameraTransform.forward;
       Vector3 right = cameraTransform.right;
       
       forward.y = 0;
       right.y = 0;
       
       forward.Normalize();
       right.Normalize();
       
       Vector3 moveDirection = forward * moveInput.y + right * moveInput.x; 
       Debug.DrawRay(transform.position, moveDirection, Color.red);
       
       rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
       
    }

    public void Look(Vector2 lookInput)
    {
       
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;
      
        // 위 아래 회전은 'X축을 고정한 채로 회전'하는 방향
        // 더해서 회전이 -가 되어야 위로 회전하므로 입력을 반대로 해주어야 함
        eulerAngleX -= mouseY; 
        
        // 양 옆 회전은 'Y축을 고정한 채로 회전'하는 방향
        eulerAngleY += mouseX;
        
        eulerAngleX = Mathf.Clamp(eulerAngleX, -90f, 90f);
        
        
        //원래 코드 
        //cameraTransform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0f);
        
        transform.rotation = Quaternion.Euler(0f, eulerAngleY, 0f); // 플레이어 회전
        cameraTransform.localRotation = Quaternion.Euler(eulerAngleX, 0f, 0f); // 카메라 회전
        
    }

    public void Jump(bool isTriggered)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}