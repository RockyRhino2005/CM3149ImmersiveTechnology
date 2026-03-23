using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator animator;

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
    }

    public void CloseDoor()
    {
        animator.SetTrigger("CloseDoor");
    }
}