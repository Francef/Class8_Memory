using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardSpawnPoint;

    [SerializeField] private Sprite[] cardImages;
    List<Card> cards;

    [SerializeField] TextMeshProUGUI scoreText;

    Card card1 = null;
    Card card2 = null;
    int score = 0;

    private void Awake()
    {
        Messenger<Card>.AddListener(GameEvent.CARD_CLICKED, this.OnCardClicked);
    }

    private void OnDestroy()
    {
        Messenger<Card>.RemoveListener(GameEvent.CARD_CLICKED, this.OnCardClicked);
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
        cards = CreateCards();
        AssignImagesToCards();
    }

    Card CreateCard(Vector3 pos)
    {
        GameObject obj = Instantiate(cardPrefab, pos, cardPrefab.transform.rotation);
        Card card = obj.GetComponent<Card>();
        return card;
    }

    // Create (and return) a List of cards organized in a grid layout
    private List<Card> CreateCards()
    {
        List<Card> newCards = new List<Card>();
        int rows = 2;           // # of rows
        int cols = 4;           // # of columns
        float xOffset = 2f;     // # of units between cards horizontally
        float yOffset = -2.5f;  // # of units between cards vertically

        // Create cards and position on a grid
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Vector3 offset = new Vector3(x * xOffset, y * yOffset, 0);    // calculate the offset                
                Card card = CreateCard(cardSpawnPoint.position + offset);     // create the card          
                newCards.Add(card);                                           // add the card to the list
            }
        }
        return newCards;
    }

    // Assign images to the cards in pairs
    private void AssignImagesToCards()
    {
        // create a list of paired image indices - the # of entries MUST match the # of cards.
        // eg: [0,0,1,1,2,2,3,3]
        List<int> imageIndices = new List<int>();

        for (int i = 0; i < cardImages.Length; i++)
        {
            imageIndices.Add(i);    // one index for the first card in the pair
            imageIndices.Add(i);    // one index for the second
        }
        int r;
        for (int i = 0; i < imageIndices.Count; i++)
        {
            int temp;

            r = UnityEngine.Random.Range(0, imageIndices.Count);
            temp = imageIndices[i];
            imageIndices[i] = imageIndices[r];
            imageIndices[r] = temp;

        }

        // Go through each card in the game and assign it an image based on the (shuffled) list of indices.
        for (int i = 0; i < cards.Count; i++)
        {
            int imageIndex = imageIndices[i];           // use the card # to index into the imageIndices array
            cards[i].SetSprite(cardImages[imageIndex]); // set the image on the card
        }
    }

    public void OnCardClicked(Card card)
    {
        Debug.Log(this + ".OnCardClicked()");
        //card.setFaceVisible(true);
        if(card1 == null)   // no cards have been clicked
        {
            card1 = card;
            card1.setFaceVisible(true);
        } else if (card2 == null)   // one card has been clicked
        {
            card2 = card;
            card2.setFaceVisible(true);
            StartCoroutine(EvaluatePair());
        }
        else
        {
            Debug.Log("ignoring click");
        }
    }

    IEnumerator EvaluatePair()
    {
        if (card1.GetSprite() == card2.GetSprite())
        {
            Debug.Log("match");
            score++;
            scoreText.text = "Score: " + score;
        }
        else 
        {
            Debug.Log("not a match");
            // put cards on Swap layer and swap
            card1.SetSortingLayer("Swap");
            card2.SetSortingLayer("Swap");
            float swapTime = 1f;
            // pause and look at cards
            yield return new WaitForSeconds(swapTime);


            iTween.MoveTo(card1.gameObject, card2.transform.position, swapTime);
            iTween.MoveTo(card2.gameObject, card1.transform.position, swapTime);
            // pause for movement
            yield return new WaitForSeconds(swapTime);

            //return back to Foreground layer
            card1.SetSortingLayer("Foreground");
            card2.SetSortingLayer("Foreground");
            card1.setFaceVisible(false);
            card2.setFaceVisible(false);
        }
        card1 = null;
        card2 = null;
    }

    public void OnResetButtonPressed()
    {
        Reset();
    }

    private void Reset()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        card1 = null;
        card2 = null;

        // turn cards face down
        foreach(Card card in cards)
        {
            card.setFaceVisible(false);
        }
        //randomize card images
        AssignImagesToCards();
    }



}
