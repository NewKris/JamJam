using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class CustomerEntity : MonoBehaviour {
        public CustomerData data;
        
        private CustomerSeat _assignedSeat;

        public void EnterBar(CustomerSeat assignedSeat, CustomerData assignedData) {
            _assignedSeat =  assignedSeat;
            _assignedSeat.Available = false;
            
            data = assignedData;

            Vector2 randPos = Random.insideUnitCircle * 10;
            transform.position = new Vector3(randPos.x, 0, randPos.y);
        }
    }
}