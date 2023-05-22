using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PlayerController
{
    public GameObject Whole;
    public GameObject Slash;

    public int AddPointScoreBoard;

    public static bool shake;


    private Rigidbody item;
    private Collider itemCollider;

    private ParticleSystem ItemEffect;

    SpecialFruitScript FruitEffect = new SpecialFruitScript();


    Bullet getBullet = new Bullet();

    ProjectileWeapon1 getWeapon = new ProjectileWeapon1();

    public AudioSource audioSource;


    private void Awake()
    {
        item = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
        ItemEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        Whole?.SetActive(false);
        Slash?.SetActive(true);

        itemCollider.enabled= false;

        ItemEffect?.Play();

        float angle=Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
        Slash.transform.rotation= Quaternion.Euler(0f,0f,angle);
        Rigidbody[] Slash2= Slash.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in Slash2)
        {
            slice.velocity= item.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void CheckCutBall(){
        if(AddPointScoreBoard >= 0) {

            if(SpecialFruitScript.doublePoints){
                CurrentPoint += AddPointScoreBoard * 2;  
            }else if(SpecialFruitScript.halfPoints){
                CurrentPoint += AddPointScoreBoard / 2;
            }else{
                CurrentPoint += AddPointScoreBoard;
            }

            YouCanAddPoint = true;
            shake = false;
        }else{
            CurrentLife -= 1;
            shake = true;
        }
    }

    public IEnumerator UpdateTimeScale()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        SpecialFruitScript.slowTime = false;
    }

    
    public IEnumerator ResetDoublePoints(){
        yield return new WaitForSeconds(4f);
        SpecialFruitScript.doublePoints = false;
    }

    public IEnumerator ResetHalfPoints(){
        yield return new WaitForSeconds(4f);
        SpecialFruitScript.halfPoints = false;
    }
    public IEnumerator ResetBulletSize(){
        yield return new WaitForSeconds(2f);
        getBullet.ScaleDecreaseResolution();
    }

    public IEnumerator ResetEffectWeapon(){
        yield return new WaitForSeconds(2f);
        getWeapon.ResetBestWeaponEffect();
    }

    private void StartCoroutineEffectFruit(){
        if(Bullet.modifyScale){
            StartCoroutine(ResetBulletSize());
        }
        if(SpecialFruitScript.weaponCheat){
            StartCoroutine(ResetEffectWeapon());
        }
        if(SpecialFruitScript.slowTime){
            StartCoroutine(UpdateTimeScale());
        }
        if(SpecialFruitScript.doublePoints){
            StartCoroutine(ResetDoublePoints());
        }
        if(SpecialFruitScript.halfPoints){
            StartCoroutine(ResetHalfPoints());
        }
    }

    private void OnTriggerEnter(Collider saber)
    {
        Rigidbody rigidbody = GetComponent<Collider>().attachedRigidbody;
        if (rigidbody != null && saber.CompareTag("Player"))
        {
            if(rigidbody.gameObject.name != "Dead(Clone)"){
                FruitEffect.OnSpecialFruitHit();
                StartCoroutineEffectFruit();
            }
            
            if(saber.gameObject.name == "sword"){
                Sword sword = saber.GetComponent<Sword>();
                Slice(sword.direction, sword.transform.position, sword.SliceForce);
                audioSource?.Play();
            }else{
                Destroy(rigidbody.gameObject, 0f);
            }
            CheckCutBall();
        }
    }
}