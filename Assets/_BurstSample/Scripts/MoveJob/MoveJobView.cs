using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace _BurstSample.Scripts
{
    public class MoveJobView : MonoBehaviour
    {
        [SerializeField]
        private Text countText;
        
        [SerializeField]
        private Text fpsText;
        
        private const string Count = "Counts";
        
        private const string Fps = "fps";
        
        public string CountText
        {
            set => countText.text = value + Count;
        }

        private void Update()
        {
            fpsText.text = (1f / Time.deltaTime).ToString(CultureInfo.InvariantCulture) + Fps;
        }
    }
}