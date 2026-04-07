using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public lockDoorTrigger door;
    private bool alreadyPressed = false;

    public void Press()
    {
        if (alreadyPressed) return;

        alreadyPressed = true;
        door.ButtonPressed();
    }
}