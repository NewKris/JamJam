using System;
using System.Collections;
using JamJam.Runtime.Bar;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        public Flavour desiredFlavour;

        private CustomerSeat _assignedSeat;

        public void GiveDrink() {
            _assignedSeat.Available = true;
            Destroy(gameObject);
        }
        
        public void EnterBar(CustomerSeat assignedSeat, CustomerData assignedData) {
            _assignedSeat =  assignedSeat;
            _assignedSeat.Available = false;
            data = assignedData;
            
            StartCoroutine(WalkToSeat());
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