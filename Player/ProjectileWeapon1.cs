
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ProjectileWeapon1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private  float bulletSpeed = 10f;
    public float bulletDestroyTime = 5f;
    public float reloadTime = 2f;
    private  int magazineSize = 100;
    public float timeBetweenShots = 0.1f;
    private bool canShoot = true;

    private float timerBetweenEachShoot = 0.1f;

    private int bulletsLeft;
    private bool reloading = false;
    bool shooting, readyToShoot = true;
    public bool allowButtonHold;

    public TextMeshProUGUI textToDisplayBullet;

    private void Awake()
    {
        bulletsLeft = magazineSize;
    }

    public void ResetBestWeaponEffect(){
        bulletSpeed = 10f;
        timerBetweenEachShoot = 0.1f;
        magazineSize = 100;
    }


    public void BestWeaponEffect(){
        bulletSpeed *= 2.3f;
        timerBetweenEachShoot = 0.01f;
        magazineSize = 780;
    }


    private void Update()
    {
        MyInput();

        if (textToDisplayBullet != null)
            textToDisplayBullet.SetText(bulletsLeft  + " / " + magazineSize);
    }
    private void MyInput()
    {

        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(canShoot){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.forward * bulletSpeed;
            bulletsLeft--;
            StartCoroutine(ShootDelay());
            Destroy(bullet, 2f);
        }   
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(timerBetweenEachShoot);
        canShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Debug.Log("Reloading...");

        Invoke("FinishReload", reloadTime);
    }

    private void FinishReload()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        Debug.Log("Reload finished. Bullets: " + bulletsLeft);
    }
}
