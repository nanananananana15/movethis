using System;
using System.Collections;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;
/// <summary>
/// Playerにアタッチ
/// </summary>

public class muteki : MonoBehaviour
{
    [SerializeField]
    Material damageMaterial, normalMaterial;

    [SerializeField]
    AudioSource damageSound;

    Coroutine damageEffectCoroutine;

    float invincibleTime = 2.0f;

    MeshRenderer playerMeshRenderer;

    void Start()
    {
        playerMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        //敵に当たったら音が鳴ってマテリアル変更→無敵時間を作って終わったらマテリアルを元に戻す
        this.OnTriggerEnterAsObservable()
            .Where(collision => collision.gameObject.tag == "Enemy")
            .ThrottleFirst(TimeSpan.FromSeconds(invincibleTime))
            .Subscribe(_ =>
            {
                if (damageEffectCoroutine != null)
                {
                    StopCoroutine(damageEffectCoroutine);
                }

                damageEffectCoroutine = StartCoroutine(DamageEffect());
            })
            .AddTo(this); ;
    }

    IEnumerator DamageEffect()
    {
        Debug.Log("Damage");

        damageSound.Play();

        playerMeshRenderer.material = damageMaterial;
        yield return new WaitForSeconds(invincibleTime);
        playerMeshRenderer.material = normalMaterial;

        if (damageEffectCoroutine != null)
        {
            damageEffectCoroutine = null;
        }
        
    }
}