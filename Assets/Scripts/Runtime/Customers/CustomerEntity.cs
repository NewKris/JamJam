using System;
using System.Collections;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        public float spawnTime;

        private CustomerSeat _assignedSeat;

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
            
            for (float t = 0; t < spawnTime; t += Time.deltaTime) {
                transform.position = Vector3.Lerp(start, end, t / spawnTime);
                yield return null;
            }
            
            transform.position = end;
        }
    }
}