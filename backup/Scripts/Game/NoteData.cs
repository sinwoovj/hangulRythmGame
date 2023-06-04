using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData : MonoBehaviour
{
    public string n_name;
    public string n_direction;
    public string n_location;

    enum noteName { //노트의 이름
        NONE, 
        GiYeok,
        DiGeut, 
        RieUl, 
        SiOt,
        IEung,
        BiEup,
        TaeGeuk,
        KEYCOUNT
    };
    
    enum noteDirection { //방향
        NONE, 
        LEFT, 
        RIGHT, 
        KEYCOUNT}; 

    enum noteLocation { //위치
        NONE, 
        RIGHT_UP,
        RIGHT_DOWN,
        LEFT_DOWN,
        LEFT_UP,
        UP, 
        LEFT, 
        DOWN, 
        RIGHT, 
        KEYCOUNT
    };

    //구조체 생성을 위해 매개변수 생성자를 작성
    public NoteData(int name, int direction, int location)
    {
        n_name = noteName.GetName(typeof(noteName), name);
        n_direction = noteDirection.GetName(typeof(noteDirection), direction);
        n_location = noteLocation.GetName(typeof(noteLocation), location);
    }
}
