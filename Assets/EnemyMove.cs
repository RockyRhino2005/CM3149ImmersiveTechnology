using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class EnemyMove : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 2f;

    private bool moving = false;
    private bool stopped = false;

    private Animator anim;

    public Transform playerCamera;   // XR Camera
    public GameObject gameOverUI;    // World-space canvas
    public float appearDistance = 2f;

    public AudioSource audioSource;
    public AudioSource audioSourcedie;

    public AudioSource audioSourceVoice;

    public GameObject xrOrigin;

    // Locomotion components
    private ContinuousMoveProviderBase moveProvider;
    private ContinuousTurnProviderBase turnProvider;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (xrOrigin != null)
        {
            moveProvider = xrOrigin.GetComponent<ContinuousMoveProviderBase>();
            turnProvider = xrOrigin.GetComponent<ContinuousTurnProviderBase>();
        }
    }

    void Update()
    {
        if (moving && !stopped)
        {
            Vector3 target = targetPoint.position;
            target.y = transform.position.y; // keep current height

            transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
            );
        }

        if (Vector3.Distance(transform.position, targetPoint.position) < 2f)
{
    GameOver();
}
    }

    public void StartMoving()
    {
        if (!moving)
        {
            moving = true;
            anim.SetBool("Walking", true);
            audioSource.Play();
            audioSourceVoice.Play();
            Debug.Log("Enemy is moving.");
        }
        else
        {
            Debug.Log("Enemy is already moving.");
        }
    }

    public void DisableEnemy()
    {
        stopped = true;
        moving = false;

        if (anim != null)
        {
            anim.SetBool("Walking", false);
        }
        audioSourcedie.Play();

        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        // Stop movement
        moving = false;
        stopped = true;

        // Show Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        // Disable movement
        if (moveProvider != null)
            moveProvider.enabled = false;

        if (turnProvider != null)
            turnProvider.enabled = false;


}
}