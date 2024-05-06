using drones_core.Dtos;
using DronesWebApi.ApiServices;
using DronesWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DronesWebApi.Endpoints
{
    public class DroneEndpoints: IEndpointGroup
    {
        private string groupRoute = "drones";
        private string groupTag = "Drones";
        public void RegisterPortalEndpoints(RouteGroupBuilder portalGroup)
        {
            var endpoints = portalGroup.MapGroup($"{groupRoute}").WithTags(groupTag);
            endpoints.MapPost("/",
                async ( DroneApiDto drone, [FromServices] DroneApiService service) =>
                 await service.CreateDrone(drone));
            endpoints.MapPost("/charge-medicines",
                async (ChargeDroneWithMedicinesDto dto, [FromServices] DroneApiService service) =>
                 await service.ChargeDroneWithMedicines(dto.Guid, dto));
            endpoints.MapGet("/",
                (DroneApiService service) =>
                service.GetDrones());
            endpoints.MapGet("/available",
                ([FromServices] DroneApiService service) =>
                service.GetAvailableDrones());
            endpoints.MapGet("/{guid}",
                (string guid, [FromServices] DroneApiService service) =>
                service.GetDroneByGuid(guid));
            endpoints.MapGet("/{guid}/battery",
                (string guid, [FromServices] DroneApiService service) =>
                service.GetDroneBatteryByGuid(guid));
            endpoints.MapGet("/{guid}/total-medicines-weight",
                (string guid, [FromServices] DroneApiService service) =>
                service.GetDroneMedicineWeightByGuid(guid));

        }
    }
}
