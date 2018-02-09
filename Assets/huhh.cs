using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huhh:MonoBehaviour
{
    public Rigidbody2D body;
    Vector2 m_velocity;
    float m_speedModifier;

    void Start()
    {
        body=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_speedModifier=4;
        }

        else
        {
            m_speedModifier=12;
        }

        m_velocity.Set(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if (body.position.x>0 && m_velocity.x>0)
        {
            m_velocity.x=0;
        }

        else if (body.position.x<-15 && m_velocity.x<0)
        {
            m_velocity.x=0;
        }

        if (body.position.y>7 && m_velocity.y>0)
        {
            m_velocity.y=0;
        }

        else if (body.position.y<-7 && m_velocity.y<0)
        {
            m_velocity.y=0;
        }

        m_velocity.Normalize();

        body.velocity=m_velocity*m_speedModifier;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hey");
    }
}
