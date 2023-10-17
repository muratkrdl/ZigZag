using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] GameObject lastFloor;

    void Start() 
    {
        for(int i = 0; i < 30; i++)
        {
            SpawnFloor();
        }
    }

    public void SpawnFloor()
    {
        Vector3 randomVector;
        if(Random.Range(0,2) == 0) { randomVector = Vector3.forward; }
        else { randomVector = Vector3.left; } 

        var newLastFloor = Instantiate(lastFloor, lastFloor.transform.position + randomVector, lastFloor.transform.rotation);
        lastFloor = newLastFloor;
    }

}
