namespace DronesWebApi.Endpoints
{
    public interface IEndpointGroup
    {
        void RegisterPortalEndpoints(RouteGroupBuilder portalGroup);
    }
}
