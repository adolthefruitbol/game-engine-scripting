using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public float honeyProductionRate = 10.0f; // Rate of honey production per second
    public int startingBees = 10; // Starting number of bees
    public GameObject beePrefab; // Reference to bee prefab

    private int nectarStored = 0;
    private int honeyStored = 0;
    private float honeyCountdown = 0.0f;
    private bool isCountingDown = false;

    private void Start()
    {
        // Instantiate bees
        for (int i = 0; i < startingBees; i++)
        {
            GameObject beeObject = Instantiate(beePrefab, transform.position, Quaternion.identity);
            Bee bee = beeObject.GetComponent<Bee>();
            bee.Init(this);
        }
    }

    private void Update()
    {
        if (nectarStored > 0 && !isCountingDown)
        {
            // Start counting down to produce honey
            honeyCountdown = honeyProductionRate;
            isCountingDown = true;
        }

        if (isCountingDown)
        {
            honeyCountdown -= Time.deltaTime;
            if (honeyCountdown <= 0)
            {
                ProduceHoney();
            }
        }
    }

    private void ProduceHoney()
    {
        if (nectarStored > 0)
        {
            nectarStored--;
            honeyStored++;
            // Check if there is more nectar and reset the timer if that is the case
            if (nectarStored > 0)
            {
                honeyCountdown = honeyProductionRate;
            }
            else
            {
                isCountingDown = false;
            }
        }
    }

    public void GiveNectar()
    {
        nectarStored++;
        if (!isCountingDown)
        {
            // Start counting down if not already counting down
            honeyCountdown = honeyProductionRate;
            isCountingDown = true;
        }
    }
}
