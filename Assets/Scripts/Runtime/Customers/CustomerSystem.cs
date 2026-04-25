using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JamJam.Runtime.Customers {
    public class CustomerSystem : MonoBehaviour {
        private static HashSet<CustomerData> SpawnedCustomers;
        private static HashSet<CustomerData> ActiveCustomers;
        private static CustomerSystem Instance;
        
        public GameObject customerPrefab;
        public float spawnRate;
        public CustomerSeat[] seats;
        public List<CustomerData> customerPool;
        public CustomerData finalBoss;

        private int _satisfaction;
        private float _lastSpawnTime;

        public static void DeSpawnCustomer(CustomerData data) {
            ActiveCustomers.Remove(data);
        }
        
        public static bool HasSpawnedCustomerBefore(CustomerData data) {
            return SpawnedCustomers.Contains(data);
        }

        public static void AddFinalBoss() {
            if (!Instance.customerPool.Contains(Instance.finalBoss)) {
                Instance.customerPool.Add(Instance.finalBoss);
            }
        }

        private void Awake() {
            Instance = this;
            SpawnedCustomers = new HashSet<CustomerData>(customerPool.Count);
            ActiveCustomers = new HashSet<CustomerData>(customerPool.Count);
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

            int randomIndex;
            do {
                randomIndex = Random.Range(0, customerPool.Count);
            } while (ActiveCustomers.Contains(customerPool[randomIndex]));
            
            SpawnCustomer(customerPool[randomIndex], seat);
        }

        private void SpawnCustomer(CustomerData customer, CustomerSeat seat) {
            CustomerEntity entity = Instantiate(customerPrefab).GetComponent<CustomerEntity>();
            entity.EnterBar(seat, customer);
            
            ActiveCustomers.Add(customer);
            SpawnedCustomers.Add(customer);
        }
        
        private CustomerSeat TryFindAvailableSeat() {
            return seats.FirstOrDefault(customerSeat => customerSeat.Available);
        }
    }
}