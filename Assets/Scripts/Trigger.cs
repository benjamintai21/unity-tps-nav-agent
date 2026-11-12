using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player stepped on trigger - opening door.");
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                target.SendMessage("Activate");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player left trigger - closing door.");
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                target.SendMessage("Deactivate");
            }
        }
    }
}