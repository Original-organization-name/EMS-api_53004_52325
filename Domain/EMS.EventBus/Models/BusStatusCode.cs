﻿namespace EMS.EventBus.Models;

public enum BusStatusCode
{
    Success = 200,
    
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    
    InternalServerError = 500,
}