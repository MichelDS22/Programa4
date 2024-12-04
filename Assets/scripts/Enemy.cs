using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; //variar
    private Rigidbody2D ERB;
    private Animator Eanim;  
    private bool moveLeft; //Espejo
    public Transform down_Collision;//detecta el suelo
    public Transform top_Collision;// detecta al player
    private bool Move;
    private bool Sleep;
    public LayerMask PlayerLayer;

    public int EnemyType;

    public bool muerte = false;

    void Awake()
    {
        ERB = GetComponent<Rigidbody2D>();
        Eanim = GetComponent<Animator>();
    }
    void Start()
    {
        moveLeft = true;
        Move = true;
    }
    void Update()
    {
     if (Move)
      {
       if (moveLeft)
        {
    ERB.velocity = 
    new Vector2(-moveSpeed, ERB.velocity.y);//izq
            }
            else
            {
    ERB.velocity = new Vector2(moveSpeed, ERB.velocity.y);//derecha
            }
        }
        CheckCollision();
    }
    void CheckCollision()
    {
    Collider2D topHit = Physics2D.OverlapCircle //dibujar círculo
    (top_Collision.position, 0.2f, PlayerLayer);
      if (topHit != null)
        {
        if (topHit.gameObject.tag == "Player")
        {
           if (!Sleep)     
              { 
            topHit.gameObject.GetComponent
           <Rigidbody2D>().velocity =
           new Vector2(topHit.gameObject.GetComponent
           <Rigidbody2D>().velocity.x, 10f);// efecto resorte
                    Move = false; //stop 
                    ERB.velocity = new Vector2(0, 0);
                    Eanim.Play("E_Sleep"); //rojo
                    muerte = true;
                    Sleep = true; // detener   
                } } }
        if (!Physics2D.Raycast
            (down_Collision.position, Vector2.down, 0.9f) && muerte == false)
        {  
            ChangeDirection();
        }
        if (EnemyType == 2)
        {
            if (gameObject.tag == "Bullet")
            {
                muerte = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" && EnemyType == 2)
            gameObject.SetActive(false);
    }
    void ChangeDirection()
    {
        
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);//izq
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);//derecha
        }
        transform.localScale = tempScale;
        
    } }