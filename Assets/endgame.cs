using UnityEngine;

public class endgame : MonoBehaviour
{
    public GameObject uiPanel;

    // This will be called by the XR button event
    public void ShowUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);
        }
    }
}
