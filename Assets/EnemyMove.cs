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

    void Start()
    {
        anim = GetComponent<Animator>();
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

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                GameOver();
            }
        }
    }

    public void StartMoving()
    {
        moving = true;
        anim.SetBool("Walking", true);
    }

    public void DisableEnemy()
    {
        stopped = true;
        moving = false;

        if (anim != null)
        {
            anim.SetBool("Walking", false);
        }

        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        // Stop movement
        moving = false;
        stopped = true;

        // Get position in front of player
        Vector3 forward = playerCamera.forward;
        forward.y = 0f; // keep it level

        Vector3 spawnPos = playerCamera.position + forward.normalized * appearDistance;

        // Move enemy in front of player
        transform.position = spawnPos;

        // Make enemy face the player
        transform.LookAt(playerCamera);

        // Show Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

}
}