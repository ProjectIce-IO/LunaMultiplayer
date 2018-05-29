﻿using LunaClient.Base;
using LunaClient.Localization;
using LunaClient.Systems.SettingsSys;
using UnityEngine;

namespace LunaClient.Windows.Update
{
    /// <summary>
    /// Here we should only display the statistics for systems that contain ROUTINES or code that executes on every fixedupdate/update/lateupdate
    /// </summary>
    public partial class UpdateWindow : Window<UpdateWindow>
    {
        #region Fields & properties

        public static string CurrentVersion;
        public static string LatestVersion;
        public static string Changelog;

        private static bool _display;
        public override bool Display
        {
            get => base.Display && _display && HighLogic.LoadedScene <= GameScenes.MAINMENU && SettingsSystem.CurrentSettings.DisclaimerAccepted;
            set => base.Display = _display = value;
        }

        private const float WindowHeight = 250;
        private const float WindowWidth = 400;

        #endregion

        public override void OnGui()
        {
            base.OnGui();
            if (Display)
            {
                WindowRect = FixWindowPos(GUILayout.Window(6724 + MainSystem.WindowOffset, WindowRect, DrawContent, LocalizationContainer.UpdateWindowText.Title, WindowStyle, LayoutOptions));
            }
        }

        public override void SetStyles()
        {
            WindowRect = new Rect(Screen.width - (WindowWidth + 50), Screen.height / 2f - WindowHeight / 2f, WindowWidth, WindowHeight);
            MoveRect = new Rect(0, 0, 10000, 20);

            LayoutOptions = new GUILayoutOption[4];
            LayoutOptions[0] = GUILayout.MinWidth(WindowWidth);
            LayoutOptions[1] = GUILayout.MaxWidth(WindowWidth);
            LayoutOptions[2] = GUILayout.MinHeight(WindowHeight);
            LayoutOptions[3] = GUILayout.MaxHeight(WindowHeight);

            TextAreaOptions = new GUILayoutOption[1];
            TextAreaOptions[0] = GUILayout.ExpandWidth(true);
        }
    }
}
