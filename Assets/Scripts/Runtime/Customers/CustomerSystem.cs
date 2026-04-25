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
        public CustomerData[] availableCustomers;

        private int _satisfaction;
        private float _lastSpawnTime;

        public static bool HasSpawnedCustomerBefore(CustomerData data) {
            return SpawnedCustomers.Contains(data);
        }

        private void Awake() {
            SpawnedCustomers = new HashSet<CustomerData>(availableCustomers.Length);
        }

        private void Update() {
            if (Time.time - _lastSpawnTime > spawnRate) {
                _lastSpawnTime = Time.time;
                TrySpawnCustomer();
            }
        }

        private void TrySpawnCustomer() {
            CustomerSeat seat = TryFindAvailableSeat();
            
            if (seat == null) return;

            SpawnCustomer(FindAvailableCustomer(), seat);
        }

        private void SpawnCustomer(CustomerData customer, CustomerSeat seat) {
            CustomerEntity entity = Instantiate(customerPrefab).GetComponent<CustomerEntity>();
            entity.EnterBar(seat, customer);
            SpawnedCustomers.Add(customer);
        }
        
        private CustomerData FindAvailableCustomer() {
            List<CustomerData> inactiveCustomers = availableCustomers
                .ToList();
            
            int i = Random.Range(0, inactiveCustomers.Count);
            return inactiveCustomers[i];
        }
        
        private CustomerSeat TryFindAvailableSeat() {
            return seats.FirstOrDefault(customerSeat => customerSeat.Available);
        }
    }
}