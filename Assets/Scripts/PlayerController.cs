using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float runSpd;
    private Animator animator;
    private Vector3 input;
    private bool isMoving;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        transform.position += input * runSpd * Time.deltaTime;

        if (input != new Vector3(0, 0))
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        animator.SetBool("isMoving", isMoving);
    }
}
