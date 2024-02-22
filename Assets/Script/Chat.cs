using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public Image imagelona;
    public Text ChatText;
    public Text ChatTitle;

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        imagelona.enabled = false;
    }

    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }

    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        ChatTitle.text = narrator;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.08f);
        }

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("집사", "오늘 저녁에 주인님의 환영 만찬회가 있다."));
        yield return StartCoroutine(NormalChat("집사", "그러면 역할 분담을... 흠.. "));
        yield return StartCoroutine(NormalChat("집사", "간단한 테이블 정리는 신입 메이드를 시킬까?  "));
        yield return StartCoroutine(NormalChat("집사", "'로나야' "));
        imagelona.enabled = true;
        yield return StartCoroutine(NormalChat("신입 메이드 로나", "네!! 집사님!  "));
        yield return StartCoroutine(NormalChat("집사", "만찬회 때 사용 될 테이블 정리를 너에게 맡기마"));
        yield return StartCoroutine(NormalChat("신입 메이드 로나", "넵! 맡겨만 주세요! "));
        SceneManager.LoadScene("GameScene");
    }
}