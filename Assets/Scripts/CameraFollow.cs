using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    Vector3 distance;

    BallMovement ballMovement;

    void Awake() 
    {
        ballMovement = FindObjectOfType<BallMovement>();
    }

    void Start() 
    {
        distance = transform.position - followTarget.position;   
    }

    void Update() 
    {
        if(!ballMovement.GetIsBallFall()) { transform.position = followTarget.position + distance; }
    }

}
