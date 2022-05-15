using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudesGunAim : MonoBehaviour
{
    [SerializeField] private DudeScript dudeScript;

    [Header("Transform references")]
    [SerializeField] private Transform transGun;
    [SerializeField] private Transform transCrosshair;

    [SerializeField] private float crosshairRadius = 5f;

    [Header("Aiming variables")]
    private Vector3 aimDir;
    private float angle;
    internal Vector3 target;

    // Update is called once per frame
    private void Update()
    {
        GunRotate();
        GunFlip();
        GunAim();
    }

    private void GunRotate(){
        aimDir = Camera.main.WorldToScreenPoint(transGun.position);
        dudeScript.mousePos.x = dudeScript.mousePos.x - aimDir.x;
        dudeScript.mousePos.y = dudeScript.mousePos.y - aimDir.y;

        angle = Mathf.Atan2(dudeScript.mousePos.y, dudeScript.mousePos.x) * Mathf.Rad2Deg;
        transGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
    }

    private void GunFlip(){
        if(dudeScript.mouseWorldPos.x > transform.position.x)
        {
            transGun.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transGun.localScale = new Vector3(-1, -1, 1);
        }
    }

    private void GunAim(){
        float distanceToCrosshair = Vector2.Distance(dudeScript.mouseWorldPos, transform.position);
        Vector3 crosshairDirection = (dudeScript.mouseWorldPos - transform.position).normalized;

        Vector3 diff = (dudeScript.mouseWorldPos - transform.position).normalized;

        transCrosshair.rotation = Quaternion.Euler(0f, 0f, 0f); 
        if(distanceToCrosshair < crosshairRadius){
            target = dudeScript.mouseWorldPos;
        }else if(distanceToCrosshair >= crosshairRadius){
            target = transform.position + (crosshairDirection * crosshairRadius);
        }
        target.z = 1;
        transCrosshair.position = target;
    }

    void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(this.transform.position, crosshairRadius);
}

}
