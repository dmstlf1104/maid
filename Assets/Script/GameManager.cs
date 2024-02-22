using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 0.0f;
    public GameObject card;

    void Start()
    {
        float cardWidth = 110f;
        float cardHeight = 110f;
        int rows = 2;
        int cols = 6;

        for (int row = 0; row < rows; row++)
        {
            int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};

            rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

            for (int col = 0; col < cols; col++)
            {
                GameObject newCard = Instantiate(card);
                newCard.transform.parent = GameObject.Find("cards").transform;

                float xPos = col * cardWidth - 300f;
                float yPos = row * -cardHeight + 10; 

                xPos += col * 10f;
                yPos -= row * 10f;

                newCard.transform.localPosition = new Vector3(xPos, yPos, 0);

                //string rtanName = "rtan" + rtans[col].ToString();
                //newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
            }

            
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
}
