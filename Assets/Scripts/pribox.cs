using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pribox : MonoBehaviour
{ 
    public Sprite visibleSprite;
    public Sprite invisibleSprite;

    private bool isVisible = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisibility();
    }

    
    public void EnemyKilled()
    {
        isVisible = true;
        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        spriteRenderer.sprite = isVisible ? visibleSprite : invisibleSprite;
    }
}
