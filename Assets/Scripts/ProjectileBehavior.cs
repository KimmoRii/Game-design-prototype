using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private bool canPierceEnemies;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (!canPierceEnemies)
            {
                Destroy(gameObject);
            }
        }

        if (collision.transform.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
