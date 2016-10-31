using System.Collections.Generic;
using System.Speech.Synthesis;

namespace VIK.Core.SynthesizerModule
{
    class VIKSynthesizer
    {
        private SpeechSynthesizer _synthesizer = null;
        public List<VoiceInfo> voicesInfoList { get; set; }
        private double Volumen = 100;
        private double Rate = 0;

        public VIKSynthesizer()
        {
            _synthesizer = new SpeechSynthesizer();
            voicesInfoList = new List<VoiceInfo>();
        }

        public void RecoverVoicesFromSystem()
        {
            foreach (InstalledVoice voice in _synthesizer.GetInstalledVoices())
            {
                voicesInfoList.Add(voice.VoiceInfo);
            }
        }

        public void ReadAloudThisWord(string word)
        {
            _synthesizer.Volume = (int)Volumen;
            _synthesizer.Rate = (int)Rate;
            _synthesizer.Speak(word);
        }

        public void ReadAloudThisWord(string word, double volume, double rate)
        {
            _synthesizer.Volume = (int)volume;
            _synthesizer.Rate = (int)rate;
            _synthesizer.Speak(word);
        }
    }
}
