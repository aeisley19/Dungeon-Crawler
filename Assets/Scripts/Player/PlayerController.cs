using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //[SerializeField] private Rigidbody2D rb;
    //  [SerializeField] private float runSpd;
    //private SharedPlayerContext sharedCtx;
    //private PlayerMovementStateManager movementManager;
    //private PlayerActionStateManager actionManager;
    
    public SharedPlayerContext SharedCtx { get; private set; }

    private void Awake()
    {
        SharedCtx = new SharedPlayerContext(animator);

      //  movementManager = GetComponent<PlayerMovementStateManager>();
       // actionManager = GetComponent<PlayerActionStateManager>();
    }
}
