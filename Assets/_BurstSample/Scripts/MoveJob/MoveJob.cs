using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace _BurstSample.Scripts
{
    [BurstCompile]
    public struct MoveJob : IJobParallelForTransform
    {
        //　移動と回転のスピード
        [ReadOnly]
        public float speed;
        //　デルタタイム
        [ReadOnly]
        public float deltaTime;

        public void Execute(int index, TransformAccess transform) {
            // 下に移動
            transform.position = transform.position + Vector3.down * speed * deltaTime;
            // Y軸を中心に回転
            transform.rotation = math.mul(math.normalize(transform.rotation), quaternion.AxisAngle(math.up(), speed * deltaTime));

            // 画面外に出たら上に戻す
            if (transform.position.y <= 0f) {
                transform.position = new float3(transform.position.x, 50f, 0f);
            }
        }
    }
}