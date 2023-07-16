using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    //집어 넣을 영상
    public UnityEngine.Video.VideoClip Target_Clip;
    public RenderTexture Target_Texture;
    public void Start()
    {
        //메인 카메라
        GameObject camera = GameObject.Find("Main Camera");

        //카메라 컴포넌트 가져옴
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        //프로그램이 실행과 동시에 영상이 송출될지 안될지 설정
        videoPlayer.playOnAwake = true;

        //렌더모드 설정인데 안건드려도 됨
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        //알파값 설정임 0~1인데, 투명도라고 생각하면 됨
        videoPlayer.targetCameraAlpha = 1F;

        //위에서 연결시켰던 클립과 텍스쳐를 호출 앤드 연결
        videoPlayer.clip = Target_Clip;
        videoPlayer.targetTexture = Target_Texture;

        //영상을 계속 반복시킬 것인지에 대해서인데 한번만 할거니까 false
        videoPlayer.isLooping = false;

        //이게 중요하다. loopPointReached에 추가할 함수가 곧 영상이 종료되고 실행될 함수이다.
        videoPlayer.loopPointReached += EndReached;

        //위 설정값들을 바탕으로 영상 송출
        videoPlayer.Play();
    }

    //매개변수로 꼭 VideoPlayer를 넣어줘야한다.
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        //Main이라는 이름의 Scene으로 이동한다는 거다.
        SceneManager.LoadScene("Main");
    }
}
