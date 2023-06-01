using UnityEngine;
using UnityEngine.UI;

namespace _BurstSample.Scripts
{
    public class NormalInstantiate : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private int numberToInstantiate = 100;
        private int total;
        [SerializeField]
        private Text totalText;
        [SerializeField]
        private Text fpsText;
 
        private void Update()
        {
            fpsText.text = (1f / Time.deltaTime).ToString();
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                InstantiateGameObject();
            }
        }

        private void InstantiateGameObject() {
            for (int i = 0; i < numberToInstantiate; i++) {
                Instantiate(prefab, new Vector3(Random.Range(-20f, 20f), 50f, 0f), Quaternion.identity);
            }
            total += numberToInstantiate;
            totalText.text = total.ToString();
        }
    }
}