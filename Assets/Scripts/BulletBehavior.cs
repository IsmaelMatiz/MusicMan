using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    GameObject spawn;
    PlayerMove movement;
    ParabollicShoot parabollic;
    float t;
    private float x;
    private float y;
    const float gravity = 9.81f;

    int howManyColisions = 0;


    void Start (){
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        parabollic = GameObject.FindGameObjectWithTag("Player").GetComponent<ParabollicShoot>();
        t = 0;
        x = transform.position.x;
        y = transform.position.y;
    }

    void FixedUpdate(){
        float vX = Mathf.Cos(Mathf.Round((-parabollic.py.rotation.z+parabollic.adjustAim) * 100) * Mathf.Deg2Rad) * parabollic.potencia;
        float vY = -Mathf.Sin(Mathf.Round((-parabollic.py.rotation.z+parabollic.adjustAim) * 100) * Mathf.Deg2Rad) * parabollic.potencia;
        Invoke("increaseTime",1);
        float xball = vX * t + x;
        float yball = 0.5f * (-gravity) * Mathf.Pow(t, 2) + vY * t + y;

        transform.position  = new Vector3(xball,yball,0);
    }

    void OnCollisionEnter2D(Collision2D collision){
        Invoke("EnableShoot", 2.5f);
        Invoke("Restartcolisions", 5f);
        Destroy(gameObject,5);
    }

    void EnableShoot(){
            if(howManyColisions == 0) {
                movement.Shoot();
                howManyColisions++;
            }
    }

    void increaseTime(){
        t += 0.009f; 
    }

    void Restartcolisions(){
        howManyColisions = 0;
    }
}
