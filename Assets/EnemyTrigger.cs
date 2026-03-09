using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyMove enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StartMoving();
        }
    }
}