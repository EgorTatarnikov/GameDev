using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToFitScreen : MonoBehaviour
{
    private SpriteRenderer sr;
    private float spriteScale;
    private float scaleMultiplier;

    public float ScaleMultiplier { get { return scaleMultiplier; } }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        spriteScale = worldScreenWidth / sr.sprite.bounds.size.x;
        scaleMultiplier = spriteScale / transform.localScale.x;
        transform.localScale = new Vector3(spriteScale, spriteScale, 1);
    }
}