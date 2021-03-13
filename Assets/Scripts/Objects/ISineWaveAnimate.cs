internal interface ISineWaveAnimate
{
    void SetCorrectSineWaveSpeed(float amount);
    void SetOutputSineWaveSpeed(float amount);
    void AnimateSignWave(bool animState);
    void ResetSignWave();
}