using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Bee : MonoBehaviour
{
    private Hive hive;

    private void Update()
    {
        CheckAnyFlower();
    }

    public void Init(Hive hive)
    {
        this.hive = hive;
    }

    public void CheckAnyFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();
        if (flowers.Length > 0)
        {
            Flower randomFlower = flowers[Random.Range(0, flowers.Length)];

            transform.DOMove(randomFlower.transform.position, 1f).OnComplete(() =>
            {
                if (randomFlower.GetNectar())
                {
                    GoToHive();
                }
                else
                {
                    CheckAnyFlower();
                }
            }).SetEase(Ease.Linear);
        }
    }

    private void GoToHive()
    {
        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
        {
            hive.GiveNectar();

            CheckAnyFlower();
        }).SetEase(Ease.Linear);
    }
}
