using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Color readyColor;
    public Color notReadyColor;

    public float nectarProductionRate = 10.0f; // Rate of nectar production per second
    private float nectarCountdown;
    private bool hasNectar = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Initialize nectar countdown to start producing nectar immediately
        nectarCountdown = nectarProductionRate;
    }

    private void Update()
    {
        if (!hasNectar)
        {
            // If flower has no nectar, start counting down to produce nectar
            nectarCountdown -= Time.deltaTime;

            if (nectarCountdown <= 0)
            {
                ProduceNectar();
                nectarCountdown = nectarProductionRate; // Reset countdown
            }
        }
    }

    private void ProduceNectar()
    {
        hasNectar = true;
        spriteRenderer.color = readyColor;
    }

    public bool HasNectar()
    {
        return hasNectar;
    }

    public bool GetNectar()
    {
        if (hasNectar)
        {
            hasNectar = false;
            spriteRenderer.color = notReadyColor;
            return true;
        }
        return false;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    // Method to notify bees that there is nectar available
    public bool NotifyBees()
    {
        return hasNectar;
    }
}
