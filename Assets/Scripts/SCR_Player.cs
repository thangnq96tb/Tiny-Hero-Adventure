using TinyHero;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 5f;
    [SerializeField] float m_JumpForce = 5f;
    [SerializeField] float m_Health = 10f;

    [SerializeField] TextMeshProUGUI m_HealthTXT;
    [SerializeField] LayerMask m_JumpableGround;


    protected Player m_Player;
    private Rigidbody2D playerRB;
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
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        m_Player = new Player();
        UpdateHealthInfo();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(dirX * m_MoveSpeed, playerRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, m_JumpForce);
        }
        UpdateAnimationState();

        if(m_Health <= 0f)
        {
            Die();
        }    
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

        if(playerRB.velocity.y > 0.1f)
        {
            m_CurrentState = MovementState.JUMP;
        }     
        else if(playerRB.velocity.y < -0.1f)
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

    public void TakeDamage(float damage)
    {
        m_Health -= damage;
        UpdateHealthInfo();
    }

    public void Heal(float health)
    {
        m_Health += health;
        UpdateHealthInfo();
    }

    public void UpdateHealthInfo()
    {
        m_HealthTXT.text = $"HP: {m_Health}"; 
    }    

    public void Die()
    {
        Instantiate(m_Player.GetDieVfx(), transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
 