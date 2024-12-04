using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PBullet; //prefab

    void Update()
    {
        Shooter();
    }
  void Shooter()
   {
   if (Input.GetKeyUp(KeyCode.L))//
    { 
     GameObject bullet = Instantiate//obj,pos,rotacion
     (PBullet, transform.position, 
     Quaternion.identity);
     bullet.GetComponent<FireBullet>//codigo
     ().Speed *= transform.localScale.x; //disparar X y -X espejo
        } } }