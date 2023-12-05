using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public int meleeDamage;
    [SerializeField] private float meleeCooldown;
    private float timeUntilMelee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButton(1))
            {
                animator.SetTrigger("Attack");
                timeUntilMelee = meleeCooldown;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }
}
