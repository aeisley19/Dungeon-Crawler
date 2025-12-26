using UnityEngine;

public class HeartPickup : AbstractPickup
{

    [SerializeField] private HealthManager healthManager;
    [SerializeField] private HealthUI ui;
    [SerializeField] private int heartIncreaseAmount;

    public override void PickupAction()
    {
        healthManager.ReplenishHealth(heartIncreaseAmount);
        ui.RegenSingleUI();
        Destroy(gameObject);
    }
}
