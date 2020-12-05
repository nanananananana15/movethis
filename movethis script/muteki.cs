using System;
using System.Collections;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;
/// <summary>
/// Player�ɃA�^�b�`
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

        //�G�ɓ��������特�����ă}�e���A���ύX�����G���Ԃ�����ďI�������}�e���A�������ɖ߂�
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