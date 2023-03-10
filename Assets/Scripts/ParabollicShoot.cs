using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabollicShoot : MonoBehaviour
{
    public int potencia;
    private float vX;
    private float vY;
    public Transform bulletSpawnPoint;// Where shoot the Bullet

    public const float gravity = 9.81f;

    //--------------------
    private PlayerMove py;

    // Start is called before the first frame update
    void Start()
    {
        vX = Mathf.Cos(Mathf.Deg2Rad());
        
    }

    // Update is called once per frame
    void Update()
    {
        py = new PlayerMove();
    }
}
