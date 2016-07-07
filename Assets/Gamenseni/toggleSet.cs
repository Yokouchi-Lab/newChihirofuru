using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleSet : MonoBehaviour {

  void Start () {
  }

  /// 表示・非表示を設定
  public static void SetActive(Toggle _toggle,bool b) {
    foreach(Transform child in _toggle.transform) {
      // 子の要素をたどる
      if(child.name == "Text") {
        child.gameObject.SetActive(b);
        // おしまい
        return;
      }
    }
    // 指定したオブジェクト名が見つからなかった
    Debug.LogWarning("Not found objname:"+"Text");
  }
}
