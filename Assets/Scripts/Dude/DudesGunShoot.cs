using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudesGunShoot : MonoBehaviour
{
    [SerializeField] private DudeScript dudeScript;

    [Header("References")]
    [SerializeField] private Transform transGunTip;
    [SerializeField] private GameObject melon;

    private void Update() {
        Shoot();
    }

    private void Shoot(){
        if(Input.GetMouseButtonDown(0)){
            GameObject instantiatedMelon = Instantiate(melon, transGunTip.position, Quaternion.identity);
            instantiatedMelon.GetComponent<FakeHeightObject>().Initialize( new Vector2(transform.right.x * Mathf.Abs(dudeScript.dudesAim.target.x), transform.right.y * Mathf.Abs(dudeScript.dudesAim.target.y)), dudeScript.fixedVerticalVelocity);
        }
    }
}