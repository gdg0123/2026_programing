using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int cardNumber;
    public float rotationSpeed;
    public bool isFront = true;
    public bool isMatched = false;
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);
    public CardGame cardGame;

    public Sprite frontSprite;
    public Sprite backSprite;


    //����

    //�Լ�

    // Update is called once per frame
    void Update()
    {

        //AND &&     OR ||

        if(isFront)
        {
           transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
           transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }

        

    }
    


    public void ClickCard()
    {
        if(!isMatched)
        {
            cardGame.OnClickCard(this);
            //isFront = !isFront;
        }
        
    }

    //카드 돌리기

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
        if(isFront)
        {
            GetComponent<Image>().sprite = frontSprite;
        }
        else
        {
            GetComponent<Image>().sprite = backSprite;
        }
    }


    public void SetCardNumber(int newNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        cardNumber = newNumber;

        text.text = cardNumber.ToString();
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }

    public void SetImage(Sprite sprite)
    {
        frontSprite = sprite;
        GetComponent<Image>().sprite = backSprite;
    }


    
}
