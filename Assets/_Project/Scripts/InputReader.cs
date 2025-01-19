
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions; // as statict in order to access IPlayerActions

namespace Platformer397
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };
        public void OnMove(InputAction.CallbackContext context) 
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                case InputActionPhase.Canceled:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
            }
            Move?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnLook(InputAction.CallbackContext context) { }
        public void OnAttack(InputAction.CallbackContext context) { }
        public void OnInteract(InputAction.CallbackContext context) { }
        public void OnCrouch(InputAction.CallbackContext context) { }
        public void OnJump(InputAction.CallbackContext context) { }
        public void OnPrevious(InputAction.CallbackContext context) { }
        public void OnNext(InputAction.CallbackContext context) { }
        public void OnSprint(InputAction.CallbackContext context) { }




        InputSystem_Actions input;
        private void OnEnable()
        {
            if (input == null)
            {
                input = new InputSystem_Actions();
                input.Player.SetCallbacks(this);
            }
            input.Enable();
            

        }

        public void EnablePlayerActions()
        {
            input.Enable();

        }
    }
}
