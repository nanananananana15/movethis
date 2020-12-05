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
        pausePanel.SetActive(false); // ポーズのパネルは初期状態では非表示にしておく

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        itemsButton.onClick.AddListener(ToggleItemsDialog);
        weaponButton.onClick.AddListener(ToggleWeaponDialog);
    }

    /// <summary>
    /// ゲームを一時停止します。
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0; // Time.timeScaleで時間の流れの速さを決める。0だと時間が停止する
        pausePanel.SetActive(true);


    }

    /// <summary>
    /// ゲームを再開します。
    /// </summary>
    private void Resume()
    {
        Time.timeScale = 1; // また時間が流れるようにする
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// アイテムウインドウを開閉します。
    /// </summary>
    private void ToggleItemsDialog()
    {
        itemsDialog.Toggle();
    }

    /// <summary>
    /// レシピウインドウを開閉します。
    /// </summary>
    private void ToggleWeaponDialog()
    {
        weaponDialog.Toggle();
    }
}