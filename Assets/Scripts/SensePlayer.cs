using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensePlayer : MonoBehaviour
{
    public EnemyMovement enemyMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemyMovement.playerSpotted = true;
        }
    }
}
