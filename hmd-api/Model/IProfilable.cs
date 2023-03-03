namespace hmd_api.Model
{
    public interface IProfilable
    {
        public void SetProfile(TrackProfile trackProfile);
        public TrackProfile GetProfile();
    }
}