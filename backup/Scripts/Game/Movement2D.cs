/*
//PlayerAction.cs

using UnityEngine;


public class Movement2D : MonoBehaviour
{
    
    public float moveSpeed = 10f;
    public GameManager Manager; // 플레이어에서 맨저 함수를 호출 할 수 있게 변수 생성
    
    private Vector3 moveDirection = Vector3.zero;
    Rigidbody2D rb;
    // Animator anim;

    public float h, v; //수직, 수평
    public bool hDown, vDown, hUp, vUp;
    bool isHorizonMove; //수평이동인지 아닌지 플래그
    public bool isPressForMove;
    public bool isPressForAction;

    Vector3 dirVec; //현재 바라보고 있는 방향 값을 가진 변수가 필요
    GameObject scanObject; //스캔된 오브젝트

    public LayerMask Note; //선택한 레이어에 속한 객체들에 대해서만 레이캐스팅 검사를 진행하게 된다.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        //#Move Value
        
        h = Manager.isAction ? 0 : Input.GetAxisRaw("Horizontal"); //isAction이라는 플래그 값을 활용함.
        v = Manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        hDown = Manager.isAction ? false : Input.GetButtonDown("Horizontal"); 
        vDown = Manager.isAction ? false : Input.GetButtonDown("Vertical");
        hUp = Manager.isAction ? false : Input.GetButtonUp("Horizontal");
        vUp = Manager.isAction ? false : Input.GetButtonUp("Vertical");

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
        
            
        // if (Input.GetButtonDown("Jump") && scanObject != null) //보통 Jump는 Space바를 의미 && 오브젝트가 인식될 때
        //     Manager.Action(scanObject);
        
    }

    private void FixedUpdate()
    {
        //#Move
        if(Manager.pushCount >= 0){
            if(isPressForMove){
                Vector2 moveVec = isHorizonMove ? new Vector3(h, 0, 0) : new Vector3(0, v, 0); //플래그 변수(isHorizonMove) 하나로 수평, 수직이동을 결정 [삼항 연산자 사용]
                rb.velocity = moveVec * moveSpeed; //부드러운 움직임
            }
        }

        //충돌 감지 
        
        Debug.DrawRay(rb.position,dirVec * 0.7f, new Color(0,1,0)); // DrawRay(기준 위치, 쏘는 방향 * 길이, 색상)
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, dirVec, 0.7f, Note); // Raycast(기준 위치, 쏘는 방향, 길이, 인식할 레이어)

        if(rayHit.collider != null) //collider 값이 null이 아닐때 >> 즉, 뭔가 있을 때
        {
            scanObject = rayHit.collider.gameObject; //RayCast 된 오브젝트를 변수로 저장하여 활용!
        }
        else
        {
            scanObject = null; //없다면 그냥 null
        }
        Manager.Action(scanObject);
    }
}