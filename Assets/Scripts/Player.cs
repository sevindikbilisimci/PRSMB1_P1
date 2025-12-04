using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    public float moveSpeed = 5f;
    
    public Animator animator;
    public Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = Vector3.zero;

        Vector3 inputDirection = new Vector3(h, 0f, v);

        if(inputDirection.magnitude <=0.1f)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);


            Vector3 camForward =  cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;    

            Quaternion targetRotation = Quaternion.LookRotation(camForward);

            transform.rotation = targetRotation;

            moveDirection = (camForward * inputDirection.z + camRight * inputDirection.x).normalized;

        }                                                            

        cc.Move(moveDirection * moveSpeed * Time.deltaTime);

    }
}
