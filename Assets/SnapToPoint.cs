using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToPoint : MonoBehaviour
{
    public Transform snapPoint;
    public float snapDistance = 0.2f;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isSnapped = false;

    // Reference to the manager
    public SnapManager snapManager;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (Vector3.Distance(transform.position, snapPoint.position) <= snapDistance)
        {
            transform.position = snapPoint.position;
            transform.rotation = snapPoint.rotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;

            if (!isSnapped)
            {
                isSnapped = true;
                snapManager.ObjectSnapped(this);
            }
        }
        else
        {
            // If not snapped, reset flag in case it was snapped before
            if (isSnapped)
            {
                isSnapped = false;
                snapManager.ObjectUnsapped(this);
            }
        }
    }
}