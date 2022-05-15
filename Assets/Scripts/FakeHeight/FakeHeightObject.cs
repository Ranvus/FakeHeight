using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FakeHeightObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onGroundHitEvent;

    [SerializeField] private Transform transObject;
    [SerializeField] private Transform transBody;
    [SerializeField] private Transform transShadow;

    [SerializeField] private float gravity = -10;
    [SerializeField] private Vector2 groundVelocity;
    [SerializeField] private float verticalVelocity;
    private float lastInitialVerticalVelocity;

    [SerializeField] private bool isGrounded;

    private void Update() {
        UpdatePosition();
        CheckGroundHit();
    }

    public void Initialize(Vector2 groundVelocity, float verticalVelocity){
        isGrounded = false;
        this.groundVelocity = groundVelocity;
        this.verticalVelocity = verticalVelocity;
        lastInitialVerticalVelocity = verticalVelocity;
    }

    private void UpdatePosition(){
        if(!isGrounded){
            verticalVelocity += gravity * Time.deltaTime;
            transBody.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime; 
        }
        transObject.position += (Vector3)groundVelocity * Time.deltaTime;
    }

    private void CheckGroundHit(){
        if(transBody.position.y < transObject.position.y && !isGrounded){
            transBody.position = transObject.position;
            isGrounded = true;
            GroundHit();
        }
    }

    private void GroundHit(){
        onGroundHitEvent.Invoke();
    }

    public void Stick(){
        groundVelocity = Vector2.zero;
    }

    public void Bounce(float divisionFactor){
        Initialize(groundVelocity, lastInitialVerticalVelocity / divisionFactor);
        groundVelocity = groundVelocity / divisionFactor;
    }
}
