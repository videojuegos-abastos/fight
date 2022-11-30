using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSSpawner : MonoBehaviour
{

    [SerializeField]
    Vector2 size;

    [SerializeField]
    GameObject objectToSpawn;

    [SerializeField]
    float spawnTime;

    void Start()
    {
        StartCoroutine( SpawnerCoroutine() );
    }

    void Update()
    {

        bool spacePressed = Input.GetKey(KeyCode.Space);

        if (spacePressed)
        {
            SpawnObject();
        }
        
    }

    void SpawnObject()
    {

        float rX = Random.Range(0, size.x) - size.x / 2;
        float rY = Random.Range(0, size.y) - size.y / 2;


        Instantiate(objectToSpawn, new Vector3(rX, rY, 0), Quaternion.identity, transform);
    }

    IEnumerator SpawnerCoroutine()
    {

        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnObject();
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, .1f));
    }
}
