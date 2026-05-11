using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using TMPro;

public class CardGame : MonoBehaviour
{
    public List<Card> cards;
    public List<Sprite> sprites;
    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;

    public int pairCount = 10;

    public Card cardPrefab;
    public Transform Game;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<int> GeneratePairNumbers(int cardCount)
    {
        //페어카드넘버생성
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();

        for(int i =  0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        //셔플
        for(int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;
        }

        return newCardNumbers;
    }

   
    //게임루프
    private void StartGame()
    {
        int totalCards = pairCount * 2;

        if(pairCount > 10)
        {
            Debug.LogError("페어카드의 수는 최대 10개입니다.");
            return;
        }

        for(int i = 0; i < totalCards; ++i)
        {
            Card newCard = Instantiate(cardPrefab, Game);
            newCard.cardGame = this;
            cards.Add(newCard);
        }
        

        List<int> randomPairNumbers = GeneratePairNumbers(cards.Count);

        for(int i = 0; i < cards.Count; ++i)
        {
            cards[i].SetCardNumber(randomPairNumbers[i]);
            cards[i].SetImage(sprites[randomPairNumbers[i]]);
            cards[i].isFront = false;
        }
    }

    private void CheckCard()
    {//두 카드가 맞는지

        isChecking = true;

        if(firstCard.cardNumber == secondCard.cardNumber)
        {
            firstCard.isMatched = true;
            secondCard.isMatched = true;

            firstCard.ChangeColor(Color.red);
            secondCard.ChangeColor(Color.red);

            firstCard = null;
            secondCard = null;

            isChecking = false;
        }
        else
        { //다시원래대로
          //지연
            Invoke("HideCard", 0.6f);
        }

    }

    private void HideCard()
    {
            firstCard.isFront = false;
            secondCard.isFront = false;

            firstCard.Flip(false);
            secondCard.Flip(false);

            firstCard = null;
            secondCard = null;

            isChecking = false;
    }


     //카드가선택되면호출
    public void OnClickCard(Card card)
    {
        if(isChecking)
        {
           return;
        }

        if(firstCard == null)
        {
           firstCard = card;
           firstCard.Flip(true);
        }
        else if(firstCard != card)
        {
           secondCard = card;
           secondCard.Flip(true);
        } 

        if(firstCard != null && secondCard != null)
        {
            CheckCard();
        }
    }
 

    
}
