using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JamJam.Runtime.Player {
    public class PlayerController : MonoBehaviour {
        public static event Action OnGrab;
        public static event Action OnRelease;
        public static event Action<int> OnAddIngredient;
        
        public static bool HoldingMix { get; private set; }
        public static Vector2 DeltaMouse { get; private set; }

        private InputAction _mixAction;
        private InputAction _lookAction;

        private InputActionMap ActionMap => InputSystem.actions.actionMaps[0];
        
        private void Awake() {
            _lookAction = ActionMap["Look"];
            _mixAction = ActionMap["Mix"];
            
            ActionMap["Interact"].performed += _ =>  OnGrab?.Invoke();
            ActionMap["Interact"].canceled += _ =>  OnRelease?.Invoke();
            
            ActionMap["Ingredient 1"].performed += _ =>  OnAddIngredient?.Invoke(0);
            ActionMap["Ingredient 2"].performed += _ =>  OnAddIngredient?.Invoke(1);
            ActionMap["Ingredient 3"].performed += _ =>  OnAddIngredient?.Invoke(2);
            ActionMap["Ingredient 4"].performed += _ =>  OnAddIngredient?.Invoke(3);
            ActionMap["Ingredient 5"].performed += _ =>  OnAddIngredient?.Invoke(4);
            ActionMap["Ingredient 6"].performed += _ =>  OnAddIngredient?.Invoke(5);
            ActionMap["Ingredient 7"].performed += _ =>  OnAddIngredient?.Invoke(6);
            ActionMap["Ingredient 8"].performed += _ =>  OnAddIngredient?.Invoke(7);
            ActionMap["Ingredient 9"].performed += _ =>  OnAddIngredient?.Invoke(8);
            ActionMap["Ingredient 10"].performed += _ =>  OnAddIngredient?.Invoke(9);
            ActionMap["Ingredient 11"].performed += _ =>  OnAddIngredient?.Invoke(10);
            ActionMap["Ingredient 12"].performed += _ =>  OnAddIngredient?.Invoke(11);
            
            ActionMap.Enable();
        }

        private void OnDestroy() {
            ActionMap.Dispose();
        }

        private void Update() {
            DeltaMouse = _lookAction.ReadValue<Vector2>();
            HoldingMix = _mixAction.ReadValue<float>() > 0f;
        }
    }
}
