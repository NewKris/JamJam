using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JamJam.Runtime.Player {
    public class PlayerController : MonoBehaviour {
        public static event Action OnInteract;
        
        public static Vector2 DeltaMouse { get; private set; }

        private InputAction _lookAction;

        private InputActionMap ActionMap => InputSystem.actions.actionMaps[0];
        
        private void Awake() {
            _lookAction = ActionMap["Look"];
            
            ActionMap["Interact"].performed += _ =>  OnInteract?.Invoke();
            
            ActionMap.Enable();
        }

        private void OnDestroy() {
            ActionMap.Dispose();
        }

        private void Update() {
            DeltaMouse = _lookAction.ReadValue<Vector2>();
        }
    }
}
