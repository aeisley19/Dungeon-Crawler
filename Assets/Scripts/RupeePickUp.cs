using UnityEngine;

public class RupeePickUp : AbstractPickup
{
    [SerializeField] private Animator anim;
    [SerializeField] private RupeeUI rupeeUI;
    [SerializeField] private int rupeeValue;

    public override void PickupAction()
    {
        anim.SetBool("pickedUp", true);
        RupeeManager.Instance.AddRupees(rupeeValue);
        rupeeUI.RupeeCounter();
    }

    public void OnEndAnimation()
    {
        Destroy(gameObject);
    }
}
