
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

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        //Explanation: This method is called when the script instance is being loaded.
        // https://www.youtube.com/watch?v=EhHsm95D_C0&list=PLQzk5yF-sBwCjj-6oYr9EHOguj4PzbqHj&index=13&t=9127s
        //2:23:28
        public void OnMove(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                case InputActionPhase.Canceled:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
                default:
                    break;
            }
           
        }


        public void OnLook(InputAction.CallbackContext context) { }
        public void OnAttack(InputAction.CallbackContext context) { }
        public void OnInteract(InputAction.CallbackContext context) { }
        public void OnCrouch(InputAction.CallbackContext context) { }
        public void OnJump(InputAction.CallbackContext context) { }
        public void OnPrevious(InputAction.CallbackContext context) { }
        public void OnNext(InputAction.CallbackContext context) { }
        public void OnSprint(InputAction.CallbackContext context) { }

    }
}
