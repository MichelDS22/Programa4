using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 8f;
    private Animator anim; // Bullet1 y Bullet2
    private bool bulletMove; //movimiento X    -X

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
     bulletMove = true;
     StartCoroutine(DisableBullet(0.5f));//desactivar bala
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (bulletMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        } }
    public float Speed
    {
        get
        {   return speed;   }
        set
        {   speed = value;  }
    }
    IEnumerator DisableBullet(float timer)
    {
     yield return new WaitForSeconds(timer);
     gameObject.SetActive(false); //ocultar
    } }