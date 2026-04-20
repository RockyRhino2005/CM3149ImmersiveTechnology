using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSource;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            audioSource.Play();
        }
    }
}
