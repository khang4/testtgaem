using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aagun:MonoBehaviour
{
    public GameObject aaBulletA;
    public float m_firerate=3;

    void Start()
    {
        InvokeRepeating("fireaaBulletA",0,m_firerate);
    }

    void Update()
    {

    }

    void fireaaBulletA()
    {
        Instantiate(aaBulletA,transform.position,new Quaternion());
    }
}
