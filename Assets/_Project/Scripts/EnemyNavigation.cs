using UnityEngine;
using UnityEngine.AI;

namespace Platformer397
{
    public class EnemyNavigation : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private Transform player;
        private NavMeshAgent agent;
        private Vector3 playePos;

        private void Awake()
        {
            player ??= GameObject.FindGameObjectWithTag("Player")?.transform;
            agent = GetComponent<NavMeshAgent>();
            playePos = player.position;
        }


        void Update()
        {
            //professor's code
            agent.destination = player.position;
            //agent.SetDestination(playePos);
        }
    }
}
