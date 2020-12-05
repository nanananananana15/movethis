using DG.Tweening;
using UnityEngine;

public class TestTween : MonoBehaviour
{
    // 開始時
    void Start()
    {
        PlayMoveTween();
    }

    // Tweenの再生
    void PlayMoveTween()
    {
        Sequence sequence = DOTween.Sequence();

        // 移動時間
        float duration = 1f;

        // 移動値
        Vector3 addValue = new Vector3(Random.Range(-80f, 80f), Random.Range(-80f, 80f), 0f);
        Vector2 endPos = transform.position + addValue;
        endPos = ClampInScreen(endPos);

        // Tweenの作成
        sequence.Append(transform.DOMove(endPos, duration));

        // イーズタイプの指定
        sequence.SetEase(Ease.Linear);

        // ループの終わりにまたこのメソッドを呼ぶように指定
        sequence.OnComplete(PlayMoveTween);

        // 再生
        sequence.Play();
    }

    Vector2 ClampInScreen(Vector2 objectPos)
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        objectPos.x = Mathf.Clamp(objectPos.x, min.x, max.x);
        objectPos.y = Mathf.Clamp(objectPos.y, min.y, max.y);

        return objectPos;
    }
}