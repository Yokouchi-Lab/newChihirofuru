using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

  static Panel _panel;
  static Toggle _toggle;

  void Start () {
    _panel = GetComponent<Panel>();
  }

  /// 表示・非表示を設定
  public static void SetActive(string name, bool b) {
    foreach(Transform child in _panel.transform) {
      // 子の要素をたどる
      if(child.name == name) {
        // 指定した名前と一致
        // 表示フラグを設定
        child.gameObject.SetActive(b);
        // おしまい
        return;
      }
    }

    // 指定したオブジェクト名が見つからなかった
    Debug.LogWarning("Not found objname:"+name);
  }
}
