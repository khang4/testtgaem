﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//aa bullet alpha, big bullet fired by gun
public class aaBulletA:MonoBehaviour
{
    Vector2 m_direction;

    float m_velocity=.1f;
    float m_minVelocity=.01f;
    float m_decceleration=.01f;

    int m_betaBulletsFired=10;

    public GameObject aaBulletB;

    // float m_spawnTime;

    void Start()
    {
        m_direction=GameObject.Find("player?").transform.position-transform.position;
        m_direction.Normalize();

        InvokeRepeating("updateVelocity",0,.5f);
        Invoke("explode",3);
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

    void explode()
    {
        Vector2 direction=Random.insideUnitCircle;
        float angle=360/m_betaBulletsFired;

        for (int x=0;x<m_betaBulletsFired;x++)
        {
            direction=Quaternion.Euler(0,0,angle)*direction;
            Instantiate(aaBulletB,transform.position,new Quaternion()).GetComponent<aaBulletB>().setDirection(direction);
        }

        Destroy(this.gameObject);
    }
}