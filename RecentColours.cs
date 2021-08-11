// RecentColours.cs
// Copyright Karel Kroeze, 2018-2018

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Verse;

namespace ColourPicker {
    public class RecentColours {
        private const int max = 20;
        private static List<Color> _colors = new List<Color>();

        static RecentColours() {
            Read();
        }

        public Color this[int index] => _colors[index];

        public int Count => _colors.Count;

        public void Add(Color color) {
            _colors.RemoveAll(c => c == color);
            _colors.Insert(0, color);

            while (_colors.Count > max) {
                _colors.RemoveAt(_colors.Count - 1);
            }

            Write();
        }

        private static void Read() {
            string path = Path.Combine(GenFilePaths.ConfigFolderPath, "ColourPicker.xml");
            if (!File.Exists(path)) {
                return;
            }

            try {
                Scribe.loader.InitLoading(path);
                ExposeData();
            } catch (Exception ex) {
                Log.Error("ColourPicker :: Error loading recent colours from file:" + ex);
            } finally {
                Scribe.loader.FinalizeLoading();
            }
        }

        private static void Write() {
            try {
                string path = Path.Combine( GenFilePaths.ConfigFolderPath, "ColourPicker.xml" );
                Scribe.saver.InitSaving(path, "ColourPicker");
                ExposeData();
            } catch (Exception ex) {
                Log.Error("ColourPicker :: Error saving recent colours to file:" + ex);
            } finally {
                Scribe.saver.FinalizeSaving();
            }
        }

        private static void ExposeData() {
            Scribe_Collections.Look(ref _colors, "RecentColors");
        }
    }
}
