using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    GameObject spawn;
    PlayerMove movement;

    int howManyColisions = 0;


    void Start (){
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
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

    void Restartcolisions(){
        howManyColisions = 0;
    }
}
