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
    [SerializeField] private GameObject bubblePrefab;
    private float bubbleCooldownTimer;
    [SerializeField] private float bubbleCoolDown;
    [SerializeField] private bool bubbleReady;

    public int rangedDamage;
    [SerializeField] private float rangedCoolDown;
    [SerializeField] private float bulletForce;

    private float cooldownTimer;
    private bool weaponReady = true;
    public int energy = 20;
    public int bulletEnergyCost;
    public int bubbleEnergyCost;
    public TMP_Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Energy " + energy.ToString();

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        if (!weaponReady)
        {
            WaitBetweenShots();
        }

        if (Input.GetKeyDown("q"))
        {
            ShootBubble();
        }

        if (!bubbleReady)
        {
            BubbleReload();
        }
    }

    private void Shoot()
    {
        if (weaponReady && energy > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            cooldownTimer = rangedCoolDown;
            weaponReady = false;
            energy -= bulletEnergyCost;
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

    private void ShootBubble()
    {
        if (bubbleReady)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bubblePrefab, new Vector3(cursorPos.x, cursorPos.y, -0.3f), Quaternion.identity);
            bubbleCooldownTimer = bubbleCoolDown;
            bubbleReady = false;
            energy -= bubbleEnergyCost;
        }
    }

    private void BubbleReload()
    {
        bubbleCooldownTimer -= Time.deltaTime;

        if (bubbleCooldownTimer <= 0.0f)
        {
            bubbleReady = true;
        }
    }
}
