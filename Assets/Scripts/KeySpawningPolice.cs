using UnityEngine;

public class KeySpawningPolice : EnemyController
{
    // public Transform Enemy;
    public Transform key;

    private void OnDestroy()
    {
        Instantiate(key, this.transform.position, this.transform.rotation);
    }
}
