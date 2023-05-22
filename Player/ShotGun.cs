using System.Collections;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;   
    public float fireRate = 1f;   
    public int bulletsPerShot = 8;    
    public float reloadTime = 0.1f;  

    private bool isReloading = false; 

    void Update(){
        if(Input.GetKey(KeyCode.Mouse0)){
            Shoot();
        }
    }
    public void Shoot()
    {
        if (!isReloading)
        {
            for (int i = 0; i < bulletsPerShot; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = transform.right * 10;
            }
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
}