using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabollicShoot : MonoBehaviour
{
    public int potencia;
    private float vX;
    private float vY;
    public Transform bulletSpawnPoint;// Where shoot the Bullet

    public GameObject point;

    public const float gravity = 9.81f;

    private float x;
    private float y;

    public float adjustAim;

    //--------------------
    public Transform py;

    // Start is called before the first frame update
    void Start()
    {
        py = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("CalculateBullet",0.1f);
    }

    void CalculateBullet(){
        vX = Mathf.Cos(Mathf.Round((-py.rotation.z+adjustAim) * 100) * Mathf.Deg2Rad) * potencia;
        vY = -Mathf.Sin(Mathf.Round((-py.rotation.z+adjustAim) * 100) * Mathf.Deg2Rad) * potencia;

        for(float t = 0.4f; t < 3.5f ; t += 0.2f){

            float xball = vX * t + x;
            float yball = 0.5f * (-gravity) * Mathf.Pow(t, 2) + vY * t + y;

            Instantiate(point, new Vector3(xball,yball,0), bulletSpawnPoint.rotation);

        }
    }

}
