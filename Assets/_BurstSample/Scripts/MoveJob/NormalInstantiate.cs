using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _BurstSample.Scripts
{
    public class NormalInstantiate : MonoBehaviour
    {
        [SerializeField]
        private DemoManager demoManager;
        [SerializeField]
        private MoveJobView moveJobView;
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private int numberToInstantiate = 100;
        private int _total;

        private void Awake()
        {
            this.enabled = !demoManager.IsBurst();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                InstantiateGameObject();
            }
        }

        private void InstantiateGameObject() {
            for (int i = 0; i < numberToInstantiate; i++) {
                Instantiate(prefab, new Vector3(Random.Range(-20f, 20f), 50f, 0f), Quaternion.identity);
            }
            _total += numberToInstantiate;
            moveJobView.CountText = _total.ToString();
        }
    }
}