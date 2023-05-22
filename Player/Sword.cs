using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Camera MainCamera;
    private Collider SwordCollider;

    private bool Slice;

    public float SliceForce= 5f, MinPositionSlice = 0.01f;

    private TrailRenderer SlashSword;

    private Vector3 Position = new Vector3();
    public Vector3 direction {get; set;}

    // Start is called before the first frame update
    private void Awake()
    {
        MainCamera = Camera.main;
        SwordCollider = GetComponent<Collider>();
        SlashSword = GetComponentInChildren<TrailRenderer>();
    }
    void PositionCamera(){
        Position = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Position.z = 0f;
    }

    private void OnEnable()
    {
        StopSlicing();
    }
    private void OnDisable()
    {
        StopSlicing();
    }
    private void MyInputSlashing(){
        if(Input.GetMouseButtonDown(0))
            StartSlicing();
        if (Input.GetMouseButtonUp(0))
            StopSlicing(); 
        if (Slice)
            Slicing();
            
    }

    void Update(){ MyInputSlashing(); }

    private void ModifyBoolVariable(bool myBool){
        Slice = myBool;
        SwordCollider.enabled = myBool;
    }

    private void StartSlicing(bool start = true)
    {
        ModifyBoolVariable(start);
        transform.position = Position;
    }

    private void StopSlicing(bool stop = false)
    {
        ModifyBoolVariable(stop);
    }

    private void Slicing()
    {
        PositionCamera();
        direction= Position-transform.position;
        float velocity = direction.magnitude/ Time.deltaTime;
        SwordCollider.enabled = velocity > MinPositionSlice;
        transform.position = Position;
    }
}
