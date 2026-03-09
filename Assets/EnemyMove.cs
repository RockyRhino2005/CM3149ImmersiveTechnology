using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 2f;

    private bool moving = false;
    private bool stopped = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (moving && !stopped)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
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

    public void StopEnemy()
    {
        stopped = true;
        anim.SetBool("Walking", false);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        // Load game over scene or restart
    }
}