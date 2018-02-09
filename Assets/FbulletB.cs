using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbulletB:MonoBehaviour
{
    Vector2 m_direction;
    public float m_speed=.01f;

    void Start()
    {
        m_direction=GameObject.Find("player?").transform.position-transform.position;
        m_direction.Normalize();
    }

    void Update()
    {
        transform.Translate(m_direction*m_speed);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag=="bulletcatcher")
        {
            Destroy(this.gameObject);
        }

        else if (trigger.name=="player?")
        {
            Debug.Log("mini bullet hit");
        }
    }
}
