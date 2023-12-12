using UnityEngine;

public class KeySpawningPolice : EnemyController
{
    // public Transform Enemy;
    public Transform key;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Instantiate(key, this.transform.position, this.transform.rotation);
    }
}
