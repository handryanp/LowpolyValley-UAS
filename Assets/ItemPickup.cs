using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;

    private bool canPickup = false;

    private void Update()
    {
        if (canPickup && Input.GetKeyDown(pickupKey))
        {
            UseItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }

    private void UseItem()
    {
        Debug.Log("Item digunakan!");
    }
}
