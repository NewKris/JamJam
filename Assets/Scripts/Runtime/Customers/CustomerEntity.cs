using System;
using System.Collections;
using System.Linq;
using JamJam.Runtime.Audio;
using JamJam.Runtime.Drink;
using JamJam.Runtime.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        public ReactionBubble reactionBubble;
        public TextMeshProUGUI speechText;
        public TextMeshProUGUI nameText;
        public SpriteRenderer spriteRenderer;
        public Image timerSprite;
        public FootStepPlayer footSteps;

        private CustomerSeat _assignedSeat;
        private float _patience;
        private bool _waiting;
        
        public void EnterBar(CustomerSeat assignedSeat, CustomerData assignedData) {
            _waiting = true;
            _patience = assignedData.patienceTime;
            spriteRenderer.sprite = assignedData.sprite;
            _assignedSeat =  assignedSeat;
            _assignedSeat.SeatCustomer(this);
            data = assignedData;
            speechText.text = CustomerSystem.HasSpawnedCustomerBefore(data) ? data.repeatingBark : data.firstBark;
            nameText.text = assignedData.displayName;
            nameText.transform.parent.gameObject.SetActive(!string.IsNullOrEmpty(assignedData.displayName));

            StartCoroutine(WalkToSeat());
        }

        public void StopWaiting() {
            _waiting = false;
        }

        public void FailDrink() {
            _waiting = false;
            SatisfactionManager.DecreaseSatisfaction(data.satisfactionLoss);
            speechText.transform.parent.gameObject.SetActive(false);
            reactionBubble.Display(false);
        }

        public bool EvaluateDrink(DrinkObject drink) {
            _waiting = false;
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
            return likesFlavour;
        }
        
        public IEnumerator WalkOut() {
            Vector3 start = _assignedSeat.SeatPos;
            Vector3 end = _assignedSeat.SpawnStart;
            SpriteRenderer reactionSprite = reactionBubble.GetComponent<SpriteRenderer>();
            
            transform.position = start;
            footSteps.IsWalking = true;
            
            for (float t = 0; t < 2; t += Time.deltaTime) {
                transform.position = Vector3.Lerp(start, end, t / 2);
                spriteRenderer.color = Color.Lerp(Color.white, Color.clear, t);
                reactionSprite.color = Color.Lerp(Color.white, Color.clear, t);
                yield return null;
            }
            
            transform.position = end;
            spriteRenderer.color = Color.clear;
            reactionSprite.color = Color.clear;
            footSteps.IsWalking = false;
            
            Destroy(gameObject);
            CustomerSystem.DeSpawnCustomer(data);
        }

        private IEnumerator WalkToSeat() {
            Vector3 start = _assignedSeat.SpawnStart;
            Vector3 end = _assignedSeat.SeatPos;
            
            transform.position = start;
            footSteps.IsWalking = true;
            
            for (float t = 0; t < 2; t += Time.deltaTime) {
                transform.position = Vector3.Lerp(start, end, t / 2);
                spriteRenderer.color = Color.Lerp(Color.clear, Color.white, t);
                yield return null;
            }
            
            spriteRenderer.color = Color.white;
            transform.position = end;
            footSteps.IsWalking = false;
        }

        private void Update() {
            _patience -= Time.deltaTime;
            timerSprite.fillAmount = _patience / data.patienceTime;

            if (_waiting && _patience <= 0) {
                _waiting = false;
                _assignedSeat.KickCustomer();
            }
        }
    }
}