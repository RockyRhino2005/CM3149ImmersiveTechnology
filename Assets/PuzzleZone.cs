using UnityEngine;

using UnityEngine;

public class PuzzleZone : MonoBehaviour
{
    public string requiredTag = "PuzzleObject";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            Debug.Log("Object entered zone: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            Debug.Log("Object left zone: " + other.name);
        }
    }
}
