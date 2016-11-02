using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Threading;

namespace VIK.Core
{
    class SpeechManager
    {
        private SpeechRecognitionEngine _recognizer = null;
        private GrammarManager grammarManager = null;
        private bool IsActive = false;
        
        public List<String> WordList { get; set; }

        public SpeechManager()
        {
            WordList = new List<string>();

            grammarManager = new GrammarManager();
        }

        public void RefreshGrammarWithWords(string fileName)
        {
            StopSpeech();
            grammarManager = new GrammarManager(fileName);
            Thread.Sleep(200);
            StartSpeech();
            _recognizer.UnloadAllGrammars();
            _recognizer.LoadGrammar(grammarManager.CustomGrammar());
        }

        private void InitSpeech()
        {
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.SetInputToDefaultAudioDevice();

            _recognizer.LoadGrammar(grammarManager.CustomGrammar());
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
        }

        public void StartSpeech()
        {
            if (_recognizer == null)
            {
                InitSpeech();
            }

            if(IsActive == false)
            {
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                IsActive = true;
            }
        }

        public void StopSpeech()
        {
            if (IsActive == true)
            {
                _recognizer.RecognizeAsyncStop();
                IsActive = false;
            }
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit word in e.Result.Words)
            {
                WordList.Add(word.Text);
            }
        }
    }
}
