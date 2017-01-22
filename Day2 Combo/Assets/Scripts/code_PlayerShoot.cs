using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_PlayerShoot : MonoBehaviour {
    public GameObject player;
    public GameObject playerBullet;
    public GameObject katanaObject;
    public float gunLocationCorectionX;
    private float bulletSpeed = 20;
    private bool reloading = false;
    private float reloadTimer;
    private float reloadDefault;
    private int weapon = 0;
    private int ammo; // implement ammo when come back
    private bool weaponAuto;
    private bool meleeMode;
    private Animator anim;
    private Vector3 gunPlaceCorection;

    void Start()
    {
        gunPlaceCorection = new Vector3(gunLocationCorectionX, 0, 0);
        anim = GetComponent<Animator>();
        meleeMode = true;
        weaponAuto = false;
        changeWeapon(0);
        reloadTimer = reloadDefault;
    }

    void Update () {

        // Test key pad weapon change
        //if (Input.GetKeyDown(KeyCode.Keypad1)) changeWeapon(0);
        //if (Input.GetKeyDown(KeyCode.Keypad2)) changeWeapon(1);
        //if (Input.GetKeyDown(KeyCode.Keypad3)) changeWeapon(2);
        //if (Input.GetKeyDown(KeyCode.Keypad4)) changeWeapon(3);

        if (meleeMode)
        {
            katanaSliceAttack();
        }
        else if (weaponAuto)
        {
            gunAutoShoot();
        }
        else if (!weaponAuto)
        {
            gunShoot();
        }

        gunReload();
	}

    // Consumes ammo
    void consumeAmmo()
    {
        if (weapon != 0 && ammo > 0)
        {
            ammo--;
            Debug.Log("Ammo: " + ammo);
        }

        if(ammo == 0)
        {
            changeWeapon(0);
        }
    }

    // Changes weapon on power up
    public void changeWeapon(int type)
    {
        weapon = type;

        // Katana [0]
        if (type == 0)
        {
            anim.SetTrigger("SwitchToKatana");
            meleeMode = true;
            Debug.Log("Changed to Katana!");
            reloadDefault = 0.46f;
        }

        // Pistol [1]
        if (type == 1)
        {
            anim.SetTrigger("SwitchToPistol");
            Debug.Log("Changed to Pistol!");
            ammo = 24;
            bulletSpeed = 21.7f;
            weaponAuto = false;
            reloadDefault = 0.41f;
        }

        // AC470 [2]
        if (type == 2)
        {
            anim.SetTrigger("SwitchToAk");
            Debug.Log("Changed to AK!");
            ammo = 47;
            bulletSpeed = 47.71f;
            weaponAuto = true;
            reloadDefault = 0.16f;
        }

        // Shotgun [3]
        if (type == 3)
        {
            anim.SetTrigger("SwitchToShotgun");
            Debug.Log("Changed to Shotgun!");
            ammo = 18;
            bulletSpeed = 27.6f;
            weaponAuto = false;
            reloadDefault = 0.46f;
        }

        reloadTimer = reloadDefault;
        if (type != 0) meleeMode = false;
    }

    // Non-auto shooting (spawns player bullet)
    void gunShoot()
    {
        if (Input.GetMouseButtonDown(0) && !reloading)
        {
            // Finds mouse position and sets bullet direction
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 direction = target - playerPos;
            direction.Normalize();

            GameObject projectile = (GameObject)Instantiate(playerBullet, player.transform.position + gunPlaceCorection, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            // Shotgun two additional side bullets
            if (weapon == 3)
            {
                direction.y += 0.12f;
                direction.Normalize();
                GameObject projectile1 = (GameObject)Instantiate(playerBullet, player.transform.position + gunPlaceCorection, Quaternion.identity);
                projectile1.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                projectile1.transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

                direction.y -= 0.24f;
                direction.Normalize();
                GameObject projectile2 = (GameObject)Instantiate(playerBullet, player.transform.position + gunPlaceCorection, Quaternion.identity);
                projectile2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                projectile2.transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
            }

            consumeAmmo();
            reloading = true;
        }
    }

    // Auto shooting (spawns player bullet)
    void gunAutoShoot()
    {
        if (Input.GetMouseButton(0) && !reloading)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 direction = target - playerPos;
            direction.Normalize();

            GameObject projectile = (GameObject)Instantiate(playerBullet, player.transform.position + gunPlaceCorection, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

            consumeAmmo();
            reloading = true;
        }
    }

    void katanaSliceAttack()
    {
        
        if (Input.GetMouseButtonDown(0) && !reloading && player != null)
        {
            anim.SetTrigger("Shooting");
            Instantiate(katanaObject,
            new Vector2(player.transform.position.x + 0.25f, player.transform.position.y ),
            Quaternion.identity);

            reloading = true;
        }
        
    }

    // Delay before player can shoot again
    void gunReload()
    {
        if (reloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                reloading = false;
                reloadTimer = reloadDefault;
                anim.SetTrigger("StopKatanaAttack");
            }
        }
    }
}