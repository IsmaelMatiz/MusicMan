using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketController : MonoBehaviour
{
    public LayerMask limit;
    [SerializeField]int speedMovement;
    bool isLookingUp; // save the previous Y position from this object

    // Start is called before the first frame update
    void Start()
    {
        isLookingUp = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isInBorder()){
            changeMove();
        }

        //if the goal go down reduce the position in Y else increase it
        if (isLookingUp){
            transform.position += new Vector3(0,  1,  0) * speedMovement * Time.deltaTime;
        }else{
            //transform.position += transform.down * speedMovement * Time.deltaTime;
            transform.position += new Vector3(0,  -1,  0) * speedMovement * Time.deltaTime;
        }
    

        Debug.DrawRay(this.transform.position, Vector2.up*4.0f, Color.blue);
        Debug.DrawRay(this.transform.position, Vector2.down*4.0f, Color.blue);

    }

    // if the goal touch the border swap movement
        void changeMove(){
        Debug.Log("Se ejecuto el move");
        if(isLookingUp == true){
            isLookingUp = false;
            Debug.Log("is looking ahora es false");
        }else{ 
            isLookingUp = true;
            Debug.Log("is looking ahora es true");
        }
        }

    //return if the goal is near to the border
    bool isInBorder(){
        if (Physics2D.Raycast(this.transform.position,Vector2.up,4.0f,limit)){
            Debug.Log(" Si Toco Borde");
            return true;
        }
        if (Physics2D.Raycast(this.transform.position,Vector2.down,4.0f,limit)){
            Debug.Log(" Si Toco Borde");
            return true;
        }else{
            return false;
        }
    }
}
