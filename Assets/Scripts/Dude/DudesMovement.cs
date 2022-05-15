using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudesMovement : MonoBehaviour
{
    [SerializeField] private DudeScript dudeScript;

    [Header("Movement variables")]
    private Vector2 movement;

    [Header("Jump variables")]
    [SerializeField] private Transform transDudesSprite;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float gravityScale;
    private float velocity;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        AnimateCharacter();
        FlipCharacter();

        isGrounded = false;

        GroundCheck();
        Jump();
    }

    private void FixedUpdate() {
        dudeScript.rb2d.velocity = movement.normalized * dudeScript.moveSpeed * Time.deltaTime;
        
    }

    private void FlipCharacter(){

        if(dudeScript.mouseWorldPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void AnimateCharacter(){
        if(movement.x != 0 || movement.y != 0){
            dudeScript.anim.SetBool("isRunning", true);
        }
        else {
            dudeScript.anim.SetBool("isRunning", false);
        }
    }
    
    private void GroundCheck(){
        if(transDudesSprite.position.y < transform.position.y && !isGrounded){
            isGrounded = true;
        }
    }

    private void Jump(){
        velocity += gravity * gravityScale * Time.deltaTime;
        if(isGrounded && velocity < 0){
            velocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity = jumpForce;
        }
        transDudesSprite.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}
