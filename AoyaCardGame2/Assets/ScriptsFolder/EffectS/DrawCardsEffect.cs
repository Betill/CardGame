using UnityEngine;

public class DrawCardsEffect : IEffect
{
    private PlayerDeck playerDeck;
    private PlayerDeck enemyDeck;
    private int numberOfCards;

    public DrawCardsEffect(PlayerDeck playerDeck, PlayerDeck enemyDeck, int numberOfCards)
    {
        this.playerDeck = playerDeck;
        this.enemyDeck = enemyDeck;
        this.numberOfCards = numberOfCards;
    }

    public void applyEffect(ThisCard target)
    {
        Debug.Log("Effect applied");
        if (target.IsPlayerCard)
            playerDeck.DrawCard(numberOfCards);
        else
            enemyDeck.DrawCard(numberOfCards);

    }
}
