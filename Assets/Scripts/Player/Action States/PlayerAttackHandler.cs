using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag ==  "Enemy") print("hit");
    }

}
