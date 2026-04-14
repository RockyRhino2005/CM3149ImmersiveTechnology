using UnityEngine;

public class windmillSpin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool isSpinning = false;

     public void pushButton()
    {
        bool isSpinning = true;
    }
    public void update()
    {
        if (isSpinning == true)
        {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    }
}
