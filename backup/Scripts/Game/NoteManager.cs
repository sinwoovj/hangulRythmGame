/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "NoteManager", menuName = "Custom/NoteManager")]
public class NoteManager : ScriptableObject
{
    Dictionary<int, NoteData> noteList;

    private void OnEnable()
    {
        noteList = new Dictionary<int, NoteData>();
        GenerateData();
    }
    private void GenerateData(){
        noteList.Add(111, new NoteData(1, 1, 1)); // Giyeok, 시계방향(파란색), 우측상단
        noteList.Add(112, new NoteData(1, 1, 2)); // Giyeok, 시계방향(파란색), 우측하단
        noteList.Add(113, new NoteData(1, 1, 3)); // Giyeok, 시계방향(파란색), 좌측하단
        noteList.Add(114, new NoteData(1, 1, 4)); // Giyeok, 시계방향(파란색), 좌측상단
        noteList.Add(121, new NoteData(1, 2, 1)); // Giyeok, 반시계방향(빨간색), 우측상단
        noteList.Add(122, new NoteData(1, 2, 2)); // Giyeok, 반시계방향(빨간색), 우측하단
        noteList.Add(123, new NoteData(1, 2, 3)); // Giyeok, 반시계방향(빨간색), 좌측하단
        noteList.Add(124, new NoteData(1, 2, 4)); // Giyeok, 반시계방향(빨간색), 좌측상단

        noteList.Add(205, new NoteData(2, 0, 5)); // DiGeut, 없음, 상단
        noteList.Add(206, new NoteData(2, 0, 6)); // DiGeut, 없음, 좌측
        noteList.Add(207, new NoteData(2, 0, 7)); // DiGeut, 없음, 하단
        noteList.Add(208, new NoteData(2, 0, 8)); // DiGeut, 없음, 우측
        
        noteList.Add(311, new NoteData(3, 0, 1)); // RieUl, 시계방향(파란색), 상단
        noteList.Add(312, new NoteData(3, 0, 2)); // RieUl, 시계방향(파란색), 좌측
        noteList.Add(321, new NoteData(3, 0, 3)); // RieUl, 반시계방향(빨간색), 하단
        noteList.Add(322, new NoteData(3, 0, 4)); // RieUl, 반시계방향(빨간색), 우측

        noteList.Add(405, new NoteData(4, 0, 5)); // SiOt, 없음, 우측
        noteList.Add(406, new NoteData(4, 0, 6)); // SiOt, 없음, 좌측
        noteList.Add(407, new NoteData(4, 0, 7)); // SiOt, 없음, 상단
        noteList.Add(408, new NoteData(4, 0, 8)); // SiOt, 없음, 하단

        noteList.Add(500, new NoteData(5, 0, 0)); // IEung, 없음, 없음

        noteList.Add(605, new NoteData(6, 0, 5)); // BiEup, 없음, 우측
        noteList.Add(606, new NoteData(6, 0, 6)); // BiEup, 없음, 좌측
        noteList.Add(607, new NoteData(6, 0, 7)); // BiEup, 없음, 상단
        noteList.Add(608, new NoteData(6, 0, 8)); // BiEup, 없음, 하단

        noteList.Add(700, new NoteData(7, 0, 0)); // TaeGeuk, 없음, 없음
    }

    public void NoteInteraction(){
        
    }
}
