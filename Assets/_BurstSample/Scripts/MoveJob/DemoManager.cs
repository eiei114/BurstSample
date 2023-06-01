using UnityEngine;

namespace _BurstSample.Scripts
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField]
        private bool isBurst = true;

        public bool IsBurst()
        {
            return isBurst;
        }
    }
}
