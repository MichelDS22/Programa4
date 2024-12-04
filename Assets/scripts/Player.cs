using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Player : MonoBehaviour
{
 
    Rigidbody2D PlayerRB;
    public float PSpeed = 6f;
    Animator Panim;
    public Transform groundcheck;
    public LayerMask groundlayer;
    private bool isGround;
    private bool jumped;
    private float jumpPower = 7f;

    public TextMeshProUGUI monedas;
    public int TotalMonedas;

    void Start()
    {
       PlayerRB = GetComponent<Rigidbody2D>();
       Panim = GetComponent<Animator>();
       UpdateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }
    private void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            PlayerRB.velocity = new Vector2(PSpeed, PlayerRB.velocity.y);
            ChangeDirection(1);
        }
        else if (h < 0)
        {
            PlayerRB.velocity = new Vector2(-PSpeed, PlayerRB.velocity.y);
            ChangeDirection(-1);
        }
        else
        {
            PlayerRB.velocity = new Vector2(0f, PlayerRB.velocity.y);
        }
        Panim.SetInteger("Speed", Mathf.Abs((int)PlayerRB.velocity.x));
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
    void CheckIfGrounded()
    {
        isGround = Physics2D.Raycast(groundcheck.position, Vector2.down, 0.2f, groundlayer);
        if (isGround)
        {
            if (jumped)
            {
                jumped = false;
                Panim.SetBool("Jump", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            TotalMonedas += 1;
            monedas.text = " " + TotalMonedas.ToString();
        }
    }

    void UpdateCoin()
    {
        
    }


    void PlayerJump()
    {
        if (isGround)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpPower);
                Panim.SetBool("Jump", true);
            }
        }
    }

}
