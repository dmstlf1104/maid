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

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű
    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        imagelona.enabled = false;
    }

    void Update()
    {
        foreach (var element in skipButton) // ��ư �˻�
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

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.08f);
        }

        //Ű�� �ٽ� ���� �� ���� ������ ���
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
        yield return StartCoroutine(NormalChat("����", "���� ���ῡ ���δ��� ȯ�� ����ȸ�� �ִ�."));
        yield return StartCoroutine(NormalChat("����", "�׷��� ���� �д���... ��.. "));
        yield return StartCoroutine(NormalChat("����", "������ ���̺� ������ ���� ���̵带 ��ų��?  "));
        yield return StartCoroutine(NormalChat("����", "'�γ���' "));
        imagelona.enabled = true;
        yield return StartCoroutine(NormalChat("���� ���̵� �γ�", "��!! �����!  "));
        yield return StartCoroutine(NormalChat("����", "����ȸ �� ��� �� ���̺� ������ �ʿ��� �ñ⸶"));
        yield return StartCoroutine(NormalChat("���� ���̵� �γ�", "��! �ðܸ� �ּ���! "));
        SceneManager.LoadScene("GameScene");
    }
}