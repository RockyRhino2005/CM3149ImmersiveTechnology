using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public string correctObjectName;
    private bool isCorrect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == correctObjectName)
        {
            isCorrect = true;
            Debug.Log("Correct object placed!");
            PuzzleManager.instance.CheckPuzzle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == correctObjectName)
        {
            isCorrect = false;
        }
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }
}
