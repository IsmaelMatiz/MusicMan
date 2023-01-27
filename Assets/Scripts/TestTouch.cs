using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{

    private Touch tocaTeToca;
    private Vector2 positionCamera;
    private Vector2 changePositionCamera;
    [SerializeField] Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            tocaTeToca = Input.GetTouch(0);
            positionCamera = camera.ScreenToWorldPoint(tocaTeToca.position);

            Debug.Log("En x es: " + positionCamera.x);
            Debug.Log("En y es: " + positionCamera.y);
        }

    }
}
