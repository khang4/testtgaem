using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//aa bullet alpha, big bullet fired by gun
public class aaBulletA:MonoBehaviour
{
    Vector2 m_direction;

    float m_velocity=.1f;
    float m_minVelocity=.01f;
    float m_decceleration=.01f;

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
        GameObject newBullet;
        aaBulletB bulletComp;

        newBullet=Instantiate(aaBulletB,transform.position,new Quaternion()) as GameObject;
        bulletComp=newBullet.GetComponent<aaBulletB>();
        bulletComp.setDirection(new float[2]{0,1});

        newBullet=Instantiate(aaBulletB,transform.position,new Quaternion()) as GameObject;
        bulletComp=newBullet.GetComponent<aaBulletB>();
        bulletComp.setDirection(new float[2]{0,-1});

        newBullet=Instantiate(aaBulletB,transform.position,new Quaternion()) as GameObject;
        bulletComp=newBullet.GetComponent<aaBulletB>();
        bulletComp.setDirection(new float[2]{1,0});

        newBullet=Instantiate(aaBulletB,transform.position,new Quaternion()) as GameObject;
        bulletComp=newBullet.GetComponent<aaBulletB>();
        bulletComp.setDirection(new float[2]{-1,0});

        Destroy(this.gameObject);
    }
}