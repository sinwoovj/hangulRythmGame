using UnityEngine;

public class DontDestoryObject : MonoBehaviour
{
    GameObject CurrentStageScore;
    private void Awake()
    {
        DontDestroyOnLoad(CurrentStageScore);
    }
}
