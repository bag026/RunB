using UnityEngine;

public class Coins : Pickup
{
    // Start iscalled once before the first execution of Update after the MonoBehaviour is created

    protected override void OnPickup()
    {
        Debug.Log("Coin collected!");
    }
}
