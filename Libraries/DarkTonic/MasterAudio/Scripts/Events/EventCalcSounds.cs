using UnityEngine;

[AddComponentMenu("Dark Tonic/Master Audio/Event Calc Sounds")]
// ReSharper disable once CheckNamespace
public class EventCalcSounds : MonoBehaviour {
	public const int FramesEarlyToTrigger = 2;
	
    // ReSharper disable InconsistentNaming
	public MasterAudio.SoundSpawnLocationMode soundSpawnMode = MasterAudio.SoundSpawnLocationMode.CallerLocation;
	public bool disableSounds = false;
	
	public AudioEvent audioSourceEndedSound;
	
	public bool useAudioSourceEndedSound = false;
    // ReSharper restore InconsistentNaming
	
	private AudioSource _audio;
	private Transform _trans;
	
    // ReSharper disable once UnusedMember.Local
	void Awake() { 
		_trans = transform;
		_audio = GetComponent<AudioSource>();
		SpawnedOrAwake();
	}
	
	protected virtual void SpawnedOrAwake() {
	}
	
	protected virtual void _AudioSourceEnded() {
		PlaySound(audioSourceEndedSound);
	}
	
	private void PlaySound(AudioEvent aEvent) {
		if (disableSounds) {
			return;
		}
		
		var volume = aEvent.volume;
		var sType = aEvent.soundType;
		float? pitch = aEvent.pitch;
		if (!aEvent.useFixedPitch) {
			pitch = null;
		}
		
		PlaySoundResult soundPlayed = null;
		
		switch (soundSpawnMode) {
			case MasterAudio.SoundSpawnLocationMode.CallerLocation:
                if (aEvent.emitParticles) {
                    soundPlayed = MasterAudio.PlaySound3DAtTransform(sType, _trans, volume, pitch);
                } else {
                    MasterAudio.PlaySound3DAtTransformAndForget(sType, _trans, volume, pitch);
                }
				break;
			case MasterAudio.SoundSpawnLocationMode.AttachToCaller:
                if (aEvent.emitParticles) {
                    soundPlayed = MasterAudio.PlaySound3DFollowTransform(sType, _trans, volume, pitch);
                } else {
                    MasterAudio.PlaySound3DFollowTransformAndForget(sType, _trans, volume, pitch);
                }
				break;
			case MasterAudio.SoundSpawnLocationMode.MasterAudioLocation:
                if (aEvent.emitParticles) {
                    soundPlayed = MasterAudio.PlaySound(sType, volume);
                } else {
                    MasterAudio.PlaySoundAndForget(sType, volume);
                }
				break;
		}

		if (soundPlayed == null || !soundPlayed.SoundPlayed) {
			return;
		}
		
		MasterAudio.TriggerParticleEmission(_trans, aEvent.particleCountToEmit);
	}
	
    // ReSharper disable once UnusedMember.Local
	void Update() {
		CheckForEvents();
	}
	
	private void CheckForEvents() {
	    if (!useAudioSourceEndedSound || _audio == null || _audio.clip == null)
	    {
	        return;
	    }
	    if (!(_audio.clip.length - _audio.time < Time.deltaTime*FramesEarlyToTrigger))
	    {
	        return;
	    }
	    // just looped
	    _audio.Stop();
	    if (_audio.loop) {
	        _audio.Play();
	    }
	    _AudioSourceEnded();
	}
}
