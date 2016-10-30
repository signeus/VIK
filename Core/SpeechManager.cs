using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

namespace VIK.Core
{
    class SpeechManager
    {
        private SpeechRecognitionEngine _recognizer = null;
        private SpeechSynthesizer _synthesizer = null;
        private List<VoiceInfo> voicesInfoList = null;
        private GrammarManager grammarManager = null;
        private bool IsActive = false;

        public List<String> HypoWordList { get; set; }
        public List<String> WordList { get; set; }

        public SpeechManager()
        {
            HypoWordList = new List<string>();
            WordList = new List<string>();

            grammarManager = new GrammarManager();
            _synthesizer = new SpeechSynthesizer();
            voicesInfoList = new List<VoiceInfo>();
            InitSpeech();

            StartSpeech();
        }

        public void RefreshGrammarWithWords(string fileName)
        {
            StopSpeech();
            grammarManager = new GrammarManager(fileName);
            Thread.Sleep(2000);
            StartSpeech();
            _recognizer.UnloadAllGrammars();
            _recognizer.LoadGrammar(grammarManager.CustomGrammar());
        }

        public void InitSpeech()
        {
            foreach (InstalledVoice voice in _synthesizer.GetInstalledVoices())
            {
                voicesInfoList.Add(voice.VoiceInfo);
            }
        }

        public void StartSpeech()
        {
            if (_recognizer == null)
            {
                _recognizer = new SpeechRecognitionEngine();
                _recognizer.SetInputToDefaultAudioDevice();

                _recognizer.LoadGrammar(grammarManager.CustomGrammar());
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            }

            if(_recognizer != null && IsActive == false)
            {
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                IsActive = true;
            }
        }

        public void StopSpeech()
        {
            if (_recognizer != null && IsActive == true)
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

                /*if (word.Text.Equals("VIK"))
                {
                    activoComando = true;
                }
                */
                //lbPalabrasReconocidas.Items.Add(word.Text);

                //double Volumen = 90;
                //double Rate = 0;

                //_synthesizer.Volume = (int)Volumen;
                //_synthesizer.Rate = (int)Rate;
                //_synthesizer.Speak(word.Text);
            }
            /*
            if (!word.Text.Equals(""))
            {
                foreach (char character in word.Text)
                {
                    SendKeys.Send(character.ToString());
                }
            }
            */
        }

        /*
        private void _recognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            foreach (var hypo in e.Result.Words)
            {
                HypoWordList.Add(hypo.Text);
            }
        }
        */
    }
}
