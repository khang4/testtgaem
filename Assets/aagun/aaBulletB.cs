using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//aa bullet Beta, small bullet fired by exploding aa bullet Alpha
public class aaBulletB:MonoBehaviour
{
    public Vector2 m_direction;
    public float m_speed=.1f;

    void Start()
    {
        // m_direction=new Vector2(1,0);
    }

    void Update()
    {
        transform.Translate(m_direction*m_speed);
    }

    public void setDirection(Vector2 direction)
    {
        m_direction=direction;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag=="bulletcatcher")
        {
            Destroy(this.gameObject);
        }
    }
}