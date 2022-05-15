using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] internal DudesMovement dudesMovement;
    [SerializeField] internal DudesGunShoot dudesGunShoot;
    [SerializeField] internal DudesGunAim dudesAim;

    [Header("Player components")]
    internal Rigidbody2D rb2d;
    internal Animator anim;

    [Header("Dudes movement variables")]
    [SerializeField]internal float moveSpeed;
    internal Vector3 mousePos;
    internal Vector3 mouseWorldPos;

    [Header("Shooting variables")]
    [SerializeField] internal Vector2 fixedGroundVelocity;
    [SerializeField] internal float fixedVerticalVelocity;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        mousePos = Input.mousePosition;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
