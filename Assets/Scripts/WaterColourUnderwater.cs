using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColourUnderwater : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private PlayerController player;
    public float maxDepthForLerp;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public Color shallowWaterColor;
    public Color deepWaterColor;

    Color lerpedColor = Color.white;


    void Update()
    {
        float lerpT = player.currentDepth / maxDepthForLerp;
        if(lerpT > 1) {
            lerpT = 1;
        }

    

        lerpedColor = Color.Lerp(shallowWaterColor, deepWaterColor, lerpT);

        spriteRenderer.color = lerpedColor;
    }
}


