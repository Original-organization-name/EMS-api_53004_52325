﻿namespace EMS.DTO.Records;

public record TrainingModel(
    Guid Id,
    Guid EmployeeId,
    Guid TrainingItemId,
    string TrainingItem,
    DateTime ExecutionDate,
    DateTime? ExpirationDate = null);
