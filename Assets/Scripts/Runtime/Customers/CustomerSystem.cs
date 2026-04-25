using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JamJam.Runtime.Customers {
    public class CustomerSystem : MonoBehaviour {
        private static HashSet<CustomerData> SpawnedCustomers;
        
        public GameObject customerPrefab;
        public float spawnRate;
        public CustomerSeat[] seats;
        public CustomerData[] customerOrder;

        private int _satisfaction;
        private int _nextCustomer;
        private float _lastSpawnTime;

        public static bool HasSpawnedCustomerBefore(CustomerData data) {
            return SpawnedCustomers.Contains(data);
        }

        private void Awake() {
            _nextCustomer = 0;
            SpawnedCustomers = new HashSet<CustomerData>(customerOrder.Length);
        }

        private void Update() {
            if (Time.time - _lastSpawnTime > spawnRate) {
                _lastSpawnTime = Time.time;
                TrySpawnCustomer();
            }
        }

        private void TrySpawnCustomer() {
            if (_nextCustomer >= customerOrder.Length) {
                return;
            }
            
            CustomerSeat seat = TryFindAvailableSeat();
            
            if (seat == null) return;

            SpawnCustomer(customerOrder[_nextCustomer], seat);
            _nextCustomer++;
        }

        private void SpawnCustomer(CustomerData customer, CustomerSeat seat) {
            CustomerEntity entity = Instantiate(customerPrefab).GetComponent<CustomerEntity>();
            entity.EnterBar(seat, customer);
            SpawnedCustomers.Add(customer);
        }
        
        private CustomerSeat TryFindAvailableSeat() {
            return seats.FirstOrDefault(customerSeat => customerSeat.Available);
        }
    }
}