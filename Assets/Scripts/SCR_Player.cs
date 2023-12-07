using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 5f;

    private Rigidbody2D player;
    private float dirX = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * m_MoveSpeed, player.velocity.y);
    }
}
