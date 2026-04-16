using UnityEngine;

public class windmillSpin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool isSpinning = true;

     public void pushButton()
    {
        isSpinning = true;
    }
    public void Update()
    {
        if (isSpinning == true)
        {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    }
}
