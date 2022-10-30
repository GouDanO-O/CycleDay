using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;

    [SerializeField] private float playerJumpHeight;

    [SerializeField] private LayerMask ground;

    private bool playerIsOnGround;

    private CapsuleCollider2D capsuleCollider2D;

    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float hor= Input.GetAxis("Horizontal")*playerMoveSpeed;       
        if(hor<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(hor>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetButtonDown("Jump")&&IsGroundCheck())
        {
            rigidbody2D.velocity=new Vector2(rigidbody2D.velocity.x, playerJumpHeight);
        }
        rigidbody2D.velocity = new Vector2(hor * playerMoveSpeed, rigidbody2D.velocity.y);
    }
    private bool IsGroundCheck()
    {       
        if (capsuleCollider2D.IsTouchingLayers(ground))
        {
            playerIsOnGround = true;
        }
        else
        {
            playerIsOnGround = false;
        }
        return playerIsOnGround;
    }
}
