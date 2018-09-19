using System.Text;
using ClassLibPhone.Components;
using ClassLibPhone.Component_Interfaces;
using ClassLibPhone.Content;

namespace ClassLibPhone {

    public abstract class MobilePhone {
        
        public IPlayback PlaybackComponent { get; set; }
        public ICharger ChargerComponent { get; set; }
        public IProtector ProtectorComponent { get; set; }

        public abstract AerialBase AerialBase { get; }
        public abstract BatteryBase BatteryBase { get; }
        public abstract DynamicBase DynamicBase { get; }
        public abstract KeyboardBase KeyboardBase { get; }
        public abstract MicrophoneBase MicrophoneBase { get; }
        public abstract ScreenBase ScreenBase { get; }
        public abstract SimCardBase SimCardBase { get; }

        public SMSProvider SMSProvider { get; set; }

        private void Show(IScreenImage screenImage) {
            ScreenBase.Show(screenImage);
        }
        
        public void Play(object data) {
            PlaybackComponent.Play(data);
        }

        public void Charge(object data) {
            ChargerComponent.Charge(data);
        }

        public void Put(object data) {
            ProtectorComponent.Put(data);
        }
        
        public string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Aerial Type: {AerialBase.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {BatteryBase.ToString()}");
            descriptionBuilder.AppendLine($"Dynamic Type: {DynamicBase.ToString()}");
            descriptionBuilder.AppendLine($"Keyboard Type: {KeyboardBase.ToString()}");
            descriptionBuilder.AppendLine($"Microphone Type: {MicrophoneBase.ToString()}");
            descriptionBuilder.AppendLine($"Screen Type: {ScreenBase.ToString()}");
            descriptionBuilder.AppendLine($"SimCard Type: {SimCardBase.ToString()}");
            return descriptionBuilder.ToString();
        }
        
    }

}
