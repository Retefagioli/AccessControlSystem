using DataAccess.Models;
using DataAccess.Data;

namespace BadgeSystemMinimalAPI
{
    public static class API
    {
        private static readonly string _apiBaseUrl = "/api";
        public static void ConfigureAPI(this WebApplication app)
        {
            app.MapGet(_apiBaseUrl + "/Users", GetUsers);
            app.MapGet(_apiBaseUrl + "/Users/{id}", GetUser);
            app.MapPost(_apiBaseUrl + "/Users", InsertUser);
            app.MapPut(_apiBaseUrl + "/Users", UpdateUser);
            app.MapDelete(_apiBaseUrl + "/Users", DeleteUser);

            app.MapGet(_apiBaseUrl + "/Sensors", GetSensors);
            app.MapGet(_apiBaseUrl + "/Sensors/{id}", GetSensorById);
            app.MapGet(_apiBaseUrl + "/Sensors/by-nfcTag/{nfcTag}", GetSensorByNFCTag);
            app.MapPost(_apiBaseUrl + "/Sensors", InsertSensor);
            app.MapPut(_apiBaseUrl + "/Sensors", UpdateSensor);
            app.MapDelete(_apiBaseUrl + "/Sensors", DeleteSensor);

            app.MapGet(_apiBaseUrl + "/Groups", GetGroups);
            app.MapGet(_apiBaseUrl + "/Groups/{id}", GetGroup);
            app.MapGet(_apiBaseUrl + "/Groups/by-name/{name}", GetGroupByName);
            app.MapPost(_apiBaseUrl + "/Groups", InsertGroup);
            app.MapPut(_apiBaseUrl + "/Groups", UpdateGroup);
            app.MapDelete(_apiBaseUrl + "/Groups", DeleteGroup);

            app.MapGet(_apiBaseUrl + "/Badges", GetBadges);
            app.MapGet(_apiBaseUrl + "/Badges/{id}", GetBadge);
            app.MapGet(_apiBaseUrl + "/Badges/by-nfcTag/{nfcTag}", GetBadgeByNFCTag);
            app.MapPost(_apiBaseUrl + "/Badges", InsertBadge);
            app.MapPut(_apiBaseUrl + "/Badges", UpdateBadge);
            app.MapDelete(_apiBaseUrl + "/Badges", DeleteBadge);

            app.MapGet(_apiBaseUrl + "/Logs", GetLogs);
            app.MapGet(_apiBaseUrl + "/Logs/{id}", GetLog);
            app.MapGet(_apiBaseUrl + "/Logs/by-user/", GetLogsByUserId);
            app.MapGet(_apiBaseUrl + "/Logs/by-sensor/", GetLogsBySensorId);
            app.MapGet(_apiBaseUrl + "/Logs/by-data/", GetLogsByDateTime);
            app.MapPost(_apiBaseUrl + "/Logs", InsertLog);
            app.MapPut(_apiBaseUrl + "/Logs", UpdateLog);
            app.MapDelete(_apiBaseUrl + "/Logs", DeleteLog);

            app.MapGet(_apiBaseUrl + "/AccessToken", GetAccessTokens);
            app.MapGet(_apiBaseUrl + "/AccessToken/{id}", GetAccessToken);
            app.MapGet(_apiBaseUrl + "/AccessToken/Token/{token}", GetAccessTokenByToken);
            app.MapPost(_apiBaseUrl + "/AccessToken", InsertAccessToken);
            app.MapPut(_apiBaseUrl + "/AccessToken", UpdateAccessToken);
            app.MapDelete(_apiBaseUrl + "/AccessToken", DeleteAccessToken);
        }

        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUser(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                var result = Results.Ok(await data.GetUsers());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertUser(CreateUserModel user, IUserData data)
        {
            try
            {

                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetSensorById(int id, ISensorData data)
        {
            try
            {
                return Results.Ok(await data.GetSensorById(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetSensorByNFCTag(string NFCTag, ISensorData data)
        {
            try
            {
                return Results.Ok(await data.GetSensorByNFCTag(NFCTag));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }


        private static async Task<IResult> GetSensors(ISensorData data)
        {
            try
            {
                var result = Results.Ok(await data.GetSensors());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertSensor(CreateSensorModel sensor, ISensorData data)
        {
            try
            {
                await data.InsertSensor(sensor);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateSensor(SensorModel sensor, ISensorData data)
        {
            try
            {
                await data.UpdateSensor(sensor);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteSensor(int id, ISensorData data)
        {
            try
            {
                await data.DeleteSensor(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetGroup(int id, IGroupData data)
        {
            try
            {
                return Results.Ok(await data.GetGroup(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetGroupByName(string name, IGroupData data)
        {
            try
            {
                return Results.Ok(await data.GetGroupByName(name));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetGroups(IGroupData data)
        {
            try
            {
                var result = Results.Ok(await data.GetGroups());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertGroup(CreateGroupModel group, IGroupData data)
        {
            try
            {
                await data.InsertGroup(group);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateGroup(GroupModel group, IGroupData data)
        {
            try
            {
                await data.UpdateGroup(group);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteGroup(int id, IGroupData data)
        {
            try
            {
                await data.DeleteGroup(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetBadge(int id, IBadgeData data)
        {
            try
            {
                return Results.Ok(await data.GetBadge(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetBadgeByNFCTag(string nfcTag, IBadgeData data)
        {
            try
            {
                return Results.Ok(await data.GetBadgeByNFCTag(nfcTag));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetBadges(IBadgeData data)
        {
            try
            {
                var result = Results.Ok(await data.GetBadges());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertBadge(CreateBadgeModel badge, IBadgeData data)
        {
            try 
            {
                Validation.validation(badge, data);
                await data.InsertBadge(badge);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateBadge(BadgeModel badge, IBadgeData data)
        {
            try
            {
                await data.UpdateBadge(badge);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteBadge(int id, IBadgeData data)
        {
            try
            {
                await data.DeleteBadge(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }
        private static async Task<IResult> GetLog(int id, ILogData data)
        {
            try
            {
                return Results.Ok(await data.GetLog(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetLogsByDateTime(DateTime dataTime, ILogData data)
        {
            try
            {
                return Results.Ok(await data.GetLogsByDateTime(dataTime));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetLogsByUserId(int userId, ILogData data)
        {
            try
            {
                return Results.Ok(await data.GetLogsByUserId(userId));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetLogsBySensorId(int sensorId, ILogData data)
        {
            try
            {
                return Results.Ok(await data.GetLogsBySensorId(sensorId));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetLogs(ILogData data)
        {
            try
            {
                var result = Results.Ok(await data.GetLogs());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertLog(CreateLogModel log, ILogData data)
        {
            try
            {
                await data.InsertLog(log);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateLog(LogModel log, ILogData data)
        {
            try
            {
                await data.UpdateLog(log);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteLog(int id, ILogData data)
        {
            try
            {
                await data.DeleteLog(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetAccessToken(int id, IAccessTokenData data)
        {
            try
            {
                return Results.Ok(await data.GetAccessTokenById(id));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetAccessTokenByToken(string token, IAccessTokenData data)
        {
            try
            {
                return Results.Ok(await data.GetAccessTokenByToken(token));
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> GetAccessTokens(IAccessTokenData data)
        {
            try
            {
                var result = Results.Ok(await data.GetAccessTokens());
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> InsertAccessToken(CreateAccessTokenModel token, IAccessTokenData data)
        {
            try
            {

                await data.InsertAccessToken(token);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> UpdateAccessToken(AccessTokenModel token, IAccessTokenData data)
        {
            try
            {
                await data.UpdateAccessToken(token);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        private static async Task<IResult> DeleteAccessToken(int id, IAccessTokenData data)
        {
            try
            {
                await data.DeleteAccessToken(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }
    }

}