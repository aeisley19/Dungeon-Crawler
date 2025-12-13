using UnityEngine;

public class RupeePickUp : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private RupeeUI rupeeUI;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
            anim.SetBool("pickedUp", true);
            RupeeManager.Instance.AddRupees(10);
            rupeeUI.RupeeCounter();

        }
    }

    public void OnEndAnimation()
    {
        Destroy(gameObject);
    }
}
