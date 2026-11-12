using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private KeyColor keyColor = KeyColor.Red;

    void OnValidate()
    {
        ApplyColor();
    }

    void Start()
    {
        ApplyColor();
        GetComponent<Collider>().isTrigger = true;
    }

    private void ApplyColor()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null && Application.isPlaying)
        {
            rend.material.color = KeyColorHelper.ToUnityColor(keyColor);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerKeyInventory inventory = other.GetComponent<PlayerKeyInventory>();
        if (inventory != null && inventory.TryPickupKey(keyColor))
        {
            // Remove the key sphere from the scene once collected
            Destroy(gameObject);
        }
    }
}