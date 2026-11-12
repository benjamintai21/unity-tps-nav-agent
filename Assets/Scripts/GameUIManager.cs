using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerKeyInventory playerInventory;
    [SerializeField] private NavMeshAgent playerAgent;

    [Header("UI Text Elements")]
    [SerializeField] private TMP_Text currentKeyText;
    [SerializeField] private TMP_Text doorsOpenedText;
    [SerializeField] private TMP_Text speedLabelText;

    [Header("Speed Slider Settings")]
    [SerializeField] private Slider speedSlider;
    [SerializeField] private float minSpeed = 1.0f;
    [SerializeField] private float maxSpeed = 12.0f;

    void Start()
    {
        // Auto-find player references if left empty in the Inspector
        if (playerInventory == null || playerAgent == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                if (playerInventory == null) playerInventory = player.GetComponent<PlayerKeyInventory>();
                if (playerAgent == null) playerAgent = player.GetComponent<NavMeshAgent>();
            }
        }

        // Configure the speed slider range and initial value
        if (speedSlider != null && playerAgent != null)
        {
            speedSlider.minValue = minSpeed;
            speedSlider.maxValue = maxSpeed;
            speedSlider.value = Mathf.Clamp(playerAgent.speed, minSpeed, maxSpeed);

            speedSlider.onValueChanged.AddListener(OnSpeedSliderChanged);
            UpdateSpeedLabel(speedSlider.value);
        }
    }

    void Update()
    {
        if (playerInventory == null) return;

        // 1. Update Held Key UI
        if (currentKeyText != null)
        {
            string keyStatus = playerInventory.HasKey ? playerInventory.CurrentKey.ToString() : "None";
            currentKeyText.text = $"Current Key: {keyStatus}";
        }

        // 2. Update Doors Opened UI
        if (doorsOpenedText != null)
        {
            doorsOpenedText.text = $"Doors Opened: {playerInventory.DoorsOpened}";
        }
    }

    private void OnSpeedSliderChanged(float newSpeed)
    {
        if (playerAgent != null)
        {
            playerAgent.speed = newSpeed;
        }
        UpdateSpeedLabel(newSpeed);
    }

    private void UpdateSpeedLabel(float speedValue)
    {
        if (speedLabelText != null)
        {
            speedLabelText.text = $"Move Speed: {speedValue:F1}";
        }
    }
}