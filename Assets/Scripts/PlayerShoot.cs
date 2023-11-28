using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// I made the shooting mechanics with the help of this tuotrial: https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys
// I made the cooldown part with the help of this tutorial: https://www.youtube.com/watch?v=1fBKVWie8ew&ab_channel=DestinedToLearn
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private float coolDown;
    [SerializeField] private float bulletForce;

    private float cooldownTimer;
    private bool weaponReady = true;
    [SerializeField] private int ammo = 20;
    public TMP_Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo " + ammo.ToString();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        if (!weaponReady)
        {
            WaitBetweenShots();
        }
    }

    private void Shoot()
    {
        if (weaponReady && ammo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            cooldownTimer = coolDown;
            weaponReady = false;
            ammo -= 1;
        }
    }

    private void WaitBetweenShots()
    {
        cooldownTimer -= Time.deltaTime;
        
        if (cooldownTimer <= 0.0f)
        {
            weaponReady = true;
        }
    }
}
