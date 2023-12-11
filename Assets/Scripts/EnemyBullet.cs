using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int bulletDamage = 1;
    public float bulletSpeed = 5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<PlayerStats>().TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
    }
}
