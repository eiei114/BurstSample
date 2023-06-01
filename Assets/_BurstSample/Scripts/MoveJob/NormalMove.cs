using Unity.Mathematics;
using UnityEngine;

namespace _BurstSample.Scripts
{
    public class NormalMove : MonoBehaviour
    {
        private float speed = 2f;
 
        private void Update()
        {
            transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
            transform.rotation = math.mul(math.normalize(transform.rotation), quaternion.AxisAngle(math.up(), speed * Time.deltaTime));
 
            if (transform.position.y <= 0f) {
                transform.position = new float3(UnityEngine.Random.Range(-20f, 20f), 50f, 0f);
            }
        }
    }
}