using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private KeyColor doorColor = KeyColor.Red;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Renderer doorRenderer;

    private bool playerInRange = false;
    private bool isOpen = false;
    private PlayerKeyInventory playerInventory;

    void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponentInChildren<Animator>();
        }

        if (doorRenderer == null)
        {
            doorRenderer = GetComponentInChildren<Renderer>();
        }

        if (doorRenderer != null)
        {
            doorRenderer.material.color = KeyColorHelper.ToUnityColor(doorColor);
        }
    }

    void Update()
    {
        if (playerInRange && !isOpen && Input.GetKeyDown(KeyCode.C))
        {
            if (playerInventory != null && playerInventory.HasSpecificKey(doorColor))
            {
                // Single-use: remove key from player and open door
                playerInventory.UseKey();
                OpenDoor();
            }
            else
            {
                Debug.Log($"Locked! You need the {doorColor} key.");
            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;

        if (playerInventory != null)
        {
            playerInventory.IncrementDoorsOpened();
        }

        if (doorAnimator != null)
        {
            doorAnimator.SetBool("isOpen", true);
        }
    }

    private void CloseDoor()
    {
        isOpen = false;
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("isOpen", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
        playerInventory = other.GetComponent<PlayerKeyInventory>();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        // Close automatically when player moves away
        if (isOpen)
        {
            CloseDoor();
        }
    }

    void OnGUI()
    {
        if (playerInRange && !isOpen)
        {
            string prompt = (playerInventory != null && playerInventory.HasSpecificKey(doorColor))
                ? $"Press C to open {doorColor} Door"
                : $"Locked — Requires {doorColor} Key";

            GUI.Box(new Rect(Screen.width / 2f - 130f, Screen.height - 80f, 260f, 30f), prompt);
        }
    }
}