using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData : MonoBehaviour
{
    public int noteId; //노트의 ID
    public int noteLocation; //위치
    public int noteDirection; //방향

    //구조체 생성을 위해 매개변수 생성자를 작성
    public NoteData(int id, int location, int direction)
    {
        noteId = id;
        noteLocation = location;
        noteDirection = direction;
    }
}
