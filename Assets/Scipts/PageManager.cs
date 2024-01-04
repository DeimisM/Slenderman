using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public Flashlight flashlight;

    private void OnTriggerEnter(Collider other)
    {
        print("page collected");
        Destroy(other.gameObject);
        pages++;

        if (pages == 1)
        {
            enemy.target = transform; // nes pagemanager ant zaidejo galima pacio pozicija duoda visam laikui
        }
        if (pages == 2)
        {
            flashlight.usagePerSecond += 5;
        }
        if (pages == 3)
        {
            enemy.speed *= 2;
        }
        if (pages == 4)
        {
            enemy.speed *= 2;
        }
        if (pages == 5)
        {
            enemy.viewDistance += 1000;
        }
        if (pages == 6)
        {
            enemy.speed += 2;
        }
        if (pages == 7)
        {
            enemy.speed += 2;
        }
        if (pages == 8)
        {
            //you win
        }
    }
}
