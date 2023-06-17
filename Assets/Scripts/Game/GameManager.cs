using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int bpm = 0;
    double currenTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    void Update()
    {
        currenTime += Time.deltaTime;
        
        if(currenTime >= 60d / bpm){
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            currenTime = 60d / bpm;
        }
    }
}
