using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmmissile:MonoBehaviour
{
    public Vector3 m_direction=new Vector3(0,1,0);
    public float m_initialTravelTime=.3f;
    float[] m_speedChanges={.01f,.05f};
    float m_speed;

    GameObject playerTarget;

    int m_flyMode=1;

    void Start()
    {
        m_speed=m_speedChanges[1];
        playerTarget=GameObject.Find("player?");

        StartCoroutine(flyModes());
    }

    void Update()
    {
        if (m_flyMode==0)
        {
            m_direction=Vector3.RotateTowards(m_direction,playerTarget.transform.position-transform.position,.01f,1);
            m_direction.Normalize();
            transform.Translate(m_direction*m_speed);
        }

        else if (m_flyMode==1)
        {
            m_direction.Normalize();
            transform.Translate(m_direction*m_speed);
        }
    }

    public void initialise(Vector3 direction,float initialTravelTime)
    {
        m_direction=direction;
        m_initialTravelTime=initialTravelTime;
    }

    IEnumerator flyModes()
    {
        yield return new WaitForSecondsRealtime(m_initialTravelTime);
        m_speed=m_speedChanges[0];
        yield return new WaitForSecondsRealtime(1.2f);
        m_speed=m_speedChanges[1];
        m_direction=playerTarget.transform.position-transform.position;
        m_direction=Quaternion.Euler(0,0,Random.Range(-50f,50f))*m_direction;
        m_flyMode=0;
    }
}
