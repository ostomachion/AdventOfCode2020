using System.Numerics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class CombatGame
    {
        public Queue<int> Player1Deck { get; }
        public Queue<int> Player2Deck { get; }

        public CombatGame(Queue<int> player1Deck, Queue<int> player2Deck)
        {
            Player1Deck = player1Deck;
            Player2Deck = player2Deck;
        }

        public static CombatGame Parse(string text)
        {
            var players = text.Split("\n\n", 2);
            var player1Deck = new Queue<int>(players[0].Split('\n').Skip(1).Select(int.Parse));
            var player2Deck = new Queue<int>(players[1].Split('\n').Skip(1).Select(int.Parse));
            return new CombatGame(player1Deck, player2Deck);
        }

        public void Move()
        {
            var p1 = Player1Deck.Dequeue();
            var p2 = Player2Deck.Dequeue();

            if (p1 > p2)
            {
                Player1Deck.Enqueue(p1);
                Player1Deck.Enqueue(p2);
            }
            else if (p2 > p1)
            {
                Player2Deck.Enqueue(p2);
                Player2Deck.Enqueue(p1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void PlayRecursive()
        {
            HashSet<string> previous = new();
            while (Player1Deck.Any() && Player2Deck.Any())
            {
                var state = GetState();
                if (previous.Contains(state))
                {
                    Player2Deck.Clear();
                    break;
                }
                else
                {
                    previous.Add(state);
                }
                MoveRecursive();
            }
        }

        private string GetState()
        {
            return string.Join(",", Player1Deck) + ":" + string.Join(",", Player2Deck);
        }

        public void MoveRecursive()
        {
            var p1 = Player1Deck.Dequeue();
            var p2 = Player2Deck.Dequeue();

            if (p1 <= Player1Deck.Count && p2 <= Player2Deck.Count)
            {
                var subGame = new CombatGame(new Queue<int>(Player1Deck.Take(p1)), new Queue<int>(Player2Deck.Take(p2)));
                subGame.PlayRecursive();
                if (!subGame.Player2Deck.Any())
                {
                    Player1Deck.Enqueue(p1);
                    Player1Deck.Enqueue(p2);
                }
                else if (!subGame.Player1Deck.Any())
                {
                    Player2Deck.Enqueue(p2);
                    Player2Deck.Enqueue(p1);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                if (p1 > p2)
                {
                    Player1Deck.Enqueue(p1);
                    Player1Deck.Enqueue(p2);
                }
                else if (p2 > p1)
                {
                    Player2Deck.Enqueue(p2);
                    Player2Deck.Enqueue(p1);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Play()
        {
            while (Player1Deck.Any() && Player2Deck.Any())
            {
                Move();
            }
        }

        public static BigInteger GetScore(Queue<int> deck)
        {
            var value = BigInteger.Zero;
            for (var i = 0; i < deck.Count; i++)
            {
                value += (i + 1) * deck.Reverse().ElementAt(i);
            }
            return value;
        }
    }
}