using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlideDoor : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Called automatically by Trigger.cs on OnTriggerEnter
    void Activate()
    {
        animator.SetBool("isOpen", true);
    }

    // Called automatically by Trigger.cs on OnTriggerExit
    void Deactivate()
    {
        animator.SetBool("isOpen", false);
    }
}