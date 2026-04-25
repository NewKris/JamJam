using System;
using System.Collections;
using System.Linq;
using JamJam.Runtime.Drink;
using JamJam.Runtime.Player;
using TMPro;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        public ReactionBubble reactionBubble;
        public TextMeshProUGUI speechText;
        public SpriteRenderer spriteRenderer;

        private CustomerSeat _assignedSeat;
        
        public void EnterBar(CustomerSeat assignedSeat, CustomerData assignedData) {
            spriteRenderer.sprite = assignedData.sprite;
            _assignedSeat =  assignedSeat;
            _assignedSeat.SeatCustomer(this);
            data = assignedData;
            speechText.text = CustomerSystem.HasSpawnedCustomerBefore(data) ? data.repeatingBark : data.firstBark;
            
            StartCoroutine(WalkToSeat());
        }

        public void EvaluateDrink(DrinkObject drink) {
            bool mixed = drink.mixAmount >= 1 || drink.ingredients.Distinct().Count() == 1;
            bool likesFlavour = mixed && data.desiredFlavour.EvaluateFlavour(drink.SumFlavours());

            if (likesFlavour) {
                Debug.Log("Yum!");
                SatisfactionManager.IncreaseSatisfaction(data.satisfactionGain);
            }
            else {
                Debug.Log("Eww!");
                SatisfactionManager.DecreaseSatisfaction(data.satisfactionLoss);
            }
            
            speechText.transform.parent.gameObject.SetActive(false);
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