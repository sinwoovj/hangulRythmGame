using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; // UI 프로그래밍 전에 꼭 먼저 UnityEngine.UI를 넣어야함.
using UnityEngine.SceneManagement; // 씬 이동

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject scanObject; //플레이어가 조사를 했던 오브젝트
    public GameObject player;
    public bool isAction = false; //상태 저장용 변수
    public bool isPush; //판정
    public int pushCount; //pushCount 기능으로 방향 변환 가능 횟수 지정

    private void Awake(){
        pushCount = 1;
    }
    private void Update()
    {
        //#Sub Menu
        
        if (Input.GetButtonDown("Cancel")){
            //ESC키로 메뉴를 켜고 끄기 가능하도록 작성
            if (!isAction)
            {
                menuSet.SetActive(true);
                isAction = true;
            }
            else{
                menuSet.SetActive(false);
                isAction = false;
            }
        }
    }
    public void Action(GameObject scanObj)
    {  
        if(player.GetComponent<Movement>().isKeyPressed){
            //아무런 오브젝트도 인식되지 않았을 때
            if(scanObj==null){
                player.GetComponent<Movement>().PushCount.text="0";
                pushCount--; 
            }   
            else{
                ObjData objData = scanObj.GetComponent<ObjData>();
                Judgement(objData.id);
                pushCount--;
            }
            //pushcount가 0이거나 이하일 때
            if(pushCount<=0)    GameOver();
        }        
    }
    public void Judgement(int id){
        Debug.Log(id);

        pushCount++;
    }

    public void GameOver(){
        Debug.Log("Game Over");
        isAction = true;
    }

    internal void Spacebar(GameObject scanObject)
    {
        throw new NotImplementedException();
    }

    //충돌한 오브젝트의 id를 들고와서 알맞은 방향을 눌렀으면 넘어감. 
    //판정 추가해서 너무 빠르거나 느리게 눌렀으면 그에 따른 결과값 산출과 못눌렀으면 miss값 보내고 게임 오버 시킴(게임오버 창 뜨고 10초 후 리스타트)
}
