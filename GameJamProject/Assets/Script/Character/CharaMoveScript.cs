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
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    private int extraJumpsValue;
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
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;
        #endregion

        #region Slide

        #endregion 

        #region Jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded == true)
        {
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


    }
}
