using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmlauncher:MonoBehaviour
{
    public GameObject tmmissile;

    void Start()
    {
        InvokeRepeating("continuousLaunch",0,3);
    }

    void Update()
    {

    }

    void continuousLaunch()
    {
        StartCoroutine(launchMissiles());
    }

    IEnumerator launchMissiles()
    {
        Vector3 direction=new Vector3(0,1,0);
        // direction.Normalize();
        for (var x=0;x<4;x++)
        {
            Instantiate(tmmissile,transform.position,
            new Quaternion()).GetComponent<tmmissile>().initialise(Quaternion.Euler(0,0,
            Random.Range(-45f,45f))*direction,Random.Range(.2f,.5f));
            yield return new WaitForSecondsRealtime(.2f);
        }
    }
}
