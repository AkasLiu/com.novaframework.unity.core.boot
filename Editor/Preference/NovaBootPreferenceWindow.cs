using System.Collections;
using System.Collections.Generic;
using NovaFramework.Editor.Preference;
using UnityEngine;

namespace NovaFramework.Editor
{
    public class NovaBootPreferenceWindow : PreferenceWindow
    {
        public override string PagingName => "环境配置";

        public override void OnDraw()
        {
            NovaBootInstallationStep installStep = new NovaBootInstallationStep();
            
            // 初始化按钮
            GUIStyle initButtonStyle = RichTextUtils.GetButtonTextOnlyStyle(Color.green);
            if (GUILayout.Button("初始化", initButtonStyle, GUILayout.Height(35)))
            {
                installStep.Install(() =>
                {
                    Debug.Log("初始化完成");
                }, () =>
                {
                    Debug.LogError("初始化失败");
                });
            }
        }
    }
}

