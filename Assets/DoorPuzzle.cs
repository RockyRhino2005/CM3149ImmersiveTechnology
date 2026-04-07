using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float slideDistance = 1f;  // How far the doors move
    public float slideSpeed = 2f;     // Speed of movement

    private Vector3 leftStartPos;
    private Vector3 rightStartPos;
    private Vector3 leftTargetPos;
    private Vector3 rightTargetPos;
    private bool opening = false;

    void Start()
    {
        // Store the initial positions
        leftStartPos = leftDoor.position;
        rightStartPos = rightDoor.position;

        // Calculate target positions (inwards)
        leftTargetPos = leftStartPos + new Vector3(slideDistance, 0, 0);
        rightTargetPos = rightStartPos + new Vector3(-slideDistance, 0, 0);
    }

    void Update()
    {
        if (opening)
        {
            // Smoothly move the doors
            leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftTargetPos, slideSpeed * Time.deltaTime);
            rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightTargetPos, slideSpeed * Time.deltaTime);

            // Stop updating once doors reach target
            if (leftDoor.position == leftTargetPos && rightDoor.position == rightTargetPos)
                opening = false;
        }
    }

    // Public function to open the door
    public void OpenDoor()
    {
        opening = true;
    }
}