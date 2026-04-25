using System;
using System.Collections;
using JamJam.Runtime.Drink;
using JamJam.Runtime.Player;
using TMPro;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        public ReactionBubble reactionBubble;
        public TextMeshProUGUI speechText;

        private CustomerSeat _assignedSeat;
        
        public void EnterBar(CustomerSeat assignedSeat, CustomerData assignedData) {
            _assignedSeat =  assignedSeat;
            _assignedSeat.SeatCustomer(this);
            data = assignedData;
            speechText.text = data.barks[0];
            
            StartCoroutine(WalkToSeat());
        }

        public void EvaluateDrink(DrinkObject drink) {
            bool likesFlavour = drink.mixAmount >= 1 && data.desiredFlavour.EvaluateFlavour(drink.SumFlavours());

            if (likesFlavour) {
                Debug.Log("Yum!");
                SatisfactionManager.IncreaseSatisfaction(data.satisfactionGain);
            }
            else {
                Debug.Log("Eww!");
                SatisfactionManager.DecreaseSatisfaction(data.satisfactionLoss);
            }
            
            reactionBubble.Display(likesFlavour);
        }
        
        public IEnumerator WalkOut() {
            Vector3 start = _assignedSeat.SeatPos;
            Vector3 end = _assignedSeat.SpawnStart;
            
            transform.position = start;
            
            for (float t = 0; t < 2; t += Time.deltaTime) {
                transform.position = Vector3.Lerp(start, end, t / 2);
                yield return null;
            }
            
            transform.position = end;
            Destroy(gameObject);
        }

        private IEnumerator WalkToSeat() {
            Vector3 start = _assignedSeat.SpawnStart;
            Vector3 end = _assignedSeat.SeatPos;
            
            transform.position = start;
            
            for (float t = 0; t < 2; t += Time.deltaTime) {
                transform.position = Vector3.Lerp(start, end, t / 2);
                yield return null;
            }
            
            transform.position = end;
        }
    }
}