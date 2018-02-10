using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaBulletA:MonoBehaviour
{
    Vector2 m_direction;
    float m_velocity=.1f;
    float m_minVelocity=.01f;
    float m_decceleration=.03f;
    // float m_spawnTime;

    void Start()
    {
        m_direction=GameObject.Find("player?").transform.position-transform.position;
        m_direction.Normalize();

        InvokeRepeating("updateVelocity",0,.5f);

        // m_spawnTime=Time.time;
    }

    void Update()
    {
        transform.Translate(m_direction*m_velocity);
    }

    void updateVelocity()
    {
        if (m_velocity>m_minVelocity)
        {
            m_velocity-=m_decceleration;
        }

        else
        {
            m_velocity=m_minVelocity;
        }
    }
}