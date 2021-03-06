﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fbullet_a:MonoBehaviour
{
    Vector2 m_direction;
    public float m_speed=1;
    public GameObject FbulletB;

    void Start()
    {
        m_direction=Random.insideUnitCircle;

        InvokeRepeating("spawnBulletB",0,.3f);
    }

    void Update()
    {
        transform.Translate(m_direction*m_speed);

        checkBounds();
    }

    void checkBounds()
    {
        if (transform.position.x<-15)
        {
            m_direction=Random.insideUnitCircle;
            if (m_direction.x<0)
            {
                m_direction.x*=-1;
            }
        }

        else if (transform.position.x>0)
        {
            m_direction=Random.insideUnitCircle;
            if (m_direction.x>0)
            {
                m_direction.x*=-1;
            }
        }

        if (transform.position.y<-7)
        {
            m_direction=Random.insideUnitCircle;
            if (m_direction.y<0)
            {
                m_direction.y*=-1;
            }
        }

        else if (transform.position.y>7)
        {
            m_direction=Random.insideUnitCircle;
            if (m_direction.y>0)
            {
                m_direction.y*=-1;
            }
        }
    }

    void spawnBulletB()
    {
        Instantiate(FbulletB,transform.position,new Quaternion());
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.name=="player?")
        {
            Debug.Log("bullet hit");
        }
    }
}