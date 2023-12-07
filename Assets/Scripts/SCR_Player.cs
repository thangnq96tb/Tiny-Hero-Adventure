using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 500f;
    [SerializeField] float m_JumpForce = 500f;
    [SerializeField] LayerMask m_JumpableGround;

    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    private float dirX = 0f;
    private MovementState m_CurrentState = MovementState.IDLE;

    public enum MovementState
    {
        IDLE, 
        RUN, 
        JUMP, 
        FALL
    }    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * m_MoveSpeed * Time.deltaTime, player.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, m_JumpForce * Time.deltaTime);
        }
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if(dirX > 0)
        {
            m_CurrentState = MovementState.RUN;
            sprite.flipX = false;
        }    
        else if(dirX < 0)
        {
            m_CurrentState = MovementState.RUN;
            sprite.flipX = true;
        }    
        else
        {
            m_CurrentState = MovementState.IDLE;
        }    

        if(player.velocity.y > 0.1f)
        {
            m_CurrentState = MovementState.JUMP;
        }     
        else if(player.velocity.y < -0.1f)
        {
            m_CurrentState = MovementState.FALL;
        }

        anim.SetInteger("state", (int)m_CurrentState);
        Debug.Log($"Player state: {m_CurrentState.ToString()}: ");
    }    

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider2D.size.y, m_JumpableGround);
        return hit.collider != null;
    }    
}
