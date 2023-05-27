using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameManager Manager; // 플레이어에서 먼저 함수를 호출 할 수 있게 변수 생성
    public Vector3 moveDirection = Vector3.zero;
    Rigidbody2D rb;
    public Text PushCount;

    public int value = 0;
    public bool isKeyPressed = false;
    

    public float h, v; //수직, 수평
    public bool hDown, vDown, hUp, vUp;
    bool isHorizonMove; //수평이동인지 아닌지 플래그

    Vector3 dirVec; //현재 바라보고 있는 방향 값을 가진 변수가 필요
    GameObject scanObject; //스캔된 오브젝트
    public LayerMask Note; //선택한 레이어에 속한 객체들에 대해서만 레이캐스팅 검사를 진행하게 된다.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(int.Parse(PushCount.text) == 0) PushCount.gameObject.SetActive(false);
        else PushCount.gameObject.SetActive(true);
        //#Move Value
        h = Manager.isAction ? 0 : Input.GetAxisRaw("Horizontal"); //isAction이라는 플래그 값을 활용함.
        v = Manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        hDown = Manager.isAction ? false : Input.GetAxisRaw("Horizontal") != 0;
        vDown = Manager.isAction ? false : Input.GetAxisRaw("Vertical") != 0;
        hUp = Manager.isAction ? false : Input.GetAxisRaw("Horizontal") == 0;
        vUp = Manager.isAction ? false : Input.GetAxisRaw("Vertical") == 0;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (!isKeyPressed)
            {
                // 텍스트 값을 숫자로 변환
                int currentValue = int.Parse(PushCount.text);

                // 1을 더한 값을 다시 문자열로 변환하여 텍스트에 설정
                PushCount.text = (currentValue + 1).ToString();
            }
            isKeyPressed = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {
            isKeyPressed = false;
        }

        //#수평 이동 체크

            if (hDown) //수평 키를 누르거나 수직 키를 뗄 때
                isHorizonMove = true;
            else if (vDown) //수직 키를 누르거나 수평 키를 뗄 때
                isHorizonMove = false;
            else if (hUp || vUp)
                isHorizonMove = h != 0; //동시 키 입력 오류 방지 >> 현재 AxisRaw 값에 따라 수평, 수직 판단하여 해결

            //Direction
            if (vDown && v == 1) //수직이동 키를 눌렀을 때, v값이 1이 될때이므로 상단 이동 키를 눌렀을 때.
                dirVec = Vector3.up; //현재 바라보고 있는 방향의 값을 위로 설정
            else if (vDown && v == -1)
                dirVec = Vector3.down;
            else if (hDown && h == 1)
                dirVec = Vector3.right;
            else if (hDown && h == -1)
                dirVec = Vector3.left;
    }

    private void OnCollisionEnter(Collision collision)
    {
        scanObject = collision.gameObject;
        // 여기에서 필요한 작업 수행
    }

    private void FixedUpdate()
    {
        //#Move
        if(Manager.pushCount >= 0){
            if(isKeyPressed){
                Vector2 moveVec = isHorizonMove ? new Vector3(h, 0, 0) : new Vector3(0, v, 0); //플래그 변수(isHorizonMove) 하나로 수평, 수직이동을 결정 [삼항 연산자 사용]
                rb.velocity = moveVec * moveSpeed; //부드러운 움직임
            }
        }

        Manager.Action(scanObject);
    }
}
