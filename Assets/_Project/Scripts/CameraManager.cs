using UnityEngine;
using Unity.Cinemachine;

namespace Platformer397
{
    public class CameraManager : MonoBehaviour
    {
        //References to the Cinemachine Virtual Camera  and transfortm of out player
        [SerializeField] private CinemachineCamera freeLookCam;
        [SerializeField] private Transform player;

        // In Awake, lock the mouse into the game view in Unity and turn the cursor invisible

        private void Awake()
        {

            //player = GameObject.FindGameObjectWithTag("Player").transform;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            player ??= GameObject.FindGameObjectWithTag("Player")?.transform;

        }

        // OnEnable, associate the transfor of the player with the Cinemachine Virtual Camera
        private void OnEnable()
        {
            freeLookCam.Target.TrackingTarget = player;

        }
    }
}
