using UnityEngine;

public class lockDoorTrigger : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float slideDistance = 1f;
    public float slideSpeed = 2f;

    public int totalButtons = 4;   // Number of required buttons
    private int buttonsPressed = 0;

    private Vector3 leftStartPos;
    private Vector3 rightStartPos;
    private Vector3 leftTargetPos;
    private Vector3 rightTargetPos;

    private bool opening = false;

    void Start()
    {
        leftStartPos = leftDoor.position;
        rightStartPos = rightDoor.position;

        leftTargetPos = leftStartPos + new Vector3(slideDistance, 0, 0);
        rightTargetPos = rightStartPos + new Vector3(-slideDistance, 0, 0);
    }

    // This will be called by buttons
    public void ButtonPressed()
    {
        buttonsPressed++;

        Debug.Log("Button pressed: " + buttonsPressed);

        if (buttonsPressed >= totalButtons)
        {
            StartOpening();
        }
    }

    void StartOpening()
    {
        opening = true;
    }

    void Update()
    {
        if (opening)
        {
            leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftTargetPos, slideSpeed * Time.deltaTime);
            rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightTargetPos, slideSpeed * Time.deltaTime);
        }
    }
}