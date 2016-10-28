using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace VIK.Core
{
    class SpeechManager
    {
        private SpeechRecognitionEngine _recognizer = null;
        private SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        private List<VoiceInfo> voicesInfoList = new List<VoiceInfo>();

        public SpeechManager()
        {

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
                
                GrammarManager grammarManager = new GrammarManager();

                _recognizer.LoadGrammar(grammarManager.CustomGrammar());

                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);

                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
        public void StopSpeech()
        {
            if (_recognizer != null)
            {
                _recognizer.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
                _recognizer = null;
            }
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit word in e.Result.Words)
            {
                /*if (word.Text.Equals("VIK"))
                {
                    activoComando = true;
                }
                */
                //lbPalabrasReconocidas.Items.Add(word.Text);

                double Volumen = 90;
                double Rate = 0;

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
    }
}
