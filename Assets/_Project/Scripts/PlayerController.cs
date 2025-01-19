using Unity.VisualScripting;
using UnityEngine;
namespace Platformer397


{
    public class PlayerController : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private InputReader input;
        private void Start()
        {
            Debug.Log("[Start]");
            input.EnablePlayerActions();

        }

        private void OnEnable()
        {
            // test it with the enable and disable checkmarks in the inspector
            //Debug.Log("[OnEnable]");
            input.Move += GetMovement;

        }
        private void OnDisable()
        {
            Debug.Log("[OnDisable]");
            input.Move -= GetMovement;
        }

        //private void OnDestroy()
        //{
        //    Debug.Log("[OnDestroy]");
        //}

        private void GetMovement(Vector2 move)
        {
            Debug.Log("[GetMovement]" + move );
        }

    }
}
