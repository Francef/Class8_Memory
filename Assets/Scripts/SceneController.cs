using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{       

    // Create (and return) a List of cards organized in a grid layout
    //private List<Card> CreateCards() {
    //    List<Card> newCards = new List<Card>();
    //    int rows = 2;           // # of rows
    //    int cols = 4;           // # of columns
    //    float xOffset = 2f;     // # of units between cards horizontally
    //    float yOffset = -2.5f;  // # of units between cards vertically

    //    // Create cards and position on a grid
    //    for (int y = 0; y < rows; y++) {
    //        for (int x = 0; x < cols; x++) {
    //            Vector3 offset = new Vector3(x * xOffset, y * yOffset, 0);    // calculate the offset                
    //            Card card = CreateCard(cardSpawnPoint.position + offset);     // create the card          
    //            newCards.Add(card);                                           // add the card to the list
    //        }
    //    }
    //    return newCards;
    //}

    // Assign images to the cards in pairs
    //private void AssignImagesToCards()
    //{
    //    // create a list of paired image indices - the # of entries MUST match the # of cards.
    //    // eg: [0,0,1,1,2,2,3,3]
    //    List<int> imageIndices = new List<int>();
    //    for (int i = 0; i < cardImages.Length; i++)
    //    {
    //        imageIndices.Add(i);    // one index for the first card in the pair
    //        imageIndices.Add(i);    // one index for the second
    //    }

    //    // *** TODO: write code to shuffle the list of image indices

    //    // Go through each card in the game and assign it an image based on the (shuffled) list of indices.
    //    for (int i = 0; i < cards.Count; i++)
    //    {
    //        int imageIndex = imageIndices[i];           // use the card # to index into the imageIndices array
    //        cards[i].SetSprite(cardImages[imageIndex]); // set the image on the card
    //    }
    //}
}
