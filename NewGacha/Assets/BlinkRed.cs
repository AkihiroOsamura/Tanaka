using UnityEngine;

public class BlinkRed : MonoBehaviour
{
    public Material material;  // ここに対象のマテリアルをアタッチする
    public float blinkInterval = 0.5f;  // 点滅の間隔
    private Color originalColor;  // 元のAlbedoカラーを保存
    private bool isRed = false;  // 現在の色が赤かどうかを管理

    void Start()
    {
        if (material == null)
        {
            material = GetComponent<Renderer>().material;  // アタッチされていない場合、Rendererから取得
        }
        originalColor = material.color;  // 初期カラーを保存
        InvokeRepeating("ToggleColor", blinkInterval, blinkInterval);  // 点滅を開始
    }

    void ToggleColor()
    {
        if (isRed)
        {
            material.color = originalColor;  // 元の色に戻す
        }
        else
        {
            material.color = Color.red;  // 赤色にする
        }
        isRed = !isRed;  // フラグを反転
    }
}
