using UnityEngine;

public class DrawCardsEffect : IEffect
{

    private PlayerDeck playerDeck;
    private int numberOfCards;

    public DrawCardsEffect(PlayerDeck playerDeck, int numberOfCards)
    {
        this.playerDeck = playerDeck;
        this.numberOfCards = numberOfCards;
    }

    public void applyEffect()
    {
        Debug.Log("Effect applied");
        playerDeck.DrawCard(numberOfCards);
    }
}
