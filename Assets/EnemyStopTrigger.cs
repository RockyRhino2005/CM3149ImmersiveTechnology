using UnityEngine;

public class EnemyStopTrigger : MonoBehaviour
{
    public EnemyMove enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.DisableEnemy();
        }
    }
}