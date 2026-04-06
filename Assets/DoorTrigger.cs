using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float slideDistance = 1f;  // How far the doors move
    public float slideSpeed = 2f;     // Speed of movement
    public float delay = 3f;          // Delay before doors start moving

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

        // Start the door opening after a delay
        Invoke("StartOpening", delay);
    }

    void StartOpening()
    {
        opening = true;
    }

    void Update()
    {
        if (opening)
        {
            // Smoothly move the doors
            leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftTargetPos, slideSpeed * Time.deltaTime);
            rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightTargetPos, slideSpeed * Time.deltaTime);
        }
    }
}