using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMoveScript : MonoBehaviour
{
    #region MoveElements
    public float moveSpeed = 8;
    public float jumpForce;
    public float slideForce = 10;
    #endregion

    #region MultipleJump
    public bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private int extraJumpsValue;
    #endregion

    #region WallJump
    bool isTouchingFront;
    bool isTouchingBack;
    public bool wallJumping;

    public LayerMask whatIsWall;
    public Transform frontCheck;
    public Transform backCheck;

    public float wallJumpTime;
    #endregion

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        jumpForce = 6;

        #region Movements
        float moves = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moves, 0, 0) * Time.deltaTime * moveSpeed;

            #endregion

            #region Slide

            #endregion

            #region Jump
            #region Multiple Jump
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded == false)
        {
            //anim saut est fausse
        }
        if(isGrounded == true)
        {
            //anim saut est vraie
            extraJumps = 1;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }

        else if (extraJumps == 1 && isGrounded == false)
        {
            jumpForce = 12;
        }
        #endregion
        #region WallJump
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsWall);
        isTouchingBack = Physics2D.OverlapCircle(backCheck.position, checkRadius, whatIsWall);

        if (isTouchingFront == true && isGrounded == false)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (isTouchingBack == true && isGrounded == false)
        {
            wallJumping = true;
             Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping == true)
        {
            extraJumps = 1;
        }
        #endregion
        #endregion


    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}
