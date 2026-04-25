using System;
using System.Collections;
using JamJam.Runtime.Drink;
using JamJam.Runtime.Utility;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerSeat : MonoBehaviour {
        public Transform coaster;
        
        public bool Available { get; set; }
        public CustomerEntity CurrentCustomer { get; set; }
        
        public Vector3 SpawnStart => transform.position + Vector3.forward * 5;
        public Vector3 SeatPos => transform.position;

        public void ServeDrink(DrinkObject drinkObject) {
            StartCoroutine(PlayServeSequence(drinkObject));
        }

        public void SeatCustomer(CustomerEntity customer) {
            Available = false;
            CurrentCustomer = customer;
            SetCollidersActive(true);
        }
        
        private void Start() {
            Available = true;
            SetCollidersActive(false);
        }

        private void OnDrawGizmos() {
            HandlesProxy.DrawDisc(transform.position, Vector3.up, 0.5f, false, Color.yellow);
            HandlesProxy.DrawDisc(SpawnStart, Vector3.up, 0.5f, true, Color.red);
            HandlesProxy.DrawLine(transform.position, SpawnStart, 1, true, Color.red);
        }

        private IEnumerator PlayServeSequence(DrinkObject drinkObject) {
            SetCollidersActive(false);
            drinkObject.PinDrink(coaster);
            yield return new WaitForSeconds(1f);
            
            CurrentCustomer.EvaluateDrink(drinkObject);
            
            yield return CurrentCustomer.WalkOut();
            Destroy(drinkObject.gameObject);
            Available = true;
        }

        private void SetCollidersActive(bool active) {
            foreach (Collider col in GetComponentsInChildren<Collider>()) {
                col.enabled = active;
            }
        }
    }
}