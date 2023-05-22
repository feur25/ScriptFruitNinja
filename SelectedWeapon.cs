using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWeapon : MonoBehaviour
{
    public GameObject gun;

    public  void DestroyItem(){
        Destroy(gun.gameObject);
    }
}
