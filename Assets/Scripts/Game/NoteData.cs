using UnityEngine;

public class NoteData : MonoBehaviour
{   
    [SerializeField]
    public string n_name;
    public string n_direction;
    public string n_location;

    //구조체 생성을 위해 매개변수 생성자를 작성
    public void NoteCreate(int name, int direction, int location)
    {
        n_name = NoteName.GetName(typeof(NoteName), name);
        n_direction = NoteDirection.GetName(typeof(NoteDirection), direction);
        n_location = NoteLocation.GetName(typeof(NoteLocation), location);
    }
}
