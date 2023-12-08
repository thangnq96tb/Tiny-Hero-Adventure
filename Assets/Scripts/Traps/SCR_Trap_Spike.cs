using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Trap_Spike : MonoBehaviour
{
    [SerializeField] float m_Damage = 1f;
    [SerializeField] float m_DamagePerSecond = 0.2f;

    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GameConstant.TAG_PLAYER)
        {
            collision.GetComponent<SCR_Player>().TakeDamage(m_Damage);
        }    
    }

    void Attack(SCR_Player player)
    {
        player.TakeDamage(m_Damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == GameConstant.TAG_PLAYER)
        {
            countTime += Time.deltaTime;
            if (countTime >= 1.0f)
            {
                collision.GetComponent<SCR_Player>().TakeDamage(m_DamagePerSecond);
                countTime -= 1.0f;
            }
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        countTime = 0f;
    }
}
