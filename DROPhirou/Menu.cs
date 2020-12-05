using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private ItemsDialog itemsDialog;
    [SerializeField] private WeaponDialog weaponDialog;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;

    [SerializeField] private Button itemsButton;
    [SerializeField] private Button weaponButton;

    private void Start()
    {
        pausePanel.SetActive(false); // �|�[�Y�̃p�l���͏�����Ԃł͔�\���ɂ��Ă���

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        itemsButton.onClick.AddListener(ToggleItemsDialog);
        weaponButton.onClick.AddListener(ToggleWeaponDialog);
    }

    /// <summary>
    /// �Q�[�����ꎞ��~���܂��B
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0; // Time.timeScale�Ŏ��Ԃ̗���̑��������߂�B0���Ǝ��Ԃ���~����
        pausePanel.SetActive(true);


    }

    /// <summary>
    /// �Q�[�����ĊJ���܂��B
    /// </summary>
    private void Resume()
    {
        Time.timeScale = 1; // �܂����Ԃ������悤�ɂ���
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// �A�C�e���E�C���h�E���J���܂��B
    /// </summary>
    private void ToggleItemsDialog()
    {
        itemsDialog.Toggle();
    }

    /// <summary>
    /// ���V�s�E�C���h�E���J���܂��B
    /// </summary>
    private void ToggleWeaponDialog()
    {
        weaponDialog.Toggle();
    }
}