using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public float amplitude = 0.1f;  // 振動の幅
    public float frequency = 20.0f;  // 振動の速さ
    private Vector3 originalPosition;  // 元の位置を保存

    void Start()
    {
        // オブジェクトの初期位置を保存
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // 振動効果を作成
        float x = originalPosition.x + Mathf.Sin(Time.time * frequency) * amplitude;
        float y = originalPosition.y;  // y軸には振動を加えない場合
        float z = originalPosition.z + Mathf.Sin(Time.time * frequency * 1.2f) * amplitude;  // z軸に対しても振動させる

        // 新しい位置を設定
        transform.localPosition = new Vector3(x, y, z);
    }
}
