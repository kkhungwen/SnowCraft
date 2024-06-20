using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private List<SOSpeechBubble> speechBubbles;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image backGroundImage;
    [SerializeField] private Image bubbleHeadImage; 
    [SerializeField] Transform speechBubbleTransform;
    [SerializeField] private Vector2 orginPosition;
    [SerializeField] private Vector2 bubbleImageOffset;
    [SerializeField] private float outLineOffset;
    [SerializeField] private float printSpeedSoftRange;

    private float printSpeed;
    private string currentString;
    private List<char> characters = new List<char>();
    private float currentTime;
    private int currentChar;

    private void Awake()
    {
        SetDown();
    }
    private void Update()
    {

    }

    public void Activate(string speechString, float duration)
    {
        SetUp(speechString, duration);
    }

    public void DeActivate()
    {
        SetDown();  
    }

    private void SetUp(string speechString, float duration)
    {
        Color white = new Color(255, 255, 255, 255);
        bubbleHeadImage.color = white;
        textMeshPro.SetText(speechString);
        Vector2 textSize = new Vector2(textMeshPro.preferredWidth, textMeshPro.preferredHeight);
        //Set Size
        textMeshPro.GetComponent<RectTransform>().sizeDelta = textSize;
        backGroundImage.rectTransform.sizeDelta = new Vector2(textSize.x + bubbleImageOffset.x*2,textSize.y + bubbleImageOffset.y*2);
        //Set Position
        textMeshPro.rectTransform.localPosition = new Vector2(bubbleImageOffset.x+orginPosition.x, bubbleImageOffset.y+orginPosition.y);
        backGroundImage.rectTransform.localPosition = new Vector2(orginPosition.x, orginPosition.y);
        Debug.Log(backGroundImage.rectTransform.localPosition);
        bubbleHeadImage.rectTransform.localPosition = new Vector2(bubbleImageOffset.x+bubbleHeadImage.rectTransform.sizeDelta.x / 2 + orginPosition.x, -bubbleHeadImage.rectTransform.sizeDelta.y / 2+outLineOffset + orginPosition.y);
        //speechBubbleTransform.localPosition = new Vector2(orginPosition.x + textSize.x/2 + bubbleImageOffset.x, orginPosition.y + textSize.y/2 + bubbleImageOffset.y);
        //bubbleHeadImage.rectTransform.localPosition = localPosition;
        textMeshPro.SetText("");
        currentString = speechString;
        characters = CreateCharacterList(speechString);
        printSpeed = CaculatePrintSpeed(speechString, duration);
        currentChar = 0;
        currentTime = 0;
    }

    private void SetDown()
    {
        Color trans = new Color(255,255,255,0);
        backGroundImage.rectTransform.sizeDelta = new Vector2(0, 0);
        textMeshPro.SetText("");
        textMeshPro.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        bubbleHeadImage.color = trans;
    }

    private List<char> CreateCharacterList(string text)
    {
        List<char> temp = new List<char>();
        foreach (char i in text)
        {
            temp.Add(i);
        }
        return temp;
    }

    private float CaculatePrintSpeed(string text,float duration)
    {
        float speed = (duration / text.Length) - printSpeedSoftRange;
        if(speed < 0)
        {
            speed = 0;
        }
        return speed;
    }

    public void PrintingTextCutScene(float delta)
    {
        currentTime -= delta;
        if (currentTime <= 0)
        {
            if (currentChar < characters.Count - 1)
            {
                textMeshPro.text += characters[currentChar];
                currentChar++;
                currentTime = printSpeed;
            }
            else if (currentChar == characters.Count - 1)
            {
                textMeshPro.text += characters[currentChar];
                currentChar++;               
            }
        }
    }

    public void PauseDirector()
    {
        CutsceneManager.Instance.PauseDirectorWaitForInput();
    }
}
