using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float increaseSpeedAmount = 0.01f;
    [SerializeField] float floorDestroyDelay = 10f;

    Vector3 direction;

    FloorSpawner floorSpawner;
    Score score;

    bool isBallFall;

    void Awake() 
    {
        floorSpawner = FindObjectOfType<FloorSpawner>();
        score = FindObjectOfType<Score>();
    }

    void Start()
    {
        isBallFall = false;
        direction = Vector3.forward;
    }

    void Update()
    {
        if(transform.position.y <= 0.65f)
            isBallFall = true;

        if(isBallFall)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            moveSpeed += increaseSpeedAmount * Time.deltaTime;
            if(direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }

    }

    void FixedUpdate() 
    {
        Vector3 newMove = direction * Time.deltaTime * moveSpeed;  
        transform.position += newMove;  
    }

    void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.CompareTag("Floor")) 
        { 
            score.IncreaseScore();
            other.gameObject.AddComponent<Rigidbody>();
            floorSpawner.SpawnFloor();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject, floorDestroyDelay);
        }
    }

    public bool GetIsBallFall()
    {
        return isBallFall;
    }

}
