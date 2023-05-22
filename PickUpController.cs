using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{

    public int distanceToItem;
    public Camera Camera;
    public GameObject shootGun;
    public GameObject AK_47;

    public bool youCanPickUp = false;

    public static bool WeaponChoice = false;

    void Start()
    {
        Camera = Camera.main;
        WeaponChoice = false;
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !youCanPickUp){
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 1f)){
                if(hitinfo.collider.gameObject.name == "Shootgun"){
                    youCanPickUp = true;
                    WeaponChoice = true;
                    Destroy(shootGun.gameObject);
                }else if(hitinfo.collider.gameObject.name == "AK_47"){
                    youCanPickUp = true;
                    WeaponChoice = false;
                    Destroy(AK_47.gameObject);
                }
            }
        }
    }
}
