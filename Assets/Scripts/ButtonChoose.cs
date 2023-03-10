using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MusicalNote{
    Do,Re,Mi,Fa,Sol,La,Si,Sos,B
}

public class ButtonChoose : MonoBehaviour
{
    MusicalNote choosenOne;

    // Start is called before the first frame update
    void Start()
    {
        choosenOne = MusicalNote.Do;
    }

    // Update is called once per frame
    void Update()
    {       
        Debug.Log("the note is: "+choosenOne);
    }


    public void setNoteSi(){
        choosenOne = MusicalNote.Si;
    }
}
