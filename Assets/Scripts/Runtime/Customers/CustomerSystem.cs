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
        public List<CustomerData> customerPool;
        public CustomerData[] tutorialCustomers;
        public CustomerData finalBoss;
        public GameObject tutorialParent;

        private bool _isInTutorial;
        private int _satisfaction;
        private float _lastSpawnTime;
        private int _nextTutorialCustomer;
        private CustomerSeat[] _seats;

        public static void DeSpawnCustomer(CustomerData data) {
            ActiveCustomers.Remove(data);
            Instance.EvaluateTutorial();
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
            _seats = GetComponentsInChildren<CustomerSeat>();
            Instance = this;
            SpawnedCustomers = new HashSet<CustomerData>(customerPool.Count);
            ActiveCustomers = new HashSet<CustomerData>(customerPool.Count);
            EvaluateTutorial();
        }

        private void EvaluateTutorial() {
            Instance._isInTutorial = Instance._nextTutorialCustomer < Instance.tutorialCustomers.Length;
            tutorialParent.SetActive(_isInTutorial);
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

            if (_isInTutorial && ActiveCustomers.Count >= 1) return;
             
            CustomerData data = _isInTutorial ? GetTutorialCustomer() : GetRandomCustomer();
            
            SpawnCustomer(data, seat);
        }

        private CustomerData GetTutorialCustomer() {
            CustomerData data = tutorialCustomers[_nextTutorialCustomer];
            _nextTutorialCustomer++;
            return data;
        }

        private CustomerData GetRandomCustomer() {
            int randomIndex;
            do {
                randomIndex = Random.Range(0, customerPool.Count);
            } while (ActiveCustomers.Contains(customerPool[randomIndex]));
            
            return customerPool[randomIndex];
        }

        private void SpawnCustomer(CustomerData customer, CustomerSeat seat) {
            CustomerEntity entity = Instantiate(customerPrefab).GetComponent<CustomerEntity>();
            entity.EnterBar(seat, customer);
            
            ActiveCustomers.Add(customer);
            SpawnedCustomers.Add(customer);
        }
        
        private CustomerSeat TryFindAvailableSeat() {
            return _seats.FirstOrDefault(customerSeat => customerSeat.Available);
        }
    }
}