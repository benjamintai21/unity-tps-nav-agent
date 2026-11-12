using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MoveTo : MonoBehaviour
{
    [Header("Destination Marker")]
    [SerializeField] private GameObject markerPrefab; // Drag your marker prefab here
    [SerializeField] private float yOffset = 0.05f;   // Slight lift so flat markers don't clip into the floor

    private NavMeshAgent agent;
    private GameObject currentMarker;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // GetMouseButtonDown fires once per click (prevents spawning dozens of prefabs per second)
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;

            if (Physics.Raycast(ray, out mouseHit))
            {
                GameObject hitObject = mouseHit.transform.gameObject;
                if (hitObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    agent.SetDestination(mouseHit.point);
                    SpawnMarker(mouseHit.point);
                }
            }
        }

        // Remove the marker once the player reaches the destination
        if (currentMarker != null && !agent.pathPending)
        {
            float arriveThreshold = Mathf.Max(agent.stoppingDistance, 0.1f);
            if (agent.remainingDistance <= arriveThreshold)
            {
                Destroy(currentMarker);
            }
        }
    }

    private void SpawnMarker(Vector3 hitPosition)
    {
        // Destroy any existing marker before spawning the new one
        if (currentMarker != null)
        {
            Destroy(currentMarker);
        }

        if (markerPrefab != null)
        {
            Vector3 spawnPos = hitPosition + Vector3.up * yOffset;
            currentMarker = Instantiate(markerPrefab, spawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
    }
}