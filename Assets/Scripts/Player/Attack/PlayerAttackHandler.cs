using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) print("hit");
    }

}
