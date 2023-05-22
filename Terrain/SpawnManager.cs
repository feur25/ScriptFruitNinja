using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Camera mainCamera;
    public Collider spawnArea;
    public GameObject[] fruitObjects;
    public static float maxTimeSpawn = 3f;
    public float minTimeSpawn = 1f;
    public float maxAngle = 0f;
    public float minAngle = 0f;
    public float maxJump = 0f;
    public float minJump = 0f;
    public float timeDestroy = 5f;
    private float SpawnIntervall;
    public static float PourcentageSpawn = 50f;
    public static float PourcentageSpawnItem;
    public static float PourcentageSpawnBomb = 3f;
    public static float MaxPourcentageSpawnGold = 45f;
    public static float MinPourcentageSpawnGold  = 35f;
    private float MaxSpawn = 0f;
    float maxX = 444f;
    float minX = 436f;
    private GameObject fruit;


    void Awake(){
        PourcentageSpawn = 50f;
        if(LevelManager.difficultyMode != 3){
            PourcentageSpawnBomb = 3f;
            MaxPourcentageSpawnGold = 45f;
            MinPourcentageSpawnGold = 35f;
        }else{
            PourcentageSpawnBomb = 37f;
            MaxPourcentageSpawnGold = 11f;
            MinPourcentageSpawnGold = 1f;
        }
        
        maxTimeSpawn = 0f;
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        GameObject prefab;
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            PourcentageSpawnItem=Random.Range(1,100);
            if(PourcentageSpawnItem<=PourcentageSpawnBomb)
            {
                prefab = fruitObjects[0];
            }
            else if(PourcentageSpawnItem <= MaxPourcentageSpawnGold && PourcentageSpawnItem >= MinPourcentageSpawnGold)
            {
                prefab = fruitObjects[1];
            }
            else
            {
                prefab = fruitObjects[Random.Range(2, fruitObjects.Length)];
            }
            Vector3 position = GetRandomPositionWithinBounds(spawnArea.bounds);
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            fruit = Instantiate(prefab, position, rotation);

            if (fruit.name == "Dead(Clone)")
            {
                CameraShake shake = fruit.AddComponent<CameraShake>();
                shake.cameraTransform = mainCamera.transform;
            }

            float force = Random.Range(minJump, maxJump);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
            Destroy(fruit, timeDestroy);
            SpawnIntervall= Random.Range(1,100);
            if (SpawnIntervall<=PourcentageSpawn && MaxSpawn<4)
            {
                MaxSpawn+=1;
                yield return new WaitForSeconds(0);
            }
            else
            {
                MaxSpawn=0;
                yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Destroy")
        {
            Destroy(fruit);
        }
    }

    private Vector3 GetRandomPositionWithinBounds(Bounds bounds)
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPosition;
    }
}
