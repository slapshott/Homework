﻿namespace Poker.Tests.Fakes
{
    using System;
    using System.Collections.Generic;

    using Poker;

    // https://github.com/shakuu/Unit-Testing/tree/master/Topics/02.%20Test-Driven%20Development/homewrok
    public class HandTypePresetsFakeHand : IHand
    {
        public HandTypePresetsFakeHand(HandType type)
        {
             this.Cards = this.initializeCards(type);
        }

        public IList<ICard> Cards { get; private set; }

        private IList<ICard> initializeCards(HandType type)
        {
            var newListOfCards = new List<ICard>();

            switch (type)
            {
                case HandType.IsStraightFlush:
                    newListOfCards = this.GetStraightFlush();
                    break;
                case HandType.IsFourOfAKind:
                    break;
                case HandType.IsFullHouse:
                    break;
                case HandType.IsFlush:
                    newListOfCards = this.GetFlush();
                    break;
                case HandType.IsStraight:
                    break;
                case HandType.IsThreeOfAKind:
                    break;
                case HandType.IsTwoPair:
                    break;
                case HandType.IsOnePair:
                    break;
                case HandType.IsHighCard:
                    newListOfCards = this.GetHighCard();
                    break;
                default:
                    break;
            }

            return newListOfCards;
        }

        private List<ICard> GetHighCard()
        {
            var highCard = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Two, CardSuit.Diamonds),
                new FakeCard(CardFace.Four, CardSuit.Hearts),
                new FakeCard(CardFace.Eight, CardSuit.Spades),
                new FakeCard(CardFace.Jack, CardSuit.Clubs)
            };

            return highCard;
        }

        private List<ICard> GetStraightFlush()
        {
            var straightFlush = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.King, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Clubs),
                new FakeCard(CardFace.Jack, CardSuit.Clubs),
                new FakeCard(CardFace.Queen, CardSuit.Clubs)
            };

            return straightFlush;
        }

        private List<ICard> GetFlush()
        {
            var flush = new List<ICard>()
            {
                new FakeCard(CardFace.Ace, CardSuit.Clubs),
                new FakeCard(CardFace.Eight, CardSuit.Clubs),
                new FakeCard(CardFace.Jack, CardSuit.Clubs),
                new FakeCard(CardFace.Ten, CardSuit.Clubs),
                new FakeCard(CardFace.Two, CardSuit.Clubs)
            };

            return flush;
        }
    }
}
